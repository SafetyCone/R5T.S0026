using System;

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
using R5T.T0062;
using R5T.T0063;


namespace R5T.S0026
{
    public static partial class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O006a_ModifyHostStartupForA0003"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O006a_ModifyHostStartupForA0003> AddO006a_ModifyHostStartupForA0003Action(this IServiceAction _,
            IServiceAction<IProjectRepository> projectRepositoryAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<O006a_ModifyHostStartupForA0003>(services => services.AddO006a_ModifyHostStartupForA0003(
                projectRepositoryAction,
                visualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O006_CreateNewProgramAsServiceSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O006_CreateNewProgramAsServiceSolution> AddO006_CreateNewProgramAsServiceSolutionAction(this IServiceAction _,
            IServiceAction<IProjectRepository> projectRepositoryAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<O006_CreateNewProgramAsServiceSolution>(services => services.AddO006_CreateNewProgramAsServiceSolution(
                projectRepositoryAction,
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }


        /// <summary>
        /// Adds the <see cref="O005_CreateProjectForExistingSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O005_CreateProjectForExistingSolution> AddO005_CreateProjectForExistingSolutionAction(this IServiceAction _,
            IServiceAction<CreateProjectForExistingSolution> createProjectForExistingSolutionAction)
        {
            var serviceAction = _.New<O005_CreateProjectForExistingSolution>(services => services.AddO005_CreateProjectForExistingSolution(
                createProjectForExistingSolutionAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O004_CreateSolutionInExistingRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O004_CreateSolutionInExistingRepository> AddO004_CreateSolutionInExistingRepositoryAction(this IServiceAction _,
            IServiceAction<CreateSolutionInExistingRepository> createSolutionInExistingRepositoryAction)
        {
            var serviceAction = _.New<O004_CreateSolutionInExistingRepository>(services => services.AddO004_CreateSolutionInExistingRepository(
                createSolutionInExistingRepositoryAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O003_CreateNewBasicTypesLibrary"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O003_CreateNewBasicTypesLibrary> AddO003_CreateNewBasicTypesLibraryAction(this IServiceAction _,
            IServiceAction<IGitHubOperator> gitHubOperatorAction,
            IServiceAction<IGitIgnoreTemplateFilePathProvider> gitIgnoreTemplateFilePathProviderAction,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<O003_CreateNewBasicTypesLibrary>(services => services.AddO003_CreateNewBasicTypesLibrary(
                gitHubOperatorAction,
                gitIgnoreTemplateFilePathProviderAction,
                gitOperatorAction,
                repositoriesDirectoryPathProviderAction,
                visualStudioProjectFileOperatorAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O002_DeleteRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O002_DeleteRepository> AddO002_DeleteRepositoryAction(this IServiceAction _,
            IServiceAction<O002a_DeleteRepositoryCore> o002a_DeleteRepositoryCoreAction)
        {
            var serviceAction = _.New<O002_DeleteRepository>(services => services.AddO002_DeleteRepository(
                o002a_DeleteRepositoryCoreAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O002a_DeleteRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O002a_DeleteRepositoryCore> AddO002a_DeleteRepositoryCoreAction(this IServiceAction _,
            IServiceAction<IGitHubOperator> gitHubOperatorAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction)
        {
            var serviceAction = _.New<O002a_DeleteRepositoryCore>(services => services.AddO002a_DeleteRepositoryCore(
                gitHubOperatorAction,
                repositoriesDirectoryPathProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O001a_CreateNewRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O001a_CreateNewRepositoryCore> AddO001a_CreateNewRepositoryCoreAction(this IServiceAction _,
            IServiceAction<IGitHubOperator> gitHubOperatorAction,
            IServiceAction<IGitIgnoreTemplateFilePathProvider> gitIgnoreTemplateFilePathProviderAction,
            IServiceAction<IGitOperator> gitOperatorAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction)
        {
            var serviceAction = _.New<O001a_CreateNewRepositoryCore>(services => services.AddO001a_CreateNewRepositoryCore(
                gitHubOperatorAction,
                gitIgnoreTemplateFilePathProviderAction,
                gitOperatorAction,
                repositoriesDirectoryPathProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O001_CreateNewRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O001_CreateNewRepository> AddO001_CreateNewRepositoryAction(this IServiceAction _,
            IServiceAction<O001a_CreateNewRepositoryCore> o001a_CreateNewRepositoryCoreAction)
        {
            var serviceAction = _.New<O001_CreateNewRepository>(services => services.AddO001_CreateNewRepository(
                o001a_CreateNewRepositoryCoreAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O999_Scratch"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O999_Scratch> AddO999_ScratchAction(this IServiceAction _)
        {
            var serviceAction = _.New<O999_Scratch>(services => services.AddO999_Scratch());
            return serviceAction;
        }
    }
}
