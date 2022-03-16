using System;

using R5T.D0101;

using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceDefinitionMarker]
    public interface ISolutionContextProvider : IBasicSolutionContextProvider, IServiceDefinition
    {
        IProjectRepository ProjectRepository { get; }
    }
}
