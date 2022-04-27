using System;

using R5T.B0002;
using R5T.L0011.T001;
using R5T.T0021;
using R5T.T0029.Dotnet.T001;
using R5T.T0032;
using R5T.T0034;
using R5T.T0036;
using R5T.T0037;
using R5T.T0040;
using R5T.T0041;
using R5T.T0044;
using R5T.T0045;
using R5T.T0060;
using R5T.T0062;
using R5T.T0070;
using R5T.T0103;
using R5T.T0107;
using R5T.T0108;
using R5T.T0110;
using R5T.T0111;
using R5T.T0112;
using R5T.T0113;
using R5T.T0115;
using R5T.T0116;
using R5T.T0123;


namespace R5T.S0026
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICodeDirectoryName CodeDirectoryName { get; } = T0037.CodeDirectoryName.Instance;
        public static ICodeFileGenerator CodeFileGenerator { get; } = T0045.CodeFileGenerator.Instance;
        public static ICodeFileOperator CodeFileOperator { get; } = T0045.CodeFileOperator.Instance;
        public static ICodeFileName CodeFileName { get; } = T0037.CodeFileName.Instance;
        public static ICommitMessage CommitMessage { get; } = T0107.CommitMessage.Instance;
        public static ICompilationUnitGenerator CompilationUnitGenerator { get; } = T0045.CompilationUnitGenerator.Instance;
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static IFileName FileName { get; } = T0021.FileName.Instance;
        public static IFileExtension FileExtension { get; } = T0032.FileExtension.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IHost Host { get; } = T0070.Host.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static ILibraryGenerator LibraryGenerator { get; } = T0111.LibraryGenerator.Instance;
        public static ILibraryNameOperator LibraryNameOperator { get; } = T0110.LibraryNameOperator.Instance;
        public static IMethodGenerator MethodGenerator { get; } = T0045.MethodGenerator.Instance;
        public static IMethodName MethodName { get; } = T0036.MethodName.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
        public static IProjectDescriptionGenerator ProjectDescriptionGenerator { get; } = T0115.ProjectDescriptionGenerator.Instance;
        public static IProjectGenerator ProjectGenerator { get; } = T0113.ProjectGenerator.Instance;
        public static IProjectNameOperator ProjectNameOperator { get; } = T0112.ProjectNameOperator.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static IProjectPath ProjectPath { get; } = T0040.ProjectPath.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IProjectType ProjectType { get; } = T0029.Dotnet.T001.ProjectType.Instance;
        public static IRepositoryGenerator RepositoryGenerator { get; } = T0103.RepositoryGenerator.Instance;
        public static IRepositoryOperator RepositoryOperator { get; } = T0103.RepositoryOperator.Instance;
        public static IRepositoryNameOperator RepositoryNameOperator { get; } = T0108.RepositoryNameOperator.Instance;
        public static IRepositoryPathOperator RepositoryPathOperator { get; } = T0123.RepositoryPathOperator.Instance;
        public static ISelector Selector { get; } = T0060.Selector.Instance;
        public static IServiceAction ServiceAction { get; } = T0062.ServiceAction.Instance;
        public static ISolutionFileNameOperator SolutionFileNameOperator { get; } = T0040.SolutionFileNameOperator.Instance;
        public static ISolutionFolder SolutionFolder { get; } = T0116.SolutionFolder.Instance;
        public static ISolutionGenerator SolutionGenerator { get; } = T0113.SolutionGenerator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
        public static ISolutionPathsOperator SolutionPathsOperator { get; } = T0040.SolutionPathsOperator.Instance;
        public static ISyntaxFactory SyntaxFactory { get; } = L0011.T001.SyntaxFactory.Instance;
    }
}
