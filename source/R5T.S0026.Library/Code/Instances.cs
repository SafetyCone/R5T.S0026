using System;

using R5T.D0082.T001;
using R5T.L0011.T001;
using R5T.T0021;
using R5T.T0034;
using R5T.T0035;
using R5T.T0036;
using R5T.T0040;
using R5T.T0041;
using R5T.T0044;
using R5T.T0045;
using R5T.T0060;
using R5T.T0107;
using R5T.T0108;
using R5T.T0112;
using R5T.T0113;


namespace R5T.S0026.Library
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICodeFileOperator CodeFileOperator { get; } = T0045.CodeFileOperator.Instance;
        public static ICommitMessage CommitMessage { get; } = T0107.CommitMessage.Instance;
        public static ICompilationUnitGenerator CompilationUnitGenerator { get; } = T0045.CompilationUnitGenerator.Instance;
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static IFileName FileName { get; } = T0021.FileName.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IGitHubRepositorySpecificationGenerator GitHubRepositorySpecificationGenerator { get; } = D0082.T001.GitHubRepositorySpecificationGenerator.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static IMethodGenerator MethodGenerator { get; } = T0045.MethodGenerator.Instance;
        public static IMethodName MethodName { get; } = T0036.MethodName.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static INamespaceGenerator NamespaceGenerator { get; } = T0045.NamespaceGenerator.Instance;
        public static INamespaceName NamespaceName { get; } = T0035.NamespaceName.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
        public static IProjectNameOperator ProjectNameOperator { get; } = T0112.ProjectNameOperator.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IRepositoryNameOperator RepositoryNameOperator { get; } = T0108.RepositoryNameOperator.Instance;
        public static ISelector Selector { get; } = T0060.Selector.Instance;
        public static ISolutionFileNameOperator SolutionFileNameOperator { get; } = T0040.SolutionFileNameOperator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
        public static ISolutionPathsOperator SolutionPathsOperator { get; } = T0040.SolutionPathsOperator.Instance;
        public static IStatementGenerator StatementGenerator { get; } = T0045.StatementGenerator.Instance;
        public static IStatementOperator StatementOperator { get; } = T0045.StatementOperator.Instance;
        public static ISyntaxFactory SyntaxFactory { get; } = L0011.T001.SyntaxFactory.Instance;
        public static ITypeName TypeName { get; } = T0034.TypeName.Instance;
    }
}
