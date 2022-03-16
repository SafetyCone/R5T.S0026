using System;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class IProjectContextProviderExtensions
    {
        public static string GetProjectDirectoryPath(this IProjectContextProvider projectContextProvider,
            string projectName,
            IBasicSolutionContext solutionContext)
        {
            var projectDirectoryName = Instances.ProjectPathsOperator.GetProjectDirectoryName(projectName);

            var projectDirectoryPath = projectContextProvider.StringlyTypedPathOperator.GetDirectoryPath(
                solutionContext.DirectoryPath,
                projectDirectoryName);

            return projectDirectoryPath;
        }

        public static string GetProjectFilePath(this IProjectContextProvider projectContextProvider,
            string projectName,
            IBasicSolutionContext solutionContext)
        {
            var projectFileName = Instances.ProjectPathsOperator.GetProjectFileName(projectName);

            var projectDirectoryPath = projectContextProvider.GetProjectDirectoryPath(
                projectName,
                solutionContext);

            var projectFilePath = projectContextProvider.StringlyTypedPathOperator.GetFilePath(
                projectDirectoryPath,
                projectFileName);

            return projectFilePath;
        }

        public static async Task InAcquiredProjectContext_ByProjectFilePath(this IProjectContextProvider projectContextProvider,
            string projectFilePath,
            Func<IProjectContext, Task> projectContextAction,
            Func<IProjectContext, Task> initialProjectContextAction)
        {
            var projectContext = projectContextProvider.GetProjectContext(
                projectFilePath);

            var projectFileExists = Instances.FileSystemOperator.FileExists(projectFilePath);
            if(!projectFileExists)
            {
                // Create it, and add it to the solution.
                await initialProjectContextAction(projectContext);
            }

            await projectContextAction(projectContext);
        }

        public static async Task InAcquiredProjectContext(this IProjectContextProvider projectContextProvider,
            string projectName,
            string projectDirectoryPath,
            Func<IProjectContext, Task> projectContextAction,
            Func<IProjectContext, Task> initialProjectContextAction)
        {
            var projectFileName = Instances.ProjectPathsOperator.GetProjectFileName(projectName);

            var projectFilePath = projectContextProvider.StringlyTypedPathOperator.GetFilePath(
                projectDirectoryPath,
                projectFileName);

            await projectContextProvider.InAcquiredProjectContext_ByProjectFilePath(
                projectFilePath,
                projectContextAction,
                initialProjectContextAction);
        }

        public static async Task InAcquiredProjectContext(this IProjectContextProvider projectContextProvider,
            string projectName,
            IBasicSolutionContext solutionContext,
            Func<IProjectContext, Task> projectContextAction,
            Func<IProjectContext, Task> initialProjectContextAction)
        {
            var projectDirectoryName = Instances.ProjectPathsOperator.GetProjectDirectoryName(projectName);

            var projectDirectoryPath = projectContextProvider.StringlyTypedPathOperator.GetDirectoryPath(
                solutionContext.DirectoryPath,
                projectDirectoryName);

            await projectContextProvider.InAcquiredProjectContext(
                projectName,
                projectDirectoryPath,
                projectContextAction,
                initialProjectContextAction);
        }

        public static async Task InProjectContext_WithoutExistenceCheck(this IProjectContextProvider projectContextProvider,
            string projectFilePath,
            Func<IProjectContext, Task> projectContextAction)
        {
            var projectContext = projectContextProvider.GetProjectContext(
                projectFilePath);

            await projectContextAction(projectContext);
        }

        public static async Task InProjectContext_WithoutExistenceCheck(this IProjectContextProvider projectContextProvider,
            string projectName,
            IBasicSolutionContext solutionContext,
            Func<IProjectContext, Task> projectContextAction)
        {
            var projectFilePath = projectContextProvider.GetProjectFilePath(
                projectName,
                solutionContext);

            await projectContextProvider.InProjectContext_WithoutExistenceCheck(
                projectFilePath,
                projectContextAction);
        }

        public static async Task InProjectContext_WithExistenceCheck(this IProjectContextProvider projectContextProvider,
            string projectFilePath,
            Func<IProjectContext, Task> projectContextAction)
        {
            var projectFileExists = Instances.FileSystemOperator.FileExists(projectFilePath);
            if(!projectFileExists)
            {
                throw new Exception($"Project file not found:\n{projectFilePath}");
            }

            await projectContextProvider.InProjectContext_WithoutExistenceCheck(
                projectFilePath,
                projectContextAction);
        }

        /// <summary>
        /// Chooses <see cref="InProjectContext_WithExistenceCheck(IProjectContextProvider, string, Func{IProjectContext, Task})"/> as the default.
        /// </summary>
        public static Task InProjectContext(this IProjectContextProvider projectContextProvider,
            string projectFilePath,
            Func<IProjectContext, Task> projectContextAction)
        {
            return projectContextProvider.InProjectContext_WithExistenceCheck(
                projectFilePath,
                projectContextAction);
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IProjectContextProviderExtensions
    {
        public static ProjectContext GetProjectContext(this IProjectContextProvider projectContextProvider,
            string projectFilePath)
        {
            var projectDirectoryPath = projectContextProvider.StringlyTypedPathOperator.GetDirectoryPathForFilePath(
                projectFilePath);

            var output = new ProjectContext
            {
                DirectoryPath = projectDirectoryPath,
                FilePath = projectFilePath,
                StringlyTypedPathOperator = projectContextProvider.StringlyTypedPathOperator,
                VisualStudioProjectFileOperator = projectContextProvider.VisualStudioProjectFileOperator,
            };

            return output;
        }
    }
}