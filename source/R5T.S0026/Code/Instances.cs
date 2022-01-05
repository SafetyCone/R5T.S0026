using System;

using R5T.T0029.Dotnet.T001;
using R5T.T0040;
using R5T.T0041;
using R5T.T0044;
using R5T.T0062;
using R5T.T0070;
using R5T.T0103;
using R5T.T0108;
using R5T.T0110;
using R5T.T0111;
using R5T.T0113;
using R5T.T0123;


namespace R5T.S0026
{
    public static class Instances
    {
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IHost Host { get; } = T0070.Host.Instance;
        public static ILibraryGenerator LibraryGenerator { get; } = T0111.LibraryGenerator.Instance;
        public static ILibraryNameOperator LibraryNameOperator { get; } = T0110.LibraryNameOperator.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
        public static IProjectGenerator ProjectGenerator { get; } = T0113.ProjectGenerator.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static IProjectType ProjectType { get; } = T0029.Dotnet.T001.ProjectType.Instance;
        public static IRepositoryGenerator RepositoryGenerator { get; } = T0103.RepositoryGenerator.Instance;
        public static IRepositoryOperator RepositoryOperator { get; } = T0103.RepositoryOperator.Instance;
        public static IRepositoryNameOperator RepositoryNameOperator { get; } = T0108.RepositoryNameOperator.Instance;
        public static IRepositoryPathOperator RepositoryPathOperator { get; } = T0123.RepositoryPathOperator.Instance;
        public static IServiceAction ServiceAction { get; } = T0062.ServiceAction.Instance;
        public static ISolutionFileNameOperator SolutionFileNameOperator { get; } = T0040.SolutionFileNameOperator.Instance;
        public static ISolutionGenerator SolutionGenerator { get; } = T0113.SolutionGenerator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
        public static ISolutionPathsOperator SolutionPathsOperator { get; } = T0040.SolutionPathsOperator.Instance;
    }
}
