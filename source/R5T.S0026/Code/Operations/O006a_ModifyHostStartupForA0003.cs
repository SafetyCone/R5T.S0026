using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0101;
using R5T.T0020;

using LocalData;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
    public class O006a_ModifyHostStartupForA0003 : IActionOperation
    {
        private IProjectRepository ProjectRepository { get; }
        private IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        private IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        private IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public O006a_ModifyHostStartupForA0003(
            IProjectRepository projectRepository,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.ProjectRepository = projectRepository;
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }

        public async Task Run()
        {
            // Inputs.
            var repositoriesDirectoryPath = @"C:\Code\DEV\Git\GitHub\SafetyCone";
            var libraryName = "Test";

            // Repository.
            var repositoryName = Instances.LibraryNameOperator.GetRepositoryName(libraryName);

            var repositoryDirectoryPath = Instances.RepositoryPathOperator.GetRepositoryDirectoryPath(
                repositoriesDirectoryPath,
                repositoryName);

            // Solution.
            var solutionName = Instances.LibraryNameOperator.GetSolutionName(libraryName);

            // Project - Entry point executable.
            var projectName = Instances.LibraryNameOperator.GetProjectName(libraryName);
            var projectDefaultNamespaceName = Instances.ProjectNameOperator.GetDefaultNamespaceNameFromProjectName(projectName);

            // Recreate the HostStartup file as it would be initially.
            await Instances.CodeFileOperator.InFileCreationContext(
                repositoryDirectoryPath,
                solutionName,
                projectName,
                Instances.ProjectPathsOperator.GetHostStartupFileRelativePath(),
                this.VisualStudioProjectFileOperator,
                this.VisualStudioProjectFileReferencesProvider,
                this.VisualStudioSolutionFileOperator,
                async hostStartupFileContext =>
                {
                    await Instances.CodeFileGenerator.CreateHostStartup(
                        hostStartupFileContext.CodeFilePath,
                        projectDefaultNamespaceName);
                });

            // Now modify project and HostStartup file for A0003 aggregation.
            await Instances.ProjectOperator.InModificationContext(
                repositoryDirectoryPath,
                solutionName,
                projectName,
                this.VisualStudioProjectFileOperator,
                this.VisualStudioProjectFileReferencesProvider,
                this.VisualStudioSolutionFileOperator,
                async projectFileModificationContext =>
                {
                    // Modify HostStartup
                    await Instances.CodeFileOperator.InModificationContextByCodeFileProjectDirectoryRelativeFilePath(
                        projectFileModificationContext,
                        Instances.ProjectPathsOperator.GetHostStartupFileRelativePath(),
                        async hostStartupContext =>
                        {
                            // Add code statements.
                            var outputCompilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_AddA0003(
                                hostStartupContext.CompilationUnit);

                            // Add project references to project and solution.
                            var dependencyProjectReferenceIdentityStrings = new[]
                            {
                                Instances.ProjectPath.R5T_A0003(),
                                Instances.ProjectPath.R5T_Magyar(), // TODO: check that no extraneous project references exist on the target project.
                                Instances.ProjectPath.R5T_D0081_I001(),
                                Instances.ProjectPath.R5T_Ostrogothia_Rivet(),
                                Instances.ProjectPath.R5T_D0048_Default(),
                            };

                            var dependendyProjectFilePaths = await Instances.ProjectOperator.GetFilePathsForProjectIdentityStrings(
                                dependencyProjectReferenceIdentityStrings,
                                this.ProjectRepository);

                            await hostStartupContext.AddDependencyProjectReferences(dependendyProjectFilePaths);

                            return outputCompilationUnit;
                        });
                });
        }
    }
}
