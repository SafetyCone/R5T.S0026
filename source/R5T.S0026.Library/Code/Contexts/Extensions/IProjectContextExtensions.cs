using System;
using System.Threading.Tasks;

using R5T.D0079;

using R5T.S0026.Library;


namespace System
{
    public static class IProjectContextExtensions
    {
        public static async Task Create(this IProjectContext projectContext,
            VisualStudioProjectType projectType)
        {
            var projectName = projectContext.GetProjectName();

            await projectContext.VisualStudioProjectFileOperator.Create(
                projectName,
                projectContext.DirectoryPath,
                projectType);
        }

        public static string GetDefaultNamespaceName(this IProjectContext projectContext)
        {
            var projectName = projectContext.GetProjectName();

            var defaultNamespaceName = Instances.ProjectNameOperator.GetDefaultNamespaceNameFromProjectName(projectName);
            return defaultNamespaceName;
        }

        public static string GetProjectName(this IProjectContext projectContext)
        {
            var projectName = Instances.ProjectPathsOperator.GetProjectName(
                projectContext.FilePath);

            return projectName;
        }

        public static Task InProjectDirectoryContext(this IProjectContext projectContext,
            Func<IDirectoryContext, Task> directoryContextAction)
        {
            return directoryContextAction(projectContext);
        }

        public static void InProjectDirectoryContextSynchronous(this IProjectContext projectContext,
            Action<IDirectoryContext> directoryContextAction)
        {
            directoryContextAction(projectContext);
        }
    }
}
