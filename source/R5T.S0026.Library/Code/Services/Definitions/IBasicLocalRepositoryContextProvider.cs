using System;

using R5T.D0037;
using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    /// <summary>
    /// 
    /// Follows an open-innards approach to allow functionality to be provided via extension method.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IBasicLocalRepositoryContextProvider : IServiceDefinition
    {
        IGitOperator SourceControlOperator { get; }
        IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
    }
}
