using System;
using System.Threading.Tasks;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0113;


namespace R5T.S0026.Library
{
    public static class IProjectOperatorExtensions
    {
        public static async Task InModificationContext(this IProjectOperator _,
            string repositoryDirectoryPath,
            string solutionName,
            string projectName,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<IProjectFileModificationContext, Task> projectFileModificationContextAction = default)
        {
            var solutionFilePath = Instances.SolutionPathsOperator.GetSourceSolutionFilePath(repositoryDirectoryPath, solutionName);

            var projectFilePath = Instances.ProjectPathsOperator.GetProjectFilePathFromSolutionFilePath(solutionFilePath, projectName);

            await _.InModificationContext(
                solutionFilePath,
                projectFilePath,
                visualStudioProjectFileOperator,
                visualStudioProjectFileReferencesProvider,
                visualStudioSolutionFileOperator,
                projectFileModificationContextAction);
        }

        public static async Task InModificationContext(this IProjectOperator _,
            string solutionFilePath,
            string projectFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<IProjectFileModificationContext, Task> projectFileModificationContextAction = default)
        {
            // Ensure that files exist. Even if there's no action to perform, throw an exception.
            Instances.FileSystemOperator.VerifyFilesExist(
                solutionFilePath,
                projectFilePath);

            if (projectFileModificationContextAction == default)
            {
                return;
            }

            var context = new ProjectFileModificationContext
            {
                ProjectFilePath = projectFilePath,
                SolutionFilePath = solutionFilePath,
                VisualStudioProjectFileOperator = visualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator,
            };

            // Context action is now not default (tested above).
            await projectFileModificationContextAction(context);
        }
    }
}
