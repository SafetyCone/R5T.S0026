using System;

using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceDefinitionMarker]
    public interface ISyntaxContextProviderAggregation : IServiceDefinition
    {
        IClassContextProvider ClassContextProvider { get; }
        ICompilationUnitContextProvider CompilationUnitContextProvider { get; }
        IMethodContextProvider MethodContextProvider { get; }
        INamespaceContextProvider NamespaceContextProvider { get; }
    }
}
