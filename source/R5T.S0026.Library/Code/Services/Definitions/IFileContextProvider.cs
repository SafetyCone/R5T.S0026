using System;

using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceDefinitionMarker]
    public interface IFileContextProvider : IServiceDefinition
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
    }
}
