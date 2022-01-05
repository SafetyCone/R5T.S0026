using System;
using System.Threading.Tasks;

using R5T.D0037;
using R5T.D0078;
using R5T.D0079;
using R5T.D0082;
using R5T.D0084.D002;
using R5T.D0111.D001;
using R5T.T0104;


namespace R5T.S0026
{
    public class O003_CreateNewBasicTypesLibrary : T0020.IOperation
    {
        private IGitHubOperator GitHubOperator { get; }
        private IGitIgnoreTemplateFilePathProvider GitIgnoreTemplateFilePathProvider { get; }
        private IGitOperator GitOperator { get; }
        private IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }
        private IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        private IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public O003_CreateNewBasicTypesLibrary(
            IGitHubOperator gitHubOperator,
            IGitIgnoreTemplateFilePathProvider gitIgnoreTemplateFilePathProvider,
            IGitOperator gitOperator,
            IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.GitHubOperator = gitHubOperator;
            this.GitIgnoreTemplateFilePathProvider = gitIgnoreTemplateFilePathProvider;
            this.GitOperator = gitOperator;
            this.RepositoriesDirectoryPathProvider = repositoriesDirectoryPathProvider;
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }

        public async Task Run()
        {
            // Inputs.
            var libraryName = "R5T.T9999";
            var libraryDescription = "IName and related extension method bases.";
            var isPrivate = false;

            // Run.
            // Repositories.
            var repositoriesDirectoryPath = await this.RepositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

            // Repository.
            var unadjustedRepositoryName = Instances.LibraryNameOperator.GetRepositoryName(libraryName);
            var repositoryDescription = libraryDescription;

            var repositoryName = Instances.RepositoryNameOperator.AdjustRepositoryName(
                unadjustedRepositoryName,
                isPrivate);

            var repositorySpecification = new RepositorySpecification()
            {
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                Name = repositoryName,
            };

            var gitIgnoreTemplateFilePath = await this.GitIgnoreTemplateFilePathProvider.GetGitIgnoreTemplateFilePath();

            // Solution.
            var solutionName = Instances.LibraryNameOperator.GetSolutionName(libraryName);
            var solutionFileName = Instances.SolutionFileNameOperator.GetSolutionFileName(solutionName);

            // Make changes.
            var defaultGitIgnoreTemplateFilePath = await this.GitIgnoreTemplateFilePathProvider.GetGitIgnoreTemplateFilePath();

            await Instances.RepositoryGenerator.CreateRepository(
                repositorySpecification,
                repositoriesDirectoryPath,
                gitIgnoreTemplateFilePath,
                this.GitHubOperator,
                this.GitOperator,
                (localRepositoryContext) =>
                {
                    return Instances.LibraryGenerator.GenerateBasicTypesLibrary(
                        libraryName,
                        libraryDescription,
                        localRepositoryContext.DirectoryPath,
                        this.VisualStudioProjectFileOperator,
                        this.VisualStudioSolutionFileOperator);
                });
        }
    }
}
