using System;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class ISolutionContextProviderExtensions
    {
        public static async Task InAcquiredSolutionContext(this ISolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<ISolutionContext, Task> solutionContextAction)
        {
            var solutionFileExists = Instances.FileSystemOperator.FileExists(solutionFilePath);
            if (!solutionFileExists)
            {
                await solutionContextProvider.VisualStudioSolutionFileOperator.Create(
                    solutionFilePath);
            }

            await solutionContextProvider.InSolutionContext_WithoutExistenceCheck(
                solutionFilePath,
                solutionContextAction);
        }

        public static async Task InAcquiredSolutionContext(this ISolutionContextProvider solutionContextProvider,
            string solutionName,
            string solutionDirectoryPath,
            Func<ISolutionContext, Task> solutionContextAction)
        {
            var solutionFilePath = solutionContextProvider.GetSolutionFilePath(
                solutionName,
                solutionDirectoryPath);

            await solutionContextProvider.InAcquiredSolutionContext(
                solutionFilePath,
                solutionContextAction);
        }


        public static async Task InAcquiredSolutionContext(this ISolutionContextProvider solutionContextProvider,
            string solutionName,
            ILocalRepositoryContext localRepositoryContext,
            Func<ISolutionContext, Task> solutionContextAction)
        {
            var solutionDirectoryPath = Instances.SolutionPathsOperator.GetSourceSolutionDirectoryPath(
                localRepositoryContext.DirectoryPath);

            await solutionContextProvider.InAcquiredSolutionContext(
                solutionName,
                solutionDirectoryPath,
                solutionContextAction);
        }

        public static async Task InSolutionContext_WithoutExistenceCheck(this ISolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<ISolutionContext, Task> solutionContextAction)
        {
            var solutionContext = solutionContextProvider.GetSolutionContext(
                solutionFilePath);

            await solutionContextAction(solutionContext);
        }

        public static async Task InSolutionContext_WithoutExistenceCheck(this ISolutionContextProvider solutionContextProvider,
            string solutionName,
            ILocalRepositoryContext localRepositoryContext,
            Func<ISolutionContext, Task> solutionContextAction)
        {
            var solutionFilePath = solutionContextProvider.GetSolutionFilePath(
                solutionName,
                localRepositoryContext);

            var solutionContext = solutionContextProvider.GetSolutionContext(
                solutionFilePath);

            await solutionContextAction(solutionContext);
        }

        public static async Task InSolutionContext_WithExistenceCheck(this ISolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<ISolutionContext, Task> solutionContextAction)
        {
            var solutionFileExists = Instances.FileSystemOperator.FileExists(solutionFilePath);
            if (!solutionFileExists)
            {
                throw new Exception($"Solution file not found:\n{solutionFilePath}");
            }

            await solutionContextProvider.InSolutionContext_WithoutExistenceCheck(
                solutionFilePath,
                solutionContextAction);
        }

        /// <summary>
        /// Chooses <see cref="InSolutionContext_WithExistenceCheck(ISolutionContextProvider, string, Func{ISolutionContext, Task})"/> as the default.
        /// </summary>
        public static Task InSolutionContext(this ISolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<ISolutionContext, Task> solutionContextAction)
        {
            return solutionContextProvider.InSolutionContext_WithExistenceCheck(
                solutionFilePath,
                solutionContextAction);
        }
    }
}


namespace R5T.S0026.Library
{
    public static class ISolutionContextProviderExtensions
    {
        public static SolutionContext GetSolutionContext(this ISolutionContextProvider solutionContextProvider,
            string solutionFilePath)
        {
            var solutionDirectoryPath = solutionContextProvider.StringlyTypedPathOperator.GetDirectoryPathForFilePath(
                solutionFilePath);

            var output = new SolutionContext
            {
                DirectoryPath = solutionDirectoryPath,
                FilePath = solutionFilePath,
                ProjectRepository = solutionContextProvider.ProjectRepository,
                StringlyTypedPathOperator = solutionContextProvider.StringlyTypedPathOperator,
                VisualStudioProjectFileReferencesProvider = solutionContextProvider.VisualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = solutionContextProvider.VisualStudioSolutionFileOperator,
            };

            return output;
        }
    }
}