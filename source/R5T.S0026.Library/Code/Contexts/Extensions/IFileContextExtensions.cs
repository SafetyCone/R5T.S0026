using System;


namespace R5T.S0026.Library
{
    public static class IFileContextExtensions
    {
        public static bool FileExists(this IFileContext fileContext)
        {
            var output = Instances.FileSystemOperator.FileExists(
                fileContext.FilePath);

            return output;
        }
    }
}
