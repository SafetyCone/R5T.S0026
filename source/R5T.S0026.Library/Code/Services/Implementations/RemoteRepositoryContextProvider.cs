using System;

using R5T.D0082;
using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class RemoteRepositoryContextProvider : IRemoteRepositoryContextProvider, IServiceImplementation
    {
        public IGitHubOperator RemoteRepositoryOperator { get; }


        public RemoteRepositoryContextProvider(
            IGitHubOperator remoteRepositoryOperator)
        {
            this.RemoteRepositoryOperator = remoteRepositoryOperator;
        }
    }
}
