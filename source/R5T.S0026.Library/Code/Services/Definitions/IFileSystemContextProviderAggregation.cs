using System;

using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceDefinitionMarker]
    public interface IFileSystemContextProviderAggregation : IServiceDefinition
    {
        IDirectoryContextProvider DirectoryContextProvider { get; }
        IFileContextProvider FileContextProvider { get; }
    }
}
