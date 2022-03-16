using System;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class ILocalRepositoryContextExtensions
    {
        public static async Task CheckIn(this ILocalRepositoryContext localRepositoryContext,
            string commitMessage)
        {
            await localRepositoryContext.SourceControlOperator.CheckIn(
                localRepositoryContext.DirectoryPath,
                commitMessage);
        }

        public static async Task Clone(this ILocalRepositoryContext localRepositoryContext,
            IRemoteRepositoryContext remoteRepositoryContext)
        {
            var remoteRepositoryUrl = await remoteRepositoryContext.GetUrl();

            await localRepositoryContext.Clone(remoteRepositoryUrl);
        }

        /// <summary>
        /// Quality-of-life for <see cref="CloneOnlyIfNotExists(ILocalRepositoryContext, string)"/>
        /// </summary>
        public static Task Clone(this ILocalRepositoryContext localRepositoryContext,
            string remoteRepositoryUrl)
        {
            return localRepositoryContext.CloneOnlyIfNotExists(remoteRepositoryUrl);
        }

        public static async Task CloneOnlyIfNotExists(this ILocalRepositoryContext localRepositoryContext,
            string remoteRepositoryUrl)
        {
            var directoryExists = await localRepositoryContext.DirectoryExists();
            if (directoryExists)
            {
                // If the directory does exist, check whether it is a repository already.
                var isRepository = await localRepositoryContext.DirectoryIsRepository();
                if (isRepository)
                {
                    return;
                }
                else
                {
                    // If the directory exists, but it is not a repository, check that the directory is empty.
                    // If not empty, throw, to avoid cloning into an existing directory.
                    var isEmpty = Instances.FileSystemOperator.IsDirectoryEmpty(localRepositoryContext.DirectoryPath);
                    if (!isEmpty)
                    {
                        // If it's not empty throw!
                        throw new Exception($"Local directory for cloning remote repository was not empty:\n{localRepositoryContext.DirectoryPath}");
                    }
                }
            }

            // If the directory does not exist, clone it.
            await localRepositoryContext.SourceControlOperator.Clone(
                remoteRepositoryUrl,
                localRepositoryContext.DirectoryPath);
        }

        public static async Task CopyGitIgnoreTemplateFile(this ILocalRepositoryContext localRepositoryContext)
        {
            var gitIgnoreTemplateFilePath = await localRepositoryContext.GitIgnoreTemplateFilePathProvider.GetGitIgnoreTemplateFilePath();

            var gitIgnoreFilePath = localRepositoryContext.GetGitIgnoreFilePath();

            Instances.FileSystemOperator.CopyFile(
                gitIgnoreTemplateFilePath,
                gitIgnoreFilePath);
        }

        public static Task DeleteDirectoryOnlyIfExists(this ILocalRepositoryContext localRepositoryContext)
        {
            Instances.FileSystemOperator.DeleteDirectoryOkIfNotExists(localRepositoryContext.DirectoryPath);

            return Task.CompletedTask;
        }

        public static Task<bool> DirectoryExists(this ILocalRepositoryContext localRepositoryContext)
        {
            // Does the directory exist?
            var directoryExists = Instances.FileSystemOperator.DirectoryExists(
                localRepositoryContext.DirectoryPath);

            return Task.FromResult(directoryExists);
        }

        public static async Task<bool> DirectoryIsRepository(this ILocalRepositoryContext localRepositoryContext)
        {
            var isRepository = await localRepositoryContext.SourceControlOperator.IsRepository(
                localRepositoryContext.DirectoryPath);

            return isRepository;
        }

        public static async Task<bool> Exists(this ILocalRepositoryContext localRepositoryContext)
        {
            var directoryExists = await localRepositoryContext.DirectoryExists();
            if(!directoryExists)
            {
                return false;
            }

            var isRepository = await localRepositoryContext.DirectoryIsRepository();

            var output = directoryExists && isRepository;
            return output;
        }

        public static string GetGitIgnoreFilePath(this ILocalRepositoryContext localRepositoryContext)
        {
            var gitIgnoreFilePath = localRepositoryContext.StringlyTypedPathOperator.GetFilePath(
                localRepositoryContext.DirectoryPath,
                Instances.FileName.GitIgnore());

            return gitIgnoreFilePath;
        }
    }
}
