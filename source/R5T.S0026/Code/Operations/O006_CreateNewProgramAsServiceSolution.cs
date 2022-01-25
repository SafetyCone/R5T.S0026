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
                // Basic.
                Instances.ProjectPath.R5T_Magyar(),
                // For program-as-a-service basic functionality.
                Instances.ProjectPath.R5T_D0088_X001(),
                Instances.ProjectPath.R5T_D0088_I0002(),
                Instances.ProjectPath.R5T_D0090_X001(),
                Instances.ProjectPath.R5T_L0014_X001(),
                Instances.ProjectPath.R5T_T0070_X001(),
                // For the A0003 services platform.
                Instances.ProjectPath.R5T_A0003(),
                Instances.ProjectPath.R5T_D0081_I001(),
                Instances.ProjectPath.R5T_Ostrogothia_Rivet(),
                Instances.ProjectPath.R5T_D0048_Default(),
                // For SerializeConfigurationAudit.
                Instances.ProjectPath.R5T_D0102_X001(),
                // For SerializeServiceCollectionAudit.
                Instances.ProjectPath.R5T_D0104_X001(),
            };

            var instanceExtensionMethodBaseNamespacedTypeNames = new[]
            {
                Instances.NamespacedTypeName.IHost_ExtensionMethodBase(),
                Instances.NamespacedTypeName.IServiceAction_ExtensionMethodBase(),
            };

            var entryPointProjectReferenceFilePaths = await Instances.ProjectOperator.GetFilePathsForProjectIdentityStrings(
                entryPointProjectReferenceIdentityStrings,
                this.ProjectRepository);

            // Create the first step of the solution.
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
                        dependencyProjectReferenceFilePaths: entryPointProjectReferenceFilePaths);

                    await Instances.ProjectGenerator.CreateConsoleProject(
                        solutionFileContext,
                        entryPointProjectFileSpecification,
                        this.VisualStudioProjectFileOperator,
                        this.VisualStudioSolutionFileOperator,
                        async projectFileContext =>
                        {
                            var projectNamespaceName = entryPointProjectFileSpecification.DefaultNamespaceName;

                            // Delete the initial program file (wrog location).
                            projectFileContext.DeleteInitialProgramFile();

                            // Create the new program class file.
                            await projectFileContext.CreateProgramFile(async programFileContext =>
                            {
                                await Instances.CodeFileGenerator.CreateProgramAsAService(
                                    programFileContext.FilePath,
                                    projectNamespaceName);
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
                            await projectFileContext.CreateHostStartupFile(async hostStartupFileContext =>
                            {
                                await Instances.CodeFileGenerator.CreateHostStartup(
                                    hostStartupFileContext.FilePath,
                                    projectNamespaceName);
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
