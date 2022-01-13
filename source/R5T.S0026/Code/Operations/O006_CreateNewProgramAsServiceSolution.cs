using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0101;
using R5T.T0020;

using LocalData;


namespace R5T.S0026
{
    public class O006_CreateNewProgramAsServiceSolution : IActionOperation
    {
        private IProjectRepository ProjectRepository { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        private IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        private IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        private IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public O006_CreateNewProgramAsServiceSolution(
            IProjectRepository projectRepository,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.ProjectRepository = projectRepository;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }

        public async Task Run()
        {
            // Inputs.
            var repositoriesDirectoryPath = @"C:\Code\DEV\Git\GitHub\SafetyCone";
            var libraryName = "Test";
            var libraryDescription = "A test of program-as-a-service solution/project creation.";

            // Run.
            // Repository.
            var repositoryName = Instances.LibraryNameOperator.GetRepositoryName(libraryName);
    
            var repositoryDirectoryPath = Instances.RepositoryPathOperator.GetRepositoryDirectoryPath(
                repositoriesDirectoryPath,
                repositoryName);

            // Solution.
            var solutionName = Instances.LibraryNameOperator.GetSolutionName(libraryName);

            // Project - Entry point executable.
            var projectName = Instances.LibraryNameOperator.GetProjectName(libraryName);
            var projectDescription = Instances.ProjectDescriptionGenerator.GetProjectDescription(libraryDescription);

            var entryPointProjectReferenceIdentityStrings = new[]
            {
                Instances.ProjectPath.R5T_D0088_X001(),
                Instances.ProjectPath.R5T_D0088_I0002(),
                Instances.ProjectPath.R5T_D0090_X001(),
                Instances.ProjectPath.R5T_L0014_X001(),
                Instances.ProjectPath.R5T_T0070_X001(),
            };

            var instanceExtensionMethodBaseNamespacedTypeNames = new[]
            {
                Instances.NamespacedTypeName.IHost_ExtensionMethodBase(),
            };

            var entryPointProjectReferenceFilePaths = await Instances.ProjectOperator.GetFilePathsForProjectIdentityStrings(
                entryPointProjectReferenceIdentityStrings,
                this.ProjectRepository);

            await Instances.SolutionOperator.CreateSolutionInExistingRepository(
                repositoryDirectoryPath,
                solutionName,
                this.VisualStudioSolutionFileOperator,
                async solutionFileContext =>
                {
                    var entryPointProjectFileSpecification = Instances.ProjectOperator.GetProjectFileSpecification(
                        projectName,
                        projectDescription,
                        solutionFileContext.DirectoryPath,
                        entryPointProjectReferenceFilePaths);

                    await Instances.ProjectGenerator.CreateConsoleProject(
                        solutionFileContext,
                        entryPointProjectFileSpecification,
                        this.VisualStudioProjectFileOperator,
                        this.VisualStudioSolutionFileOperator,
                        async projectFileContext =>
                        {
                            var projectNamespaceName = entryPointProjectFileSpecification.DefaultNamespaceName;

                            // Project class file.
                            await projectFileContext.CreateProjectFile(programFileContext =>
                            {
                                Instances.CodeFileGenerator.CreateProgramAsAService(
                                    programFileContext.FilePath,
                                    projectNamespaceName);

                                return Task.CompletedTask;
                            });

                            // Instances class file.
                            await projectFileContext.CreateInstancesFile(instancesFileContext =>
                            {
                                Instances.CodeFileGenerator.CreateInstances(
                                    instancesFileContext.FilePath,
                                    projectNamespaceName,
                                    instanceExtensionMethodBaseNamespacedTypeNames);

                                return Task.CompletedTask;
                            });

                            // HostStartup class.
                            await projectFileContext.CreateHostStartupFile(hostStartupFileContext =>
                            {
                                Instances.CodeFileGenerator.CreateHostStartup(
                                    hostStartupFileContext.FilePath,
                                    projectNamespaceName);

                                return Task.CompletedTask;
                            });

                            // IServiceCollectionExtensions
                            await projectFileContext.CreateIServiceCollectionExtensionsFile(iServiceCollectionExtensionsFileContext =>
                            {
                                Instances.CodeFileGenerator.CreateIServiceCollectionExtensions_Initial(
                                    iServiceCollectionExtensionsFileContext.FilePath,
                                    projectNamespaceName);

                                return Task.CompletedTask;
                            });

                            // IServiceActionExtensions
                            await projectFileContext.CreateIServicActionExtensionsFile(iServiceActionExtensionsFileContext =>
                            {
                                Instances.CodeFileGenerator.CreateIServiceActionExtensions_Initial(
                                    iServiceActionExtensionsFileContext.FilePath,
                                    projectNamespaceName);

                                return Task.CompletedTask;
                            });
                        });

                    // Add all dependency project references to the solution.
                    await Instances.SolutionOperator.AddProjectReferencesAndRecursiveDependencies(
                        solutionFileContext.FilePath,
                        entryPointProjectReferenceFilePaths,
                        this.StringlyTypedPathOperator,
                        this.VisualStudioProjectFileReferencesProvider,
                        this.VisualStudioSolutionFileOperator);
                });
        }
    }
}
