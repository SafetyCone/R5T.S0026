using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0045;


namespace R5T.S0026.Library
{
    public static class ICodeFileOperatorExtensions
    {
        public static async Task InFileCreationContext(this ICodeFileOperator _,
            string repositoryDirectoryPath,
            string solutionName,
            string projectName,
            string codeFileProjectDirectoryRelativeFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<ICodeFileContext, Task> codeFileContextAction = default)
        {
            // Assume source solution path.
            var solutionFilePath = Instances.SolutionPathsOperator.GetSourceSolutionFilePath(repositoryDirectoryPath, solutionName);

            var projectFilePath = Instances.ProjectPathsOperator.GetProjectFilePathFromSolutionFilePath(solutionFilePath, projectName);

            var projectDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(projectFilePath);

            var codeFilePath = Instances.PathOperator.GetFilePath(projectDirectoryPath, codeFileProjectDirectoryRelativeFilePath);

            await _.InFileCreationContext(
                solutionFilePath,
                projectFilePath,
                codeFilePath,
                visualStudioProjectFileOperator,
                visualStudioProjectFileReferencesProvider,
                visualStudioSolutionFileOperator,
                codeFileContextAction);
        }

        public static async Task InFileCreationContext(this ICodeFileOperator _,
            string solutionFilePath,
            string projectFilePath,
            string codeFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<ICodeFileContext, Task> codeFileContextAction = default)
        {
            // Ensure that files exist. Even if there's no action to perform, throw an exception.
            Instances.FileSystemOperator.VerifyFilesExist(
                solutionFilePath,
                projectFilePath);

            // If there's no action, do nothing.
            if (codeFileContextAction == default)
            {
                return;
            }

            var context = new CodeFileCreationContext
            {
                CodeFilePath = codeFilePath,
                ProjectFilePath = projectFilePath,
                SolutionFilePath = solutionFilePath,
                VisualStudioProjectFileOperator = visualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator,
            };

            // Context action is now not default (tested above).
            await codeFileContextAction(context);
        }

        public static async Task InCreationContext(this ICodeFileOperator _,
            string repositoryDirectoryPath,
            string solutionName,
            string projectName,
            string codeFileProjectDirectoryRelativeFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<ICodeFileCreationContext, Task<CompilationUnitSyntax>> codeFileCreationContextAction = default)
        {
            // Assume source solution path.
            var solutionFilePath = Instances.SolutionPathsOperator.GetSourceSolutionFilePath(repositoryDirectoryPath, solutionName);

            var projectFilePath = Instances.ProjectPathsOperator.GetProjectFilePathFromSolutionFilePath(solutionFilePath, projectName);

            var projectDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(projectFilePath);

            var codeFilePath = Instances.PathOperator.GetFilePath(projectDirectoryPath, codeFileProjectDirectoryRelativeFilePath);

            await _.InCreationContext(
                solutionFilePath,
                projectFilePath,
                codeFilePath,
                visualStudioProjectFileOperator,
                visualStudioProjectFileReferencesProvider,
                visualStudioSolutionFileOperator,
                codeFileCreationContextAction);
        }

        public static async Task InCreationContext(this ICodeFileOperator _,
            string solutionFilePath,
            string projectFilePath,
            string codeFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<ICodeFileCreationContext, Task<CompilationUnitSyntax>> codeFileCreationContextAction = default)
        {
            // Ensure that files exist. Even if there's no action to perform, throw an exception.
            Instances.FileSystemOperator.VerifyFilesExist(
                solutionFilePath,
                projectFilePath);

            // If there's no action, do nothing.
            if (codeFileCreationContextAction == default)
            {
                return;
            }

            var context = new CodeFileCreationContext
            {
                CodeFilePath = codeFilePath,
                ProjectFilePath = projectFilePath,
                SolutionFilePath = solutionFilePath,
                VisualStudioProjectFileOperator = visualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator,
            };

            // Context action is now not default (tested above).
            var compilationUnit = await codeFileCreationContextAction(context);

            await Instances.CompilationUnitOperator.Save(codeFilePath, compilationUnit);
        }

