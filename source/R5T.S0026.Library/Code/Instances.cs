using System;

using R5T.T0034;
using R5T.T0035;
using R5T.T0036;
using R5T.T0041;
using R5T.T0045;
using R5T.T0108;


namespace R5T.S0026.Library
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICompilationUnitGenerator CompilationUnitGenerator { get; } = T0045.CompilationUnitGenerator.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static IMethodGenerator MethodGenerator { get; } = T0045.MethodGenerator.Instance;
        public static INamespaceName NamespaceName { get; } = T0035.NamespaceName.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
        public static IRepositoryNameOperator RepositoryNameOperator { get; } = T0108.RepositoryNameOperator.Instance;
        public static ITypeName TypeName { get; } = T0034.TypeName.Instance;
    }
}
