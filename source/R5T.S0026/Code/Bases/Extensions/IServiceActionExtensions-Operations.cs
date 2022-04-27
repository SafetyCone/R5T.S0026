using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0037;
using R5T.D0078;
using R5T.D0079;
using R5T.D0082;
using R5T.D0083;
using R5T.D0084.D001;
using R5T.D0084.D002;
using R5T.D0101;
using R5T.D0111.D001;
using R5T.O0001;
using R5T.T0062;
using R5T.T0063;

using R5T.S0026.Library;


namespace R5T.S0026
{
    public static partial class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O900_CreateAllRepositoryAllProjectsSolutionFiles"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O900_CreateAllRepositoryAllProjectsSolutionFiles> AddO900_CreateAllRepositoryAllProjectsSolutionFilesAction(this IServiceAction _,
            IServiceAction<IAllRepositoryDirectoryPathsProvider> allRepositoryDirectoryPathsProviderAction,
            IServiceAction<ILocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<ISolutionContextProvider> solutionContextProviderAction)
        {
            var serviceAction = _.New<O900_CreateAllRepositoryAllProjectsSolutionFiles>(services => services.AddO900_CreateAllRepositoryAllProjectsSolutionFiles(
                allRepositoryDirectoryPathsProviderAction,
                localRepositoryContextProviderAction,
                solutionContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O104_DeleteProjectFromSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O104_DeleteProjectFromSolution> AddO104_DeleteProjectFromSolutionAction(this IServiceAction _,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<IBasicSolutionContextProvider> solutionContextProviderAction)
        {
            var serviceAction = _.New<O104_DeleteProjectFromSolution>(services => services.AddO104_DeleteProjectFromSolution(
                projectContextProviderAction,
                solutionContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O103_CreateProjectForExistingSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O103_CreateProjectForExistingSolution> AddO103_CreateProjectForExistingSolutionAction(this IServiceAction _,
            IServiceAction<O103_CreateProjectForExistingSolutionCore> o103_CreateProjectForExistingSolutionCoreAction)
        {
            var serviceAction = _.New<O103_CreateProjectForExistingSolution>(services => services.AddO103_CreateProjectForExistingSolution(
                o103_CreateProjectForExistingSolutionCoreAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O103_CreateProjectForExistingSolutionCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O103_CreateProjectForExistingSolutionCore> AddO103_CreateProjectForExistingSolutionCoreAction(this IServiceAction _,
            IServiceAction<O103A_CreateAndAddProjectOnly> o103A_CreateAndAddProjectOnlyAction,
            IServiceAction<O103B_ModifyInitialProjectForProjectType> o103B_ModifyInitialProjectForProjectTypeAction)
        {
            var serviceAction = _.New<O103_CreateProjectForExistingSolutionCore>(services => services.AddO103_CreateProjectForExistingSolutionCore(
                o103A_CreateAndAddProjectOnlyAction,
                o103B_ModifyInitialProjectForProjectTypeAction));

            return serviceAction;
        }
        
        /// <summary>
        /// Adds the <see cref="O103A_CreateAndAddProjectOnly"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O103A_CreateAndAddProjectOnly> AddO103A_CreateAndAddProjectOnlyAction(this IServiceAction _,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<ISolutionContextProvider> solutionContextProviderAction)
        {
            var serviceAction = _.New<O103A_CreateAndAddProjectOnly>(services => services.AddO103A_CreateAndAddProjectOnly(
                projectContextProviderAction,
                solutionContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O103B_ModifyInitialProjectForProjectType"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O103B_ModifyInitialProjectForProjectType> AddO103B_ModifyInitialProjectForProjectTypeAction(this IServiceAction _,
            IServiceAction<IFileSystemContextProviderAggregation> fileSystemContextProviderAggregationAction,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<ISyntaxContextProviderAggregation> syntaxContextProviderAggregationAction)
        {
            var serviceAction = _.New<O103B_ModifyInitialProjectForProjectType>(services => services.AddO103B_ModifyInitialProjectForProjectType(
                fileSystemContextProviderAggregationAction,
                projectContextProviderAction,
                syntaxContextProviderAggregationAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O102_CreateSolutionInExistingRespository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O102_CreateSolutionInExistingRespository> AddO102_CreateSolutionInExistingRespositoryAction(this IServiceAction _,
            IServiceAction<O102_CreateSolutionInExistingRespositoryCore> o102_CreateSolutionInExistingRespositoryCoreAction)
        {
            var serviceAction = _.New<O102_CreateSolutionInExistingRespository>(services => services.AddO102_CreateSolutionInExistingRespository(
                o102_CreateSolutionInExistingRespositoryCoreAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O102_CreateSolutionInExistingRespositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O102_CreateSolutionInExistingRespositoryCore> AddO102_CreateSolutionInExistingRespositoryCoreAction(this IServiceAction _,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IRepositorySolutionProjectFileSystemConventions> repositorySolutionProjectFileSystemConventionsAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<O102A_CreateSolutionOnly> o102A_CreateSolutionOnlyAction,
            IServiceAction<O102B_ModifyInitialSolution> o102B_ModifyInitialSolutionAction)
        {
            var serviceAction = _.New<O102_CreateSolutionInExistingRespositoryCore>(services => services.AddO102_CreateSolutionInExistingRespositoryCore(
                repositoriesDirectoryPathProviderAction,
                repositorySolutionProjectFileSystemConventionsAction,
                stringlyTypedPathOperatorAction,
                o102A_CreateSolutionOnlyAction,
                o102B_ModifyInitialSolutionAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O102A_CreateSolutionOnly"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O102A_CreateSolutionOnly> AddO102A_CreateSolutionOnlyAction(this IServiceAction _,
            IServiceAction<IBasicSolutionContextProvider> solutionContextProviderAction)
        {
            var serviceAction = _.New<O102A_CreateSolutionOnly>(services => services.AddO102A_CreateSolutionOnly(
                solutionContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O102B_ModifyInitialSolution"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O102B_ModifyInitialSolution> AddO102B_ModifyInitialSolutionAction(this IServiceAction _,
            IServiceAction<ISolutionContextProvider> solutionContextProviderAction)
        {
            var serviceAction = _.New<O102B_ModifyInitialSolution>(services => services.AddO102B_ModifyInitialSolution(
                solutionContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O101_DeleteNewRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O101_DeleteNewRepository> AddO101_DeleteNewRepositoryAction(this IServiceAction _,
            IServiceAction<O101_DeleteNewRepositoryCore> o101_DeleteNewRepositoryCoreAction)
        {
            var serviceAction = _.New<O101_DeleteNewRepository>(services => services.AddO101_DeleteNewRepository(
                o101_DeleteNewRepositoryCoreAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O101_DeleteNewRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O101_DeleteNewRepositoryCore> AddO101_DeleteNewRepositoryCoreAction(this IServiceAction _,
            IServiceAction<ILocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction)
        {
            var serviceAction = _.New<O101_DeleteNewRepositoryCore>(services => services.AddO101_DeleteNewRepositoryCore(
                localRepositoryContextProviderAction,
                remoteRepositoryContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O100_CreateNewRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O100_CreateNewRepository> AddO100_CreateNewRepositoryAction(this IServiceAction _,
            IServiceAction<O100_CreateNewRepositoryCore> o100_CreateNewRepositoryCoreAction)
        {
            var serviceAction = _.New<O100_CreateNewRepository>(services => services.AddO100_CreateNewRepository(
                o100_CreateNewRepositoryCoreAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O100_CreateNewRepositoryCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O100_CreateNewRepositoryCore> AddO100_CreateNewRepositoryCoreAction(this IServiceAction _,
            IServiceAction<O100A_CreateNewRepositoryOnly> o100A_CreateNewRepositoryOnlyAction,
            IServiceAction<O100B_InitialSetupWithCheckIn> o100B_InitialSetupWithCheckInAction)
        {
            var serviceAction = _.New<O100_CreateNewRepositoryCore>(services => services.AddO100_CreateNewRepositoryCore(
                o100A_CreateNewRepositoryOnlyAction,
                o100B_InitialSetupWithCheckInAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O100B_InitialSetupWithCheckIn"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O100B_InitialSetupWithCheckIn> AddO100B_InitialSetupWithCheckInAction(this IServiceAction _,
            IServiceAction<ILocalRepositoryContextProvider> localRepositoryContextProviderAction)
        {
            var serviceAction = _.New<O100B_InitialSetupWithCheckIn>(services => services.AddO100B_InitialSetupWithCheckIn(
                localRepositoryContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O100A_CreateNewRepositoryOnly"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O100A_CreateNewRepositoryOnly> AddO100A_CreateNewRepositoryOnlyAction(this IServiceAction _,
            IServiceAction<ILocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction)
        {
            var serviceAction = _.New<O100A_CreateNewRepositoryOnly>(services => services.AddO100A_CreateNewRepositoryOnly(
                localRepositoryContextProviderAction,
                remoteRepositoryContextProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O007_CreateNewProgramAsServiceRepository"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O007_CreateNewProgramAsServiceRepository> AddO007_CreateNewProgramAsServiceRepositoryAction(this IServiceAction _,
            IServiceAction<O001a_CreateNewRepositoryCore> o001a_CreateNewRepositoryCoreAction,
            IServiceAction<O006_CreateNewProgramAsServiceSolutionCore> o006_CreateNewProgramAsServiceSolutionCoreAction)
        {
            var serviceAction = _.New<O007_CreateNewProgramAsServiceRepository>(services => services.AddO007_CreateNewProgramAsServiceRepository(
                o001a_CreateNewRepositoryCoreAction,
                o006_CreateNewProgramAsServiceSolutionCoreAction));

            return serviceAction;
        }

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
            IServiceAction<O006_CreateNewProgramAsServiceSolutionCore> o006_CreateNewProgramAsServiceSolutionCoreAction)
        {
            var serviceAction = _.New<O006_CreateNewProgramAsServiceSolution>(services => services.AddO006_CreateNewProgramAsServiceSolution(
                o006_CreateNewProgramAsServiceSolutionCoreAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="O006_CreateNewProgramAsServiceSolutionCore"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O006_CreateNewProgramAsServiceSolutionCore> AddO006_CreateNewProgramAsServiceSolutionCoreAction(this IServiceAction _,
            IServiceAction<IProjectRepository> projectRepositoryAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<O006_CreateNewProgramAsServiceSolutionCore>(services => services.AddO006_CreateNewProgramAsServiceSolutionCore(
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
        public static IServiceAction<O999_Scratch> AddO999_ScratchAction(this IServiceAction _,
            IServiceAction<IFileSystemContextProviderAggregation> fileSystemContextProviderAggregationAction,
            IServiceAction<IBasicLocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<IProjectContextProvider> projectContextProviderAction,
            IServiceAction<IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction,
            IServiceAction<IRepositoriesDirectoryPathProvider> repositoriesDirectoryPathProviderAction,
            IServiceAction<IBasicSolutionContextProvider> solutionContextProviderAction)
        {
            var serviceAction = _.New<O999_Scratch>(services => services.AddO999_Scratch(
                fileSystemContextProviderAggregationAction,
                localRepositoryContextProviderAction,
                projectContextProviderAction,
                remoteRepositoryContextProviderAction,
                repositoriesDirectoryPathProviderAction,
                solutionContextProviderAction));
            
            return serviceAction;
        }
    }
}
