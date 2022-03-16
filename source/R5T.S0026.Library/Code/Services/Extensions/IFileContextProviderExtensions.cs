using System;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class IFileContextProviderExtensions
    {
        public static async Task InFileContext_WithoutExistenceCheck(this IFileContextProvider fileContextProvider,
            string filePath,
            Func<IFileContext, Task> fileContextAction)
        {
            var fileContext = fileContextProvider.GetFileContext(filePath);

            await fileContextAction(fileContext);
        }

        public static async Task InFileContext_WithExistenceCheck(this IFileContextProvider fileContextProvider,
            string filePath,
            Func<IFileContext, Task> fileContextAction)
        {
            var fileExists = Instances.FileSystemOperator.FileExists(filePath);
            if(!fileExists)
            {
                throw new Exception($"File not found:\n{filePath}");
            }

            await fileContextProvider.InFileContext_WithoutExistenceCheck(
                filePath,
                fileContextAction);
        }

        /// <summary>
        /// Chooses <see cref="InFileContext_WithoutExistenceCheck(IFileContextProvider, string, Func{IFileContext, Task})"/> as the default.
        /// Note: this is *without* existence check that is the default.
        /// </summary>
        public static Task InFileContext(this IFileContextProvider fileContextProvider,
            string filePath,
            Func<IFileContext, Task> fileContextAction)
        {
            return fileContextProvider.InFileContext_WithoutExistenceCheck(
                filePath,
                fileContextAction);   
        }

        public static async Task InChildFileContext(this IFileContextProvider fileContextProvider,
            IDirectoryContext directoryContext,
            string fileName,
            Func<IFileContext, Task> fileContextAction)
        {
            var childFilePath = fileContextProvider.StringlyTypedPathOperator.GetFilePath(
                directoryContext.DirectoryPath,
                fileName);

            await fileContextProvider.InFileContext(
                childFilePath,
                fileContextAction);
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IFileContextProviderExtensions
    {
        public static FileContext GetFileContext(this IFileContextProvider fileContextProvider,
            string filePath)
        {
            var output = new FileContext
            {
                FilePath = filePath,
                StringlyTypedPathOperator = fileContextProvider.StringlyTypedPathOperator,
            };

            return output;
        }
    }
}
