using System;
using System.Threading.Tasks;

using R5T.D0082.T000;

using R5T.S0026.Library;


namespace System
{
    public static class IRemoteRepositoryContextProviderExtensions
    {
        public static async Task InAcquiredRemoteRepositoryContext(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryContextAction,
            Func<GitHubRepositorySpecification, Task<GitHubRepositorySpecification>> repositorySpecificationConfigurationAction)
        {
            // Create the repository if it does not exist.
            var remoteRepositoryExists = await remoteRepositoryContextProvider.RemoteRepositoryOperator.RepositoryExists(repositoryName);
            if(!remoteRepositoryExists)
            {
                var remoteRepositorySpecification = Instances.GitHubRepositorySpecificationGenerator.GetSafetyConeDefault(
                    repositoryName);

                remoteRepositorySpecification = await repositorySpecificationConfigurationAction(remoteRepositorySpecification);

                await remoteRepositoryContextProvider.RemoteRepositoryOperator.CreateRepositoryNonIdempotent(remoteRepositorySpecification);
            }

            // Now perform the remote repository action in context.
            await remoteRepositoryContextProvider.InRemoteRepositoryContext_WithoutExistenceCheck(
                repositoryName,
                remoteRepositoryContextAction);
        }

        /// <summary>
        /// No error if the repository if it does not exist. (The user might want to call a Create() method in the repository context.)
        /// </summary>
        public static async Task InRemoteRepositoryContext_WithoutExistenceCheck(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryContextAction)
        {
            var remoteRepositoryContext = remoteRepositoryContextProvider.GetRemoteRepositoryContext(repositoryName);

            await remoteRepositoryContextAction(remoteRepositoryContext);
        }

        /// <summary>
        /// Error if the repository if it does not exist. (The user wants to assume the repository exists.)
        /// </summary>
        public static async Task InRemoteRepositoryContext_WithExistenceCheck(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryContextAction)
        {
            var repositoryExists = await remoteRepositoryContextProvider.RemoteRepositoryOperator.RepositoryExists(repositoryName);
            if(!repositoryExists)
            {
                throw new Exception($"Remote repository '{repositoryName}' does not exist.");
            }

            await remoteRepositoryContextProvider.InRemoteRepositoryContext_WithoutExistenceCheck(
                repositoryName,
                remoteRepositoryContextAction);
        }

        /// <summary>
        /// Chooses <see cref="InRemoteRepositoryContext_WithExistenceCheck(IRemoteRepositoryContextProvider, string, Func{IRemoteRepositoryContext, Task})"/> as the default.
        /// </summary>
        public static Task InRemoteRepositoryContext(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryContextAction)
        {
            return remoteRepositoryContextProvider.InRemoteRepositoryContext_WithExistenceCheck(
                repositoryName,
                remoteRepositoryContextAction);
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IRemoteRepositoryContextProviderExtensions
    {
        public static RemoteRepositoryContext GetRemoteRepositoryContext(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName)
        {
            var remoteRepositoryContext = RemoteRepositoryContext.From(
                remoteRepositoryContextProvider.RemoteRepositoryOperator,
                repositoryName);

            return remoteRepositoryContext;
        }
    }
}