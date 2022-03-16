using System;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class ILocalRepositoryContextProviderExtensions
    {
        public static async Task<bool> Exists(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string localRepositoryDirectoryPath)
        {
            var directoryExists = Instances.FileSystemOperator.DirectoryExists(localRepositoryDirectoryPath);
            var isRepository = await localRepositoryContextProvider.SourceControlOperator.IsRepository(localRepositoryDirectoryPath);

            var output = directoryExists && isRepository;
            return output;
        }

        public static async Task InClonedLocalRepositoryContext(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string localRepositoryDirectoryPath,
            IRemoteRepositoryContext remoteRepositoryContext,
            Func<ILocalRepositoryContext, Task> localRepositoryContextAction)
        {
            var directoryExists = Instances.FileSystemOperator.DirectoryExists(localRepositoryDirectoryPath);
            if (directoryExists)
            {
                // If the directory does exist, check whether it is a repository already.
                var isRepository = await localRepositoryContextProvider.SourceControlOperator.IsRepository(localRepositoryDirectoryPath);
                if (isRepository)
                {
                    // If it is a repository, check that the URL is the same.
                    var localRepositoryRemoteUrl = await localRepositoryContextProvider.SourceControlOperator.GetRemoteUrl(localRepositoryDirectoryPath);
                    var remoteRepositoryUrl = await remoteRepositoryContext.GetUrl();

                    var urlsAreTheSame = localRepositoryRemoteUrl == remoteRepositoryUrl;
                    if (!urlsAreTheSame)
                    {
                        throw new Exception($"Local repository URL did not match specified remote repository URL. Local repository:\n{localRepositoryDirectoryPath}\n\nUrls:\n{localRepositoryRemoteUrl} (Local)\n{remoteRepositoryUrl} (Remote)");
                    }
                }
                else
                {
                    // If the directory exists, but it is not a repository, check that the directory is empty.
                    var isEmpty = Instances.FileSystemOperator.IsDirectoryEmpty(localRepositoryDirectoryPath);
                    if (!isEmpty)
                    {
                        // If it's not empty throw!
                        throw new Exception($"Local directory for cloning remote repository was not empty:\n{localRepositoryDirectoryPath}");
                    }
                }
            }
            else
            {
                // If the directory does not exist, clone it.
                await remoteRepositoryContext.CloneToLocalDirectoryPath(
                    localRepositoryDirectoryPath,
                    localRepositoryContextProvider.SourceControlOperator);
            }

            await localRepositoryContextProvider.InLocalRepositoryContext(
                localRepositoryDirectoryPath,
                localRepositoryContextAction);
        }

        public static async Task InClonedLocalRepositoryContext(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            IRemoteRepositoryContext remoteRepositoryContext,
            Func<ILocalRepositoryContext, Task> localRepositoryContextAction)
        {
            var localRepositoryDirectoryPath = await localRepositoryContextProvider.GetLocalRepositoryDirectoryPath(
                remoteRepositoryContext,
                localRepositoryContextProvider.RepositoriesDirectoryPathProvider);

            await localRepositoryContextProvider.InClonedLocalRepositoryContext(
                localRepositoryDirectoryPath,
                remoteRepositoryContext,
                localRepositoryContextAction);
        }

        public static async Task InLocalRepositoryContextByDirectoryPath_WithoutExistenceCheck(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string localRepositoryDirectoryPath,
            Func<ILocalRepositoryContext, Task> localRepositoryAction)
        {
            var localRepositoryContext = localRepositoryContextProvider.GetLocalRepositoryContext(localRepositoryDirectoryPath);

            await localRepositoryAction(localRepositoryContext);
        }

        public static async Task InLocalRepositoryContextByDirectoryPath_WithExistenceCheck(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string localRepositoryDirectoryPath,
            Func<ILocalRepositoryContext, Task> localRepositoryAction)
        {
            var repositoryExists = await localRepositoryContextProvider.Exists(localRepositoryDirectoryPath);
            if(!repositoryExists)
            {
                throw new Exception($"Local repository does not exist:\n{localRepositoryDirectoryPath}");
            }

            await localRepositoryContextProvider.InLocalRepositoryContextByDirectoryPath_WithoutExistenceCheck(
                localRepositoryDirectoryPath,
                localRepositoryAction);
        }

        /// <summary>
        /// Chooses <see cref="InLocalRepositoryContextByDirectoryPath_WithExistenceCheck(ILocalRepositoryContextProvider, string, Func{ILocalRepositoryContext, Task})"/> as the default.
        /// </summary>
        public static Task InLocalRepositoryContextByDirectoryPath(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string localRepositoryDirectoryPath,
            Func<ILocalRepositoryContext, Task> localRepositoryAction)
        {
            return localRepositoryContextProvider.InLocalRepositoryContextByDirectoryPath_WithExistenceCheck(
                localRepositoryDirectoryPath,
                localRepositoryAction);
        }

        public static async Task InLocalRepositoryContext_WithoutExistenceCheck(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName,
            Func<ILocalRepositoryContext, Task> localRepositoryAction)
        {
            var repositoryDirectoryPath = await localRepositoryContextProvider.GetLocalRepositoryDirectoryPath(repositoryName);

            await localRepositoryContextProvider.InLocalRepositoryContextByDirectoryPath_WithoutExistenceCheck(
                repositoryDirectoryPath,
                localRepositoryAction);
        }

        public static async Task InLocalRepositoryContext_WithExistenceCheck(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName,
            Func<ILocalRepositoryContext, Task> localRepositoryAction)
        {
            var repositoryDirectoryPath = await localRepositoryContextProvider.GetLocalRepositoryDirectoryPath(repositoryName);

            await localRepositoryContextProvider.InLocalRepositoryContextByDirectoryPath_WithExistenceCheck(
                repositoryDirectoryPath,
                localRepositoryAction);
        }

        /// <summary>
        /// Chooses <see cref="InLocalRepositoryContext_WithExistenceCheck(ILocalRepositoryContextProvider, string, Func{ILocalRepositoryContext, Task})"/> as the default.
        /// </summary>
        public static Task InLocalRepositoryContext(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName,
            Func<ILocalRepositoryContext, Task> localRepositoryAction)
        {
            return localRepositoryContextProvider.InLocalRepositoryContext_WithExistenceCheck(
                repositoryName,
                localRepositoryAction);
        }

        public static async Task<string> GetLocalRepositoryDirectoryPath(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName)
        {
            var repositoriesDirectoryPath = await localRepositoryContextProvider.RepositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

            var repositoryDirectoryName = Instances.RepositoryNameOperator.GetRepositoryDirectoryName(repositoryName);

            var repositoryDirectoryPath = localRepositoryContextProvider.StringlyTypedPathOperator.GetDirectoryPath(
                repositoriesDirectoryPath,
                repositoryDirectoryName);

            return repositoryDirectoryPath;
        }
    }
}


namespace R5T.S0026.Library
{
    public static class ILocalRepositoryContextProviderExtensions
    {
        public static LocalRepositoryContext GetLocalRepositoryContext(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryDirectoryPath)
        {
            var output = new LocalRepositoryContext
            {
                DirectoryPath = repositoryDirectoryPath,
                GitIgnoreTemplateFilePathProvider = localRepositoryContextProvider.GitIgnoreTemplateFilePathProvider,
                RepositoriesDirectoryPathProvider = localRepositoryContextProvider.RepositoriesDirectoryPathProvider,
                SourceControlOperator = localRepositoryContextProvider.SourceControlOperator,
                StringlyTypedPathOperator = localRepositoryContextProvider.StringlyTypedPathOperator,
            };

            return output;
        }
    }
}
