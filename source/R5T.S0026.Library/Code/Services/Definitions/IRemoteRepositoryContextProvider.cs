using System;

using R5T.D0082;
using R5T.T0064;


namespace R5T.S0026.Library
{
    /// <summary>
    /// 
    /// Follows an open-innards approach to allow functionality to be provided via extension method.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IRemoteRepositoryContextProvider : IServiceDefinition
    {
        IGitHubOperator RemoteRepositoryOperator { get; }
    }
}