        public static async Task InModificationContext(this ICodeFileOperator _,
            string repositoryDirectoryPath,
            string solutionName,
            string projectName,
            string codeFileProjectDirectoryRelativeFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<ICompilationUnitModificationContext, Task<CompilationUnitSyntax>> codeFileModificationContextAction = default)
        {
            // Assume source solution path.
            var solutionFilePath = Instances.SolutionPathsOperator.GetSourceSolutionFilePath(repositoryDirectoryPath, solutionName);

            var projectFilePath = Instances.ProjectPathsOperator.GetProjectFilePathFromSolutionFilePath(solutionFilePath, projectName);

            var projectDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(projectFilePath);

            var codeFilePath = Instances.PathOperator.GetFilePath(projectDirectoryPath, codeFileProjectDirectoryRelativeFilePath);

            await _.InModificationContext(
                solutionFilePath,
                projectFilePath,
                codeFilePath,
                visualStudioProjectFileOperator,
                visualStudioProjectFileReferencesProvider,
                visualStudioSolutionFileOperator,
                codeFileModificationContextAction);
        }

        public static async Task InModificationContext(this ICodeFileOperator _,
            string solutionFilePath,
            string projectFilePath,
            string codeFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<ICompilationUnitModificationContext, Task<CompilationUnitSyntax>> codeFileModificationContextAction = default)
        {
            // Ensure that files exist. Even if there's no action to perform, throw an exception.
            Instances.FileSystemOperator.VerifyFilesExist(
                solutionFilePath,
                projectFilePath,
                codeFilePath);

            if(codeFileModificationContextAction == default)
            {
                return;
            }

            await Instances.CompilationUnitOperator.Modify(
                codeFilePath,
                async inputCompilationUnit =>
                {
                    var context = new CompilationUnitModificationContext
                    {
                        CodeFilePath = codeFilePath,
                        ProjectFilePath = projectFilePath,
                        SolutionFilePath = solutionFilePath,
                        VisualStudioProjectFileOperator = visualStudioProjectFileOperator,
                        VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider,
                        VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator,
                        CompilationUnit = inputCompilationUnit,
                    };

                    // Context action is now not default (tested above).
                    var outputCompilationUnit = await codeFileModificationContextAction(context);
                    return outputCompilationUnit;
                });
        }

        public static async Task InModificationContextByCodeFileProjectDirectoryRelativeFilePath(this ICodeFileOperator _,
            IProjectFileContext projectFileContext,
            string codeFileProjectDirectoryRelativeFilePath,
            Func<ICompilationUnitModificationContext, Task<CompilationUnitSyntax>> codeFileModificationContextAction = default)
        {
            var projectDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(projectFileContext.ProjectFilePath);

            var codeFilePath = Instances.PathOperator.GetFilePath(projectDirectoryPath, codeFileProjectDirectoryRelativeFilePath);

            await _.InModificationContextByCodeFilePath(
                projectFileContext,
                codeFilePath,
                codeFileModificationContextAction);
        }

        public static async Task InModificationContextByCodeFilePath(this ICodeFileOperator _,
            IProjectFileContext projectFileContext,
            string codeFilePath,
            Func<ICompilationUnitModificationContext, Task<CompilationUnitSyntax>> codeFileModificationContextAction = default)
        {
            // Ensure that files exist. Even if there's no action to perform, throw an exception.
            Instances.FileSystemOperator.VerifyFilesExist(
                projectFileContext.SolutionFilePath,
                projectFileContext.ProjectFilePath,
                codeFilePath);

            if (codeFileModificationContextAction == default)
            {
                return;
            }

            await Instances.CompilationUnitOperator.Modify(
                codeFilePath,
                async inputCompilationUnit =>
                {
                    var context = projectFileContext.GetCodeFileModificationContext(
                        codeFilePath,
                        inputCompilationUnit);

                    // Context action is now not default (tested above).
                    var outputCompilationUnit = await codeFileModificationContextAction(context);
                    return outputCompilationUnit;
                });
        }
    }
}
