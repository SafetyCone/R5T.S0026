using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0104;

using R5T.S0026.Library;


namespace R5T.S0026
{
    /// <summary>
    /// Simply creates a new repository. Does *not* do any initial repository setup beyond the repository defaults:
    /// * License file.
    /// * README file.
    /// </summary>
    [OperationMarker]
    public class O100A_CreateNewRepositoryOnly : IOperation
    {
        private ILocalRepositoryContextProvider LocalRepositoryContextProvider { get; }
        private IRemoteRepositoryContextProvider RemoteRepositoryContextProvider { get; }


        public O100A_CreateNewRepositoryOnly(
            ILocalRepositoryContextProvider localRepositoryContextProvider,
            IRemoteRepositoryContextProvider remoteRepositoryContextProvider)
        {
            this.LocalRepositoryContextProvider = localRepositoryContextProvider;
            this.RemoteRepositoryContextProvider = remoteRepositoryContextProvider;
        }

        public async Task Run(
             RepositorySpecification repositorySpecification)
        {
            await this.RemoteRepositoryContextProvider.InRemoteRepositoryContext_WithoutExistenceCheck(
                repositorySpecification.Name,
                async remoteRepositoryContext =>
                {
                    // Check whether the remote repository exists.
                    var remoteRepositoryExists = await remoteRepositoryContext.Exists();
                    if(remoteRepositoryExists)
                    {
                        throw new Exception($"Remote repository '{remoteRepositoryContext.Name}' exists.");
                    }

                    await this.LocalRepositoryContextProvider.InLocalRepositoryContext_WithoutExistenceCheck(
                        repositorySpecification.Name,
                        async localRepositoryContext =>
                        {
                            // Check whether the local repository exists.
                            var localRepositoryExists = await localRepositoryContext.DirectoryExists();
                            if(localRepositoryExists)
                            {
                                throw new Exception($"Local repository already exists:\n{localRepositoryContext.DirectoryPath}");
                            }
                            
                            // Tests have passed, now create the repository.
                            // Create the remote repository.
                            await remoteRepositoryContext.Create(
                                repositorySpecification.Description,
                                repositorySpecification.IsPrivate);

                            // Clone the remote repository locally.
                            await localRepositoryContext.Clone(remoteRepositoryContext);

                            // Do no further actions (like add git-ignore file and then check-in). These can be done in a different operation.
                        });
                });
        }
    }
}
