using System;

using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class SyntaxContextProviderAggregation : ISyntaxContextProviderAggregation, IServiceImplementation
    {
        public IClassContextProvider ClassContextProvider { get; }
        public ICompilationUnitContextProvider CompilationUnitContextProvider { get; }
        public IMethodContextProvider MethodContextProvider { get; }
        public INamespaceContextProvider NamespaceContextProvider { get; }


        public SyntaxContextProviderAggregation(
            IClassContextProvider classContextProvider,
            ICompilationUnitContextProvider compilationUnitContextProvider,
            IMethodContextProvider methodContextProvider,
            INamespaceContextProvider namespaceContextProvider)
        {
            this.ClassContextProvider = classContextProvider;
            this.CompilationUnitContextProvider = compilationUnitContextProvider;
            this.MethodContextProvider = methodContextProvider;
            this.NamespaceContextProvider = namespaceContextProvider;
        }
    }
}
