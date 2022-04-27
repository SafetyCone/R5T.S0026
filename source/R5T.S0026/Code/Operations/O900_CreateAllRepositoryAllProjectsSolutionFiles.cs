using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.Magyar;

using R5T.D0084.D001;
using R5T.T0020;

using R5T.S0026.Library;


namespace R5T.S0026
{
    /// <summary>
    /// For all local repositories, create a solution file that references all project files contained in the repository.
    /// Check if the solution exists already, and update instead of create if it does exist.
    /// Commit and push *just* the solution file to GitHub.
    /// </summary>
    [OperationMarker]
    public class O900_CreateAllRepositoryAllProjectsSolutionFiles : IActionOperation
    {
        private IAllRepositoryDirectoryPathsProvider AllRepositoryDirectoryPathsProvider { get; }
        private ILocalRepositoryContextProvider LocalRepositoryContextProvider { get; }
        private ILogger Logger { get; }
        private ISolutionContextProvider SolutionContextProvider { get; }


        public O900_CreateAllRepositoryAllProjectsSolutionFiles(
            IAllRepositoryDirectoryPathsProvider allRepositoryDirectoryPathsProvider,
            ILocalRepositoryContextProvider localRepositoryContextProvider,
            ILogger<O900_CreateAllRepositoryAllProjectsSolutionFiles> logger,
            ISolutionContextProvider solutionContextProvider)
        {
            this.AllRepositoryDirectoryPathsProvider = allRepositoryDirectoryPathsProvider;
            this.LocalRepositoryContextProvider = localRepositoryContextProvider;
            this.Logger = logger;
            this.SolutionContextProvider = solutionContextProvider;
        }

        public async Task Run()
        {
            var repositoryDirectoryPaths = await this.AllRepositoryDirectoryPathsProvider.GetAllRepositoryDirectoryPaths();

            //var repositoryDirectoryPaths = new[]
            //{
            //    @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing2.Private",
            //};

            foreach (var repositoryDirectoryPath in repositoryDirectoryPaths)
            {
                await this.LocalRepositoryContextProvider.InLocalRepositoryContextByDirectoryPath_WithoutExistenceCheck(
                    repositoryDirectoryPath,
                    async localRepositoryContext =>
                    {
                        var isRepository = await localRepositoryContext.IsRepository();
                        if(!isRepository)
                        {
                            this.Logger.LogInformation($"Skipping directory since it is not a repository:\n{localRepositoryContext.DirectoryPath}");

                            return;
                        }

                        // Assume repository will exist.

                        this.Logger.LogInformation($"Processing repository:\n{localRepositoryContext.DirectoryPath}");

                        var repositoryName = localRepositoryContext.GetRepositoryName();

                        var solutionName = $"{repositoryName}.ΩAll";

                        await this.SolutionContextProvider.InSolutionContext_WithoutExistenceCheck(
                            solutionName,
                            localRepositoryContext,
                            async solutionContext =>
                            {
                                // We need to know if the solution file exists.
                                var solutionFileExists = solutionContext.FileExists();
                                if(!solutionFileExists)
                                {
                                    await solutionContext.Create();
                                }

                                // Get all projects in the solution directory.
                                var allProjectFilesInDirectory = Instances.FileSystemOperator.EnumerateAllDescendentFilePaths(
                                    solutionContext.DirectoryPath,
                                    SearchPatternHelper.AllFilesWithExtension(
                                        Instances.FileExtension.csproj()));

                                // Determine if the solution already contains all project files.
                                var hasProjectReferences = await solutionContext.HasProjectReferences(allProjectFilesInDirectory);

                                var hasAllProjectFilesInDirectory = hasProjectReferences.Values.All();
                                if(!hasAllProjectFilesInDirectory)
                                {
                                    var missingProjectFilePaths = hasProjectReferences
                                        .Where(xPair => !xPair.Value)
                                        .Select(xPair => xPair.Key)
                                        .Now();

                                    await solutionContext.AddProjectReferences(missingProjectFilePaths);
                                }

                                var fileWasModified = !solutionFileExists || !hasAllProjectFilesInDirectory;
                                if(fileWasModified)
                                {
                                    var commitMessage = solutionFileExists
                                        ? "Updating all-projects solution file."
                                        : "Created all-projects solution file."
                                        ;

                                    // Now commit & push.
                                    var localRepositoryDirectoryPath = T0010.LocalRepositoryDirectoryPath.From(localRepositoryContext.DirectoryPath);

                                    await localRepositoryContext.SourceControlOperator.Commit(
                                        localRepositoryDirectoryPath,
                                        solutionContext.FilePath,
                                        commitMessage);

                                    await localRepositoryContext.SourceControlOperator.Push(localRepositoryDirectoryPath);
                                }
                            });
                    });

                

                var solutionsDirectoryPath = Instances.SolutionPathsOperator.GetSourceSolutionDirectoryPath(repositoryDirectoryPath);



            }
        }
    }
}
