using System;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class IDirectoryContextProviderExtensions
    {
        public static async Task InAcquiredChildDirectoryContext(this IDirectoryContextProvider directoryContextProvider,
            string childDirectoryPath,
            Func<IDirectoryContext, Task> childDirectoryContextAction)
        {
            var childDirectoryExists = Instances.FileSystemOperator.DirectoryExists(childDirectoryPath);
            if (childDirectoryExists)
            {
                Instances.FileSystemOperator.CreateDirectory(childDirectoryPath);
            }

            await directoryContextProvider.InChildDirectoryContext_WithoutExistenceCheck(
                childDirectoryPath,
                childDirectoryContextAction);
        }

        public static async Task InAcquiredChildDirectoryContext(this IDirectoryContextProvider directoryContextProvider,
            IDirectoryContext directoryContext,
            string childDirectoryName,
            Func<IDirectoryContext, Task> childDirectoryContextAction)
        {
            var childDirectoryPath = directoryContext.GetChildDirectoryPath(childDirectoryName);

            await directoryContextProvider.InAcquiredChildDirectoryContext(
                childDirectoryPath,
                childDirectoryContextAction);
        }

        public static async Task InChildDirectoryContext_WithoutExistenceCheck(this IDirectoryContextProvider directoryContextProvider,
            string childDirectoryPath,
            Func<IDirectoryContext, Task> childDirectoryContextAction)
        {
            var childDirectoryContext = directoryContextProvider.GetDirectoryContext(childDirectoryPath);

            await childDirectoryContextAction(childDirectoryContext);
        }

        public static async Task InChildDirectoryContext_WithExistenceCheck(this IDirectoryContextProvider directoryContextProvider,
            string childDirectoryPath,
            Func<IDirectoryContext, Task> childDirectoryContextAction)
        {
            var childDirectoryExists = Instances.FileSystemOperator.DirectoryExists(childDirectoryPath);
            if (childDirectoryExists)
            {
                throw new Exception($"Directory does not exist:\n{childDirectoryPath}");
            }

            await directoryContextProvider.InChildDirectoryContext_WithoutExistenceCheck(
                childDirectoryPath,
                childDirectoryContextAction);
        }

        /// <summary>
        /// Chooses <see cref="InChildDirectoryContext_WithoutExistenceCheck(IDirectoryContextProvider, string, Func{IDirectoryContext, Task})"/> as the default.
        /// Note: this is *without* as the default.
        /// </summary>
        public static Task InChildDirectoryContext(this IDirectoryContextProvider directoryContextProvider,
            string childDirectoryPath,
            Func<IDirectoryContext, Task> childDirectoryContextAction)
        {
            return directoryContextProvider.InChildDirectoryContext_WithoutExistenceCheck(
                childDirectoryPath,
                childDirectoryContextAction);
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IDirectoryContextProviderExtensions
    {
        public static DirectoryContext GetDirectoryContext(this IDirectoryContextProvider directoryContextProvider,
            string directoryPath)
        {
            var output = new DirectoryContext
            {
                DirectoryPath = directoryPath,
                StringlyTypedPathOperator = directoryContextProvider.StringlyTypedPathOperator,
            };

            return output;
        }
    }
}
