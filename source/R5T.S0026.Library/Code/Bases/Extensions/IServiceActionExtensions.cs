using System;

using R5T.D0037;
using R5T.D0078;
using R5T.D0079;
using R5T.D0082;
using R5T.D0083;
using R5T.D0084.D002;
using R5T.D0101;
using R5T.D0111.D001;
using R5T.D0116;
using R5T.T0062;
using R5T.T0063;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="MethodContextProvider"/> implementation of <see cref="IMethodContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMethodContextProvider> AddMethodContextProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IMethodContextProvider>(services => services.AddMethodContextProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="NamespaceContextProvider"/> implementation of <see cref="INamespaceContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<INamespaceContextProvider> AddNamespaceContextProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<INamespaceContextProvider>(services => services.AddNamespaceContextProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ClassContextProvider"/> implementation of <see cref="IClassContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IClassContextProvider> AddClassContextProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IClassContextProvider>(services => services.AddClassContextProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="SyntaxContextProviderAggregation"/> implementation of <see cref="ISyntaxContextProviderAggregation"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISyntaxContextProviderAggregation> AddSyntaxContextProviderAggregationAction(this IServiceAction _,
            IServiceAction<IClassContextProvider> classContextProviderAction,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IMethodContextProvider> methodContextProviderAction,
            IServiceAction<INamespaceContextProvider> namespaceContextProviderAction)
        {
            var serviceAction = _.New<ISyntaxContextProviderAggregation>(services => services.AddSyntaxContextProviderAggregation(
                classContextProviderAction,
                compilationUnitContextProviderAction,
                methodContextProviderAction,
                namespaceContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="SolutionContextProvider"/> implementation of <see cref="ISolutionContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISolutionContextProvider> AddSolutionContextProviderAction(this IServiceAction _,
            IServiceAction<IProjectRepository> projectRepositoryAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<ISolutionContextProvider>(services => services.AddSolutionContextProvider(
                projectRepositoryAction,
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="RepositorySolutionProjectFileSystemConventions"/> implementation of <see cref="IRepositorySolutionProjectFileSystemConventions"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRepositorySolutionProjectFileSystemConventions> AddRepositorySolutionProjectFileSystemConventionsAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IRepositorySolutionProjectFileSystemConventions>(services => services.AddRepositorySolutionProjectFileSystemConventions(
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="LocalRepositoryContextProvider"/> implementation of <see cref="ILocalRepositoryContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ILocalRepositoryContextProvider> AddLocalRepositoryContextProviderAction(this IServiceAction _,
            IServiceAction<IGitIgnoreTemplateFilePathProvider> gitIgnoreTemplateFilePathProviderAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<ILocalRepositoryContextProvider>(services => services.AddLocalRepositoryContextProvider(
                gitIgnoreTemplateFilePathProviderAction,
                repositoriesDirectoryPathProviderAction,
                gitOperatorAction,
                stringlyTypedPathOperatorAction));
            
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="CompilationUnitContextProvider"/> implementation of <see cref="ICompilationUnitContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICompilationUnitContextProvider> AddCompilationUnitContextProviderAction(this IServiceAction _,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            var serviceAction = _.New<ICompilationUnitContextProvider>(services => services.AddCompilationUnitContextProvider(
                usingDirectivesFormatterAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FileSystemContextProviderAggregation"/> implementation of <see cref="IFileSystemContextProviderAggregation"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFileSystemContextProviderAggregation> AddFileSystemContextProviderAggregationAction(this IServiceAction _,
            IServiceAction<IDirectoryContextProvider> directoryContextProviderAction,
            IServiceAction<IFileContextProvider> fileContextProviderAction)
        {
            var serviceAction = _.New<IFileSystemContextProviderAggregation>(services => services.AddFileSystemContextProviderAggregation(
                directoryContextProviderAction,
                fileContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FileContextProvider"/> implementation of <see cref="IFileContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFileContextProvider> AddFileContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IFileContextProvider>(services => services.AddFileContextProvider(
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryContextProvider"/> implementation of <see cref="IDirectoryContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectoryContextProvider> AddDirectoryContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IDirectoryContextProvider>(services => services.AddDirectoryContextProvider(
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ProjectContextProvider"/> implementation of <see cref="IProjectContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProjectContextProvider> AddProjectContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction)
        {
            var serviceAction = _.New<IProjectContextProvider>(services => services.AddProjectContextProvider(
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="BasicSolutionContextProvider"/> implementation of <see cref="IBasicSolutionContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IBasicSolutionContextProvider> AddBasicSolutionContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<IBasicSolutionContextProvider>(services => services.AddBasicSolutionContextProvider(
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="BasicLocalRepositoryContextProvider"/> implementation of <see cref="IBasicLocalRepositoryContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IBasicLocalRepositoryContextProvider> AddBasicLocalRepositoryContextProviderAction(this IServiceAction _,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IBasicLocalRepositoryContextProvider>(services => services.AddBasicLocalRepositoryContextProvider(
                gitOperatorAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="RemoteRepositoryContextProvider"/> implementation of <see cref="IRemoteRepositoryContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRemoteRepositoryContextProvider> AddRemoteRepositoryContextProviderAction(this IServiceAction _,
            IServiceAction<IGitHubOperator> gitHubOperatorAction)
        {
            var serviceAction = _.New<IRemoteRepositoryContextProvider>(services => services.AddRemoteRepositoryContextProvider(
                gitHubOperatorAction));

            return serviceAction;
        }
    }
}
