using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0037;
using R5T.D0078;
using R5T.D0079;
using R5T.D0082;
using R5T.D0083;
using R5T.D0084.D002;
using R5T.D0101;
using R5T.D0111.D001;
using R5T.D0116;
using R5T.T0063;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MethodContextProvider"/> implementation of <see cref="IMethodContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMethodContextProvider(this IServiceCollection services)
        {
            services.AddSingleton<IMethodContextProvider, MethodContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ClassContextProvider"/> implementation of <see cref="IClassContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddClassContextProvider(this IServiceCollection services)
        {
            services.AddSingleton<IClassContextProvider, ClassContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="NamespaceContextProvider"/> implementation of <see cref="INamespaceContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddNamespaceContextProvider(this IServiceCollection services)
        {
            services.AddSingleton<INamespaceContextProvider, NamespaceContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SyntaxContextProviderAggregation"/> implementation of <see cref="ISyntaxContextProviderAggregation"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSyntaxContextProviderAggregation(this IServiceCollection services,
            IServiceAction<IClassContextProvider> classContextProviderAction,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IMethodContextProvider> methodContextProviderAction,
            IServiceAction<INamespaceContextProvider> namespaceContextProviderAction)
        {
            services
                .Run(classContextProviderAction)
                .Run(compilationUnitContextProviderAction)
                .Run(methodContextProviderAction)
                .Run(namespaceContextProviderAction)
                .AddSingleton<ISyntaxContextProviderAggregation, SyntaxContextProviderAggregation>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SolutionContextProvider"/> implementation of <see cref="ISolutionContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSolutionContextProvider(this IServiceCollection services,
            IServiceAction<IProjectRepository> projectRepositoryAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(projectRepositoryAction)
                .Run(stringlyTypedPathOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<ISolutionContextProvider, SolutionContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RepositorySolutionProjectFileSystemConventions"/> implementation of <see cref="IRepositorySolutionProjectFileSystemConventions"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRepositorySolutionProjectFileSystemConventions(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<IRepositorySolutionProjectFileSystemConventions, RepositorySolutionProjectFileSystemConventions>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="LocalRepositoryContextProvider"/> implementation of <see cref="ILocalRepositoryContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddLocalRepositoryContextProvider(this IServiceCollection services,
            IServiceAction<IGitIgnoreTemplateFilePathProvider> gitIgnoreTemplateFilePathProviderAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(gitIgnoreTemplateFilePathProviderAction)
                .Run(repositoriesDirectoryPathProviderAction)
                .Run(gitOperatorAction)
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<ILocalRepositoryContextProvider, LocalRepositoryContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="CompilationUnitContextProvider"/> implementation of <see cref="ICompilationUnitContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCompilationUnitContextProvider(this IServiceCollection services,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            services
                .Run(usingDirectivesFormatterAction)
                .AddSingleton<ICompilationUnitContextProvider, CompilationUnitContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FileSystemContextProviderAggregation"/> implementation of <see cref="IFileSystemContextProviderAggregation"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFileSystemContextProviderAggregation(this IServiceCollection services,
            IServiceAction<IDirectoryContextProvider> directoryContextProviderAction,
            IServiceAction<IFileContextProvider> fileContextProviderAction)
        {
            services
                .Run(directoryContextProviderAction)
                .Run(fileContextProviderAction)
                .AddSingleton<IFileSystemContextProviderAggregation, FileSystemContextProviderAggregation>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FileContextProvider"/> implementation of <see cref="IFileContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFileContextProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<IFileContextProvider, FileContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryContextProvider"/> implementation of <see cref="IDirectoryContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectoryContextProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<IDirectoryContextProvider, DirectoryContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ProjectContextProvider"/> implementation of <see cref="IProjectContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddProjectContextProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .Run(visualStudioProjectFileOperatorAction)
                .AddSingleton<IProjectContextProvider, ProjectContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="BasicSolutionContextProvider"/> implementation of <see cref="IBasicSolutionContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddBasicSolutionContextProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<IBasicSolutionContextProvider, BasicSolutionContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="BasicLocalRepositoryContextProvider"/> implementation of <see cref="IBasicLocalRepositoryContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddBasicLocalRepositoryContextProvider(this IServiceCollection services,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(gitOperatorAction)
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<IBasicLocalRepositoryContextProvider, BasicLocalRepositoryContextProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RemoteRepositoryContextProvider"/> implementation of <see cref="IRemoteRepositoryContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRemoteRepositoryContextProvider(this IServiceCollection services,
            IServiceAction<IGitHubOperator> gitHubOperatorAction)
        {
            services
                .Run(gitHubOperatorAction)
                .AddSingleton<IRemoteRepositoryContextProvider, RemoteRepositoryContextProvider>();

            return services;
        }
    }
}
