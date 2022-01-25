using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0037;
using R5T.D0078;
using R5T.D0079;
using R5T.D0082;
using R5T.D0083;
using R5T.D0084.D002;
using R5T.D0101;
using R5T.D0111.D001;
using R5T.O0001;
using R5T.T0063;


namespace R5T.S0026
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O006a_ModifyHostStartupForA0003"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO006a_ModifyHostStartupForA0003(this IServiceCollection services,
            IServiceAction<IProjectRepository> projectRepositoryAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(projectRepositoryAction)
                .Run(visualStudioProjectFileOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<O006a_ModifyHostStartupForA0003>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O006_CreateNewProgramAsServiceSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO006_CreateNewProgramAsServiceSolution(this IServiceCollection services,
            IServiceAction<IProjectRepository> projectRepositoryAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(projectRepositoryAction)
                .Run(stringlyTypedPathOperatorAction)
                .Run(visualStudioProjectFileOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<O006_CreateNewProgramAsServiceSolution>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O005_CreateProjectForExistingSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO005_CreateProjectForExistingSolution(this IServiceCollection services,
            IServiceAction<CreateProjectForExistingSolution> createProjectForExistingSolutionAction)
        {
            services
                .Run(createProjectForExistingSolutionAction)
                .AddSingleton<O005_CreateProjectForExistingSolution>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O004_CreateSolutionInExistingRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO004_CreateSolutionInExistingRepository(this IServiceCollection services,
            IServiceAction<CreateSolutionInExistingRepository> createSolutionInExistingRepositoryAction)
        {
            services
                .Run(createSolutionInExistingRepositoryAction)
                .AddSingleton<O004_CreateSolutionInExistingRepository>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O003_CreateNewBasicTypesLibrary"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO003_CreateNewBasicTypesLibrary(this IServiceCollection services,
            IServiceAction<IGitHubOperator> gitHubOperatorAction,
            IServiceAction<IGitIgnoreTemplateFilePathProvider> gitIgnoreTemplateFilePathProviderAction,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(gitHubOperatorAction)
                .Run(gitIgnoreTemplateFilePathProviderAction)
                .Run(gitOperatorAction)
                .Run(repositoriesDirectoryPathProviderAction)
                .Run(visualStudioProjectFileOperatorAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<O003_CreateNewBasicTypesLibrary>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O002_DeleteRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO002_DeleteRepository(this IServiceCollection services,
            IServiceAction<O002a_DeleteRepositoryCore> o002a_DeleteRepositoryCoreAction)
        {
            services
                .Run(o002a_DeleteRepositoryCoreAction)
                .AddSingleton<O002_DeleteRepository>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O002a_DeleteRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO002a_DeleteRepositoryCore(this IServiceCollection services,
            IServiceAction<IGitHubOperator> gitHubOperatorAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction)
        {
            services
                .Run(gitHubOperatorAction)
                .Run(repositoriesDirectoryPathProviderAction)
                .AddSingleton<O002a_DeleteRepositoryCore>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O001_CreateNewRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO001_CreateNewRepository(this IServiceCollection services,
            IServiceAction<O001a_CreateNewRepositoryCore> O001a_CreateNewRepositoryCoreAction)
        {
            services
                .Run(O001a_CreateNewRepositoryCoreAction)
                .AddSingleton<O001_CreateNewRepository>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O001a_CreateNewRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO001a_CreateNewRepositoryCore(this IServiceCollection services,
            IServiceAction<IGitHubOperator> gitHubOperatorAction,
            IServiceAction<IGitIgnoreTemplateFilePathProvider> gitIgnoreTemplateFilePathProviderAction,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction)
        {
            services
                .Run(gitHubOperatorAction)
                .Run(gitIgnoreTemplateFilePathProviderAction)
                .Run(gitOperatorAction)
                .Run(repositoriesDirectoryPathProviderAction)
                .AddSingleton<O001a_CreateNewRepositoryCore>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O999_Scratch"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO999_Scratch(this IServiceCollection services)
        {
            services.AddSingleton<O999_Scratch>();

            return services;
        }
    }
}
