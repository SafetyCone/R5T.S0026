using System;

using R5T.D0116;
using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceDefinitionMarker]
    public interface ICompilationUnitContextProvider : IServiceDefinition
    {
        IUsingDirectivesFormatter UsingDirectivesFormatter { get; }
    }
}
