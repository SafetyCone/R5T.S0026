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

using R5T.S0026.Library;


namespace R5T.S0026
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O104_DeleteProjectFromSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO104_DeleteProjectFromSolution(this IServiceCollection services,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<IBasicSolutionContextProvider> solutionContextProviderAction)
        {
            services
                .Run(projectContextProviderAction)
                .Run(solutionContextProviderAction)
                .AddSingleton<O104_DeleteProjectFromSolution>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O103_CreateProjectForExistingSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO103_CreateProjectForExistingSolution(this IServiceCollection services,
            IServiceAction<O103_CreateProjectForExistingSolutionCore> o103_CreateProjectForExistingSolutionCoreAction)
        {
            services
                .Run(o103_CreateProjectForExistingSolutionCoreAction)
                .AddSingleton<O103_CreateProjectForExistingSolution>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O103_CreateProjectForExistingSolutionCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO103_CreateProjectForExistingSolutionCore(this IServiceCollection services,
            IServiceAction<O103A_CreateAndAddProjectOnly> o103A_CreateAndAddProjectOnlyAction,
            IServiceAction<O103B_ModifyInitialProjectForProjectType> o103B_ModifyInitialProjectForProjectTypeAction)
        {
            services
                .Run(o103A_CreateAndAddProjectOnlyAction)
                .Run(o103B_ModifyInitialProjectForProjectTypeAction)
                .AddSingleton<O103_CreateProjectForExistingSolutionCore>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O103A_CreateAndAddProjectOnly"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO103A_CreateAndAddProjectOnly(this IServiceCollection services,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<ISolutionContextProvider> solutionContextProviderAction)
        {
            services
                .Run(projectContextProviderAction)
                .Run(solutionContextProviderAction)
                .AddSingleton<O103A_CreateAndAddProjectOnly>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O103B_ModifyInitialProjectForProjectType"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO103B_ModifyInitialProjectForProjectType(this IServiceCollection services,
            IServiceAction<IFileSystemContextProviderAggregation> fileSystemContextProviderAggregationAction,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<ISyntaxContextProviderAggregation> syntaxContextProviderAggregationAction)
        {
            services
                .Run(fileSystemContextProviderAggregationAction)
                .Run(projectContextProviderAction)
                .Run(syntaxContextProviderAggregationAction)
                .AddSingleton<O103B_ModifyInitialProjectForProjectType>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O102_CreateSolutionInExistingRespository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO102_CreateSolutionInExistingRespository(this IServiceCollection services,
            IServiceAction<O102_CreateSolutionInExistingRespositoryCore> o102_CreateSolutionInExistingRespositoryCoreAction)
        {
            services
                .Run(o102_CreateSolutionInExistingRespositoryCoreAction)
                .AddSingleton<O102_CreateSolutionInExistingRespository>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O102_CreateSolutionInExistingRespositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO102_CreateSolutionInExistingRespositoryCore(this IServiceCollection services,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IRepositorySolutionProjectFileSystemConventions> repositorySolutionProjectFileSystemConventionsAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<O102A_CreateSolutionOnly> o102A_CreateSolutionOnlyAction,
            IServiceAction<O102B_ModifyInitialSolution> o102B_ModifyInitialSolutionAction)
        {
            services
                .Run(repositoriesDirectoryPathProviderAction)
                .Run(repositorySolutionProjectFileSystemConventionsAction)
                .Run(stringlyTypedPathOperatorAction)
                .Run(o102A_CreateSolutionOnlyAction)
                .Run(o102B_ModifyInitialSolutionAction)
                .AddSingleton<O102_CreateSolutionInExistingRespositoryCore>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O102A_CreateSolutionOnly"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO102A_CreateSolutionOnly(this IServiceCollection services,
            IServiceAction<IBasicSolutionContextProvider> solutionContextProviderAction)
        {
            services
                .Run(solutionContextProviderAction)
                .AddSingleton<O102A_CreateSolutionOnly>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O102B_ModifyInitialSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO102B_ModifyInitialSolution(this IServiceCollection services,
            IServiceAction<ISolutionContextProvider> solutionContextProviderAction)
        {
            services
                .Run(solutionContextProviderAction)
                .AddSingleton<O102B_ModifyInitialSolution>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O101_DeleteNewRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO101_DeleteNewRepository(this IServiceCollection services,
            IServiceAction<O101_DeleteNewRepositoryCore> o101_DeleteNewRepositoryCoreAction)
        {
            services
                .Run(o101_DeleteNewRepositoryCoreAction)
                .AddSingleton<O101_DeleteNewRepository>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O101_DeleteNewRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO101_DeleteNewRepositoryCore(this IServiceCollection services,
            IServiceAction<ILocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction)
        {
            services
                .Run(localRepositoryContextProviderAction)
                .Run(remoteRepositoryContextProviderAction)
                .AddSingleton<O101_DeleteNewRepositoryCore>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O100_CreateNewRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO100_CreateNewRepository(this IServiceCollection services,
            IServiceAction<O100_CreateNewRepositoryCore> o100_CreateNewRepositoryCoreAction)
        {
            services
                .Run(o100_CreateNewRepositoryCoreAction)
                .AddSingleton<O100_CreateNewRepository>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O100_CreateNewRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO100_CreateNewRepositoryCore(this IServiceCollection services,
            IServiceAction<O100A_CreateNewRepositoryOnly> o100A_CreateNewRepositoryOnlyAction,
            IServiceAction<O100B_InitialSetupWithCheckIn> o100B_InitialSetupWithCheckInAction)
        {
            services
                .Run(o100A_CreateNewRepositoryOnlyAction)
                .Run(o100B_InitialSetupWithCheckInAction)
                .AddSingleton<O100_CreateNewRepositoryCore>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O100B_InitialSetupWithCheckIn"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO100B_InitialSetupWithCheckIn(this IServiceCollection services,
            IServiceAction<ILocalRepositoryContextProvider> localRepositoryContextProviderAction)
        {
            services
                .Run(localRepositoryContextProviderAction)
                .AddSingleton<O100B_InitialSetupWithCheckIn>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O100A_CreateNewRepositoryOnly"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO100A_CreateNewRepositoryOnly(this IServiceCollection services,
            IServiceAction<ILocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction)
        {
            services
                .Run(localRepositoryContextProviderAction)
                .Run(remoteRepositoryContextProviderAction)
                .AddSingleton<O100A_CreateNewRepositoryOnly>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O007_CreateNewProgramAsServiceRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO007_CreateNewProgramAsServiceRepository(this IServiceCollection services,
            IServiceAction<O001a_CreateNewRepositoryCore> o001a_CreateNewRepositoryCoreAction,
            IServiceAction<O006_CreateNewProgramAsServiceSolutionCore> o006_CreateNewProgramAsServiceSolutionCoreAction)
        {
            services
                .Run(o001a_CreateNewRepositoryCoreAction)
                .Run(o006_CreateNewProgramAsServiceSolutionCoreAction)
                .AddSingleton<O007_CreateNewProgramAsServiceRepository>();

            return services;
        }

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
            IServiceAction<O006_CreateNewProgramAsServiceSolutionCore> o006_CreateNewProgramAsServiceSolutionCoreAction)
        {
            services
                .Run(o006_CreateNewProgramAsServiceSolutionCoreAction)
                .AddSingleton<O006_CreateNewProgramAsServiceSolution>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="O006_CreateNewProgramAsServiceSolutionCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO006_CreateNewProgramAsServiceSolutionCore(this IServiceCollection services,
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
                .AddSingleton<O006_CreateNewProgramAsServiceSolutionCore>();

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
        public static IServiceCollection AddO999_Scratch(this IServiceCollection services,
            IServiceAction<IFileSystemContextProviderAggregation> fileSystemContextProviderAggregationAction,
            IServiceAction<IBasicLocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IBasicSolutionContextProvider> solutionContextProviderAction)
        {
            services
                .Run(fileSystemContextProviderAggregationAction)
                .Run(localRepositoryContextProviderAction)
                .Run(projectContextProviderAction)
                .Run(remoteRepositoryContextProviderAction)
                .Run(repositoriesDirectoryPathProviderAction)
                .Run(solutionContextProviderAction)
                .AddSingleton<O999_Scratch>();

            return services;
        }
    }
}
