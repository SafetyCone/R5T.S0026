using System;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class IBasicSolutionContextProviderExtensions
    {
        public static string GetSolutionFilePath(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionName,
            string solutionDirectoryPath)
        {
            var solutionFileName = Instances.SolutionFileNameOperator.GetSolutionFileName(solutionName);

            var solutionFilePath = solutionContextProvider.StringlyTypedPathOperator.GetFilePath(
                solutionDirectoryPath,
                solutionFileName);

            return solutionFilePath;
        }

        public static string GetSolutionFilePath(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionName,
            ILocalRepositoryContext localRepositoryContext)
        {
            var solutionDirectoryPath = Instances.SolutionPathsOperator.GetSourceSolutionDirectoryPath(
                localRepositoryContext.DirectoryPath);

            var solutionFilePath = solutionContextProvider.GetSolutionFilePath(
                solutionName,
                solutionDirectoryPath);

            return solutionFilePath;
        }

        public static async Task InAcquiredSolutionContext(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<IBasicSolutionContext, Task> solutionContextAction)
        {
            var solutionFileExists = Instances.FileSystemOperator.FileExists(solutionFilePath);
            if(!solutionFileExists)
            {
                await solutionContextProvider.VisualStudioSolutionFileOperator.Create(
                    solutionFilePath);
            }

            await solutionContextProvider.InSolutionContext_WithoutExistenceCheck(
                solutionFilePath,
                solutionContextAction);
        }

        public static async Task InAcquiredSolutionContext(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionName,
            string solutionDirectoryPath,
            Func<IBasicSolutionContext, Task> solutionContextAction)
        {
            var solutionFilePath = solutionContextProvider.GetSolutionFilePath(
                solutionName,
                solutionDirectoryPath);

            await solutionContextProvider.InAcquiredSolutionContext(
                solutionFilePath,
                solutionContextAction);
        }

        public static async Task InAcquiredSolutionContext(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionName,
            ILocalRepositoryContext localRepositoryContext,
            Func<IBasicSolutionContext, Task> solutionContextAction)
        {
            var solutionDirectoryPath = Instances.SolutionPathsOperator.GetSourceSolutionDirectoryPath(
                localRepositoryContext.DirectoryPath);

            await solutionContextProvider.InAcquiredSolutionContext(
                solutionName,
                solutionDirectoryPath,
                solutionContextAction);
        }

        public static async Task InSolutionContext_WithoutExistenceCheck(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<IBasicSolutionContext, Task> solutionContextAction)
        {
            var solutionContext = solutionContextProvider.GetSolutionContext(
                solutionFilePath);

            await solutionContextAction(solutionContext);
        }

        public static async Task InSolutionContext_WithoutExistenceCheck(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionName,
            ILocalRepositoryContext localRepositoryContext,
            Func<IBasicSolutionContext, Task> solutionContextAction)
        {
            var solutionFilePath = solutionContextProvider.GetSolutionFilePath(
                solutionName,
                localRepositoryContext);

            var solutionContext = solutionContextProvider.GetSolutionContext(
                solutionFilePath);

            await solutionContextAction(solutionContext);
        }

        public static async Task InSolutionContext_WithExistenceCheck(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<IBasicSolutionContext, Task> solutionContextAction)
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
        /// Chooses <see cref="InSolutionContext_WithExistenceCheck(IBasicSolutionContextProvider, string, Func{IBasicSolutionContext, Task})"/> as the default.
        /// </summary>
        public static Task InSolutionContext(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionFilePath,
            Func<IBasicSolutionContext, Task> solutionContextAction)
        {
            return solutionContextProvider.InSolutionContext_WithExistenceCheck(
                solutionFilePath,
                solutionContextAction);
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IBasicSolutionContextProviderExtensions
    {
        public static BasicSolutionContext GetSolutionContext(this IBasicSolutionContextProvider solutionContextProvider,
            string solutionFilePath)
        {
            var solutionDirectoryPath = solutionContextProvider.StringlyTypedPathOperator.GetDirectoryPathForFilePath(
                solutionFilePath);

            var output = new BasicSolutionContext
            {
                DirectoryPath = solutionDirectoryPath,
                FilePath = solutionFilePath,
                StringlyTypedPathOperator = solutionContextProvider.StringlyTypedPathOperator,
                VisualStudioProjectFileReferencesProvider = solutionContextProvider.VisualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = solutionContextProvider.VisualStudioSolutionFileOperator,
            };

            return output;
        }
    }
}