using System;
using System.IO;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class IDirectoryContextExtensions
    {
        public static void DeleteDirectory(this IDirectoryContext directoryContext)
        {
            Instances.FileSystemOperator.DeleteDirectory(
                directoryContext.DirectoryPath);
        }

        public static void DeleteChildFileOnlyIfExists(this IDirectoryContext directoryContext,
            string fileName)
        {
            var filePath = directoryContext.GetChildFilePath(fileName);

            Instances.FileSystemOperator.DeleteFileOkIfNotExists(filePath);
        }

        public static string GetChildDirectoryPath(this IDirectoryContext directoryContext,
            string directoryName)
        {
            var directoryPath = directoryContext.StringlyTypedPathOperator.GetDirectoryPath(
                directoryContext.DirectoryPath,
                directoryName);

            return directoryPath;
        }

        public static string GetChildFilePath(this IDirectoryContext directoryContext,
            string fileName)
        {
            var filePath = directoryContext.StringlyTypedPathOperator.GetFilePath(
                directoryContext.DirectoryPath,
                fileName);

            return filePath;
        }

        public static async Task InNewChildTextFileContext(this IDirectoryContext directoryContext,
            string textFileName,
            Func<ITextWriterContext, Task> textWriterContextAction)
        {
            var textFilePath = directoryContext.GetChildFilePath(textFileName);
            
            using var textWriter = TextWriterHelper.New(textFilePath);

            var textWriterContext = new TextWriterContext
            {
                TextWriter = textWriter,
            };

            await textWriterContextAction(textWriterContext);
        }
    }
}
