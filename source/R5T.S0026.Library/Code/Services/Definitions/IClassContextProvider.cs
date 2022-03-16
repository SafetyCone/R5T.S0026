using System;

using R5T.T0064;


namespace R5T.S0026.Library
{
    /// <summary>
    /// Uses open-innards to allow extension methods to provide functionality.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IClassContextProvider : IServiceDefinition
    {
        // Empty for now, but will contain class-related services.
    }
}
