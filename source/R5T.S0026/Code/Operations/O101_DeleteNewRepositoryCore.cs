using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
    public class O101_DeleteNewRepositoryCore : IOperation
    {
        private ILocalRepositoryContextProvider LocalRepositoryContextProvider { get; }
        private IRemoteRepositoryContextProvider RemoteRepositoryContextProvider { get; }


        public O101_DeleteNewRepositoryCore(
            ILocalRepositoryContextProvider localRepositoryContextProvider,
            IRemoteRepositoryContextProvider remoteRepositoryContextProvider)
        {
            this.LocalRepositoryContextProvider = localRepositoryContextProvider;
            this.RemoteRepositoryContextProvider = remoteRepositoryContextProvider;
        }

        public async Task Run(
            string repositoryName)
        {
            // Delete the local repository directory.
            await this.LocalRepositoryContextProvider.InLocalRepositoryContext_WithoutExistenceCheck(
                repositoryName,
                async localRepositoryContext =>
                {
                    await localRepositoryContext.DeleteDirectoryOnlyIfExists();
                });

            // Delete the remote repository.
            await this.RemoteRepositoryContextProvider.InRemoteRepositoryContext_WithoutExistenceCheck(
                repositoryName,
                async remoteRepositoryContext =>
                {
                    await remoteRepositoryContext.RemoteRepositoryOperator.DeleteRepository_SafetyCone(
                        repositoryName);
                });
        }
    }
}
