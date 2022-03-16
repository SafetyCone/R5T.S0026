using System;
using System.Threading.Tasks;

using R5T.D0084.D002;

using R5T.Lombardy;

using R5T.S0026.Library;


namespace System
{
    public static class IBasicLocalRepositoryContextProviderExtensions
    {
        ///// <summary>
        ///// No error if the local repository directory path does not exist or is not a Git repository.
        ///// </summary>
        //public static async Task InLocalRepositoryContext_WithoutExistenceCheck(this IBasicLocalRepositoryContextProvider localRepositoryContextProvider,
        //    string localRepositoryDirectoryPath,
        //    Func<IBasicLocalRepositoryContext, Task> localRepositoryContextAction)
        //{
        //    var localRepositoryContext = localRepositoryContextProvider.GetLocalRepositoryContext(localRepositoryDirectoryPath);

        //    await localRepositoryContextAction(localRepositoryContext);
        //}

        ///// <summary>
        ///// Error if the local repository directory path does not exist or is not a Git repository.
        ///// </summary>
        //public static async Task InLocalRepositoryContext_WithExistenceCheck(this IBasicLocalRepositoryContextProvider localRepositoryContextProvider,
        //    string localRepositoryDirectoryPath,
        //    Func<IBasicLocalRepositoryContext, Task> localRepositoryContextAction)
        //{
        //    var localDirectoryPathExists = Instances.FileSystemOperator.DirectoryExists(localRepositoryDirectoryPath);
        //    if(!localDirectoryPathExists)
        //    {
        //        throw new Exception($"Directory path does not exist:\n{localRepositoryDirectoryPath}");
        //    }

        //    var directoryIsRepository = await localRepositoryContextProvider.SourceControlOperator.IsRepository(localRepositoryDirectoryPath);
        //    if(!directoryIsRepository)
        //    {
        //        throw new Exception($"Directory was not a Git repository:\n{localRepositoryDirectoryPath}");
        //    }

        //    await localRepositoryContextProvider.InLocalRepositoryContext_WithoutExistenceCheck(
        //        localRepositoryDirectoryPath,
        //        localRepositoryContextAction);
        //}

        ///// <summary>
        ///// Chooses <see cref="InLocalRepositoryContext_WithExistenceCheck(IBasicLocalRepositoryContextProvider, string, Func{IBasicLocalRepositoryContext, Task})"/> as the default.
        ///// </summary>
        //public static Task InLocalRepositoryContext(this IBasicLocalRepositoryContextProvider localRepositoryContextProvider,
        //    string localRepositoryDirectoryPath,
        //    Func<IBasicLocalRepositoryContext, Task> localRepositoryContextAction)
        //{
        //    return localRepositoryContextProvider.InLocalRepositoryContext_WithExistenceCheck(
        //        localRepositoryDirectoryPath,
        //        localRepositoryContextAction);
        //}

        //public static async Task InLocalRepositoryContext(this IBasicLocalRepositoryContextProvider localRepositoryContextProvider,
        //    IRemoteRepositoryContext remoteRepositoryContext,
        //    IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider,
        //    Func<IBasicLocalRepositoryContext, Task> localRepositoryContextAction)
        //{
        //    var localRepositoryDirectoryPath = await localRepositoryContextProvider.GetLocalRepositoryDirectoryPath(
        //        remoteRepositoryContext,
        //        repositoriesDirectoryPathProvider);

        //    await localRepositoryContextProvider.InLocalRepositoryContext(
        //        localRepositoryDirectoryPath,
        //        localRepositoryContextAction);
        //}

        public static async Task<string> GetLocalRepositoryDirectoryPath(this IBasicLocalRepositoryContextProvider localRepositoryContextProvider,
            IRemoteRepositoryContext remoteRepositoryContext,
            IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider)
        {
            var repositoriesDirectoryPath = await repositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

            var repositoryDirectoryName = Instances.RepositoryNameOperator.GetRepositoryDirectoryName(remoteRepositoryContext.Name);

            var localRepositoryDirectoryPath = localRepositoryContextProvider.StringlyTypedPathOperator.GetDirectoryPath(
                repositoriesDirectoryPath,
                repositoryDirectoryName);

            return localRepositoryDirectoryPath;
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IBasicLocalRepositoryContextProviderExtensions
    {
        public static BasicLocalRepositoryContext GetLocalRepositoryContext(this IBasicLocalRepositoryContextProvider localRepositoryContextProvider,
            string localRepositoryDirectoryPath)
        {
            var output = BasicLocalRepositoryContext.From(
                localRepositoryContextProvider.SourceControlOperator,
                localRepositoryContextProvider.StringlyTypedPathOperator,
                localRepositoryDirectoryPath);

            return output;
        }
    }
}
