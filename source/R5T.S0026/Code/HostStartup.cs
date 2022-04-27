using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Magyar;
using R5T.Ostrogothia.Rivet;

using R5T.A0003;
using R5T.D0037.A002;
using R5T.D0048.Default;
using R5T.D0077.A002;
using R5T.D0078.A002;
using R5T.D0079.A002;
using R5T.D0081.I001;
using R5T.D0082.A001;
using R5T.D0083.I001;
using R5T.D0084.D001.I002;
using R5T.D0084.D002.I001;
using R5T.D0088.I0002;
using R5T.D0094.I001;
using R5T.D0095.I001;
using R5T.D0101.I0001;
using R5T.D0101.I001;
using R5T.D0111.D001.I001;
using R5T.D0116.A0001;
using R5T.O0001;
using R5T.T0063;

using R5T.S0026.Library;

using IProvidedServiceActionAggregation = R5T.D0088.I0002.IProvidedServiceActionAggregation;
using IRequiredServiceActionAggregation = R5T.D0088.I0002.IRequiredServiceActionAggregation;
using ServicesPlatformRequiredServiceActionAggregation = R5T.A0003.RequiredServiceActionAggregation;


namespace R5T.S0026
{
    public class HostStartup : HostStartupBase
    {
        public override Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
            // Do nothing.

            return Task.CompletedTask;
        }

        protected override Task ConfigureServices(IServiceCollection services, IProvidedServiceActionAggregation providedServicesAggregation)
        {
            // Inputs.
            var executionSynchronicityProviderAction = Instances.ServiceAction.AddConstructorBasedExecutionSynchronicityProviderAction(Synchronicity.Synchronous);
            var organizationProviderAction = Instances.ServiceAction.AddOrganizationProviderAction(); // Rivet organization.
            var rootOutputDirectoryPathProviderAction = Instances.ServiceAction.AddConstructorBasedRootOutputDirectoryPathProviderAction(@"C:\Temp\Output");

            // Services platform.
            var servicesPlatformRequiredServiceActionAggregation = new ServicesPlatformRequiredServiceActionAggregation
            {
                ConfigurationAction = providedServicesAggregation.ConfigurationAction,
                ExecutionSynchronicityProviderAction = executionSynchronicityProviderAction,
                LoggerAction = providedServicesAggregation.LoggerAction,
                LoggerFactoryAction = providedServicesAggregation.LoggerFactoryAction,
                MachineMessageOutputSinkProviderActions = EnumerableHelper.Empty<IServiceAction<D0099.D002.IMachineMessageOutputSinkProvider>>(),
                MachineMessageTypeJsonSerializationHandlerActions = EnumerableHelper.Empty<IServiceAction<D0098.IMachineMessageTypeJsonSerializationHandler>>(),
                OrganizationProviderAction = organizationProviderAction,
                RootOutputDirectoryPathProviderAction = rootOutputDirectoryPathProviderAction,
            };

            var servicesPlatform = Instances.ServiceAction.AddProvidedServiceActionAggregation(
                servicesPlatformRequiredServiceActionAggregation);

            // Logging.
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder
                    .SetMinimumLevel(LogLevel.Debug)
                    .AddConsole(
                        servicesPlatform.LoggerSynchronicityProviderAction)
                    .AddFile(
                        servicesPlatform.LogFilePathProviderAction,
                        servicesPlatform.LoggerSynchronicityProviderAction)
                    ;
            });

            // Project repository.
            var projectRepositoryFilePathsProviderAction = Instances.ServiceAction.AddHardCodedProjectRepositoryFilePathsProviderAction();

            var fileBasedProjectRepositoryAction = Instances.ServiceAction.AddFileBasedProjectRepositoryAction(
                projectRepositoryFilePathsProviderAction);

            var projectRepositoryAction = Instances.ServiceAction.ForwardFileBasedProjectRepositoryToProjectRepositoryAction(
                fileBasedProjectRepositoryAction);

            // Visual studio.
            var dotnetOperatorActions = Instances.ServiceAction.AddDotnetOperatorActions(
                servicesPlatform.CommandLineOperatorAction,
                servicesPlatform.SecretsDirectoryFilePathProviderAction);
            var visualStudioProjectFileOperatorActions = Instances.ServiceAction.AddVisualStudioProjectFileOperatorActions(
                dotnetOperatorActions.DotnetOperatorAction,
                servicesPlatform.FileNameOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);
            var visualStudioProjectFileReferencesProviderAction = Instances.ServiceAction.AddVisualStudioProjectFileReferencesProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction);
            var visualStudioSolutionFileOperatorActions = Instances.ServiceAction.AddVisualStudioSolutionFileOperatorActions(
                dotnetOperatorActions.DotnetOperatorAction,
                servicesPlatform.FileNameOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);

            var usingDirectivesFormatterActions = Instances.ServiceAction.AddUsingDirectivesFormatterActions();

            // Core competencies.
            // Level 00.
            var classContextProviderAction = Instances.ServiceAction.AddClassContextProviderAction();
            var methodContextProviderAction = Instances.ServiceAction.AddMethodContextProviderAction();
            var namespaceContextProviderAction = Instances.ServiceAction.AddNamespaceContextProviderAction();
            var repositoriesDirectoryPathProviderAction = Instances.ServiceAction.AddConstructorBasedRepositoriesDirectoryPathProviderAction(
                 @"C:\Code\DEV\Git\GitHub\SafetyCone");
            var repositorySolutionProjectFileSystemConventionsAction = Instances.ServiceAction.AddRepositorySolutionProjectFileSystemConventionsAction(
                servicesPlatform.StringlyTypedPathOperatorAction);

            // Level 01.
            var allRepositoryDirectoryPathsProviderAction = Instances.ServiceAction.AddAllRepositoryDirectoryPathsProviderAction(
                repositoriesDirectoryPathProviderAction);
            var compilationUnitContextProviderAction = Instances.ServiceAction.AddCompilationUnitContextProviderAction(
                usingDirectivesFormatterActions.UsingDirectivesFormatterAction);
            var directoryContextProviderAction = Instances.ServiceAction.AddDirectoryContextProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction);
            var fileContextProviderAction = Instances.ServiceAction.AddFileContextProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction);
            var gitHubOperatorServiceActions = Instances.ServiceAction.AddGitHubOperatorServiceActions(
                servicesPlatform.SecretsDirectoryFilePathProviderAction);

            // Level 02.
            var fileSystemContextProviderAggregationAction = Instances.ServiceAction.AddFileSystemContextProviderAggregationAction(
                directoryContextProviderAction,
                fileContextProviderAction);
            var gitOperatorServices = Instances.ServiceAction.AddGitOperatorServices(
                gitHubOperatorServiceActions.GitHubAuthenticationProviderAction,
                servicesPlatform.SecretsDirectoryFilePathProviderAction);
            var gitIgnoreTemplateFilePathProviderAction = Instances.ServiceAction.AddDefaultGitIgnoreTemplateFilePathProviderAction(
                servicesPlatform.ExecutableDirectoryPathProviderAction,
                servicesPlatform.StringlyTypedPathOperatorAction);
            var syntaxContextProviderAggregationAction = Instances.ServiceAction.AddSyntaxContextProviderAggregationAction(
                classContextProviderAction,
                compilationUnitContextProviderAction,
                methodContextProviderAction,
                namespaceContextProviderAction);

            // Level 03.
            var basicLocalRepositoryContextProviderAction = Instances.ServiceAction.AddBasicLocalRepositoryContextProviderAction(
                gitOperatorServices.GitOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);
            var basicSolutionContextProviderAction = Instances.ServiceAction.AddBasicSolutionContextProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);
            var localRepositoryContextProviderAction = Instances.ServiceAction.AddLocalRepositoryContextProviderAction(
                gitIgnoreTemplateFilePathProviderAction,
                repositoriesDirectoryPathProviderAction,
                gitOperatorServices.GitOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);
            var projectContextProviderAction = Instances.ServiceAction.AddProjectContextProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction);
            var remoteRepositoryContextProviderAction = Instances.ServiceAction.AddRemoteRepositoryContextProviderAction(
                gitHubOperatorServiceActions.GitHubOperatorAction);
            var solutionContextProviderAction = Instances.ServiceAction.AddSolutionContextProviderAction(
                projectRepositoryAction,
                servicesPlatform.StringlyTypedPathOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);

            // Operations-Dependencies.
            var createProjectForExistingSolutionAction = Instances.ServiceAction.AddCreateProjectForExistingSolutionAction(
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);
            var createSolutionInExistingRepositoryAction = Instances.ServiceAction.AddCreateSolutionInExistingRepositoryAction(
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);

            // Operations.
            var o001a_CreateNewRepositoryAction = Instances.ServiceAction.AddO001a_CreateNewRepositoryCoreAction(
                gitHubOperatorServiceActions.GitHubOperatorAction,
                gitIgnoreTemplateFilePathProviderAction,
                gitOperatorServices.GitOperatorAction,
                repositoriesDirectoryPathProviderAction);
            var o001_CreateNewRepositoryAction = Instances.ServiceAction.AddO001_CreateNewRepositoryAction(
                o001a_CreateNewRepositoryAction);
            var o002a_DeleteRepositoryCoreAction = Instances.ServiceAction.AddO002a_DeleteRepositoryCoreAction(
                gitHubOperatorServiceActions.GitHubOperatorAction,
                repositoriesDirectoryPathProviderAction);
            var o002_DeleteRepositoryAction = Instances.ServiceAction.AddO002_DeleteRepositoryAction(
                o002a_DeleteRepositoryCoreAction);
            var o003_CreateNewBasicTypesLibraryAction = Instances.ServiceAction.AddO003_CreateNewBasicTypesLibraryAction(
                gitHubOperatorServiceActions.GitHubOperatorAction,
                gitIgnoreTemplateFilePathProviderAction,
                gitOperatorServices.GitOperatorAction,
                repositoriesDirectoryPathProviderAction,
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);
            var o004_CreateSolutionInExistingRepositoryAction = Instances.ServiceAction.AddO004_CreateSolutionInExistingRepositoryAction(
                createSolutionInExistingRepositoryAction);
            var o005_CreateProjectForExistingSolutionAction = Instances.ServiceAction.AddO005_CreateProjectForExistingSolutionAction(
                createProjectForExistingSolutionAction);
            var o006_CreateNewProgramAsServiceSolutionCoreAction = Instances.ServiceAction.AddO006_CreateNewProgramAsServiceSolutionCoreAction(
                projectRepositoryAction,
                servicesPlatform.StringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);
            var o006_CreateNewProgramAsServiceSolutionAction = Instances.ServiceAction.AddO006_CreateNewProgramAsServiceSolutionAction(
                o006_CreateNewProgramAsServiceSolutionCoreAction);
            var o006a_ModifyHostStartupForA0003Action = Instances.ServiceAction.AddO006a_ModifyHostStartupForA0003Action(
                projectRepositoryAction,
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);
            var o007_CreateNewProgramAsServiceRepositoryAction = Instances.ServiceAction.AddO007_CreateNewProgramAsServiceRepositoryAction(
                o001a_CreateNewRepositoryAction,
                o006_CreateNewProgramAsServiceSolutionCoreAction);

            // 100's - Level 01.
            var o100A_CreateNewRepositoryOnlyAction = Instances.ServiceAction.AddO100A_CreateNewRepositoryOnlyAction(
                localRepositoryContextProviderAction,
                remoteRepositoryContextProviderAction);
            var o100B_InitialSetupWithCheckInAction = Instances.ServiceAction.AddO100B_InitialSetupWithCheckInAction(
                localRepositoryContextProviderAction);
            var o101_DeleteNewRepositoryCoreAction = Instances.ServiceAction.AddO101_DeleteNewRepositoryCoreAction(
                localRepositoryContextProviderAction,
                remoteRepositoryContextProviderAction);
            var o102A_CreateSolutionOnlyAction = Instances.ServiceAction.AddO102A_CreateSolutionOnlyAction(
                basicSolutionContextProviderAction);
            var o102B_ModifyInitialSolutionAction = Instances.ServiceAction.AddO102B_ModifyInitialSolutionAction(
                solutionContextProviderAction);
            var o103A_CreateAndAddProjectOnlyAction = Instances.ServiceAction.AddO103A_CreateAndAddProjectOnlyAction(
                projectContextProviderAction,
                solutionContextProviderAction);
            var o103B_ModifyInitialProjectForProjectTypeAction = Instances.ServiceAction.AddO103B_ModifyInitialProjectForProjectTypeAction(
                fileSystemContextProviderAggregationAction,
                projectContextProviderAction,
                syntaxContextProviderAggregationAction);
            var o104_DeleteProjectFromSolutionAction = Instances.ServiceAction.AddO104_DeleteProjectFromSolutionAction(
                projectContextProviderAction,
                basicSolutionContextProviderAction);

            // 100's - Level 02.
            var o100_CreateNewRepositoryCoreAction = Instances.ServiceAction.AddO100_CreateNewRepositoryCoreAction(
                o100A_CreateNewRepositoryOnlyAction,
                o100B_InitialSetupWithCheckInAction);
            var o101_DeleteNewRepositoryAction = Instances.ServiceAction.AddO101_DeleteNewRepositoryAction(
                o101_DeleteNewRepositoryCoreAction);
            var o102_CreateSolutionInExistingRespositoryCoreAction = Instances.ServiceAction.AddO102_CreateSolutionInExistingRespositoryCoreAction(
                repositoriesDirectoryPathProviderAction,
                repositorySolutionProjectFileSystemConventionsAction,
                servicesPlatform.StringlyTypedPathOperatorAction,
                o102A_CreateSolutionOnlyAction,
                o102B_ModifyInitialSolutionAction);
            var o103_CreateProjectForExistingSolutionCoreAction = Instances.ServiceAction.AddO103_CreateProjectForExistingSolutionCoreAction(
                o103A_CreateAndAddProjectOnlyAction,
                o103B_ModifyInitialProjectForProjectTypeAction);

            // 100's - Level 03.
            var o100_CreateNewRepositoryAction = Instances.ServiceAction.AddO100_CreateNewRepositoryAction(
                o100_CreateNewRepositoryCoreAction);
            var o102_CreateSolutionInExistingRespositoryAction = Instances.ServiceAction.AddO102_CreateSolutionInExistingRespositoryAction(
                o102_CreateSolutionInExistingRespositoryCoreAction);
            var o103_CreateProjectForExistingSolutionAction = Instances.ServiceAction.AddO103_CreateProjectForExistingSolutionAction(
                o103_CreateProjectForExistingSolutionCoreAction);

            // 900's.
            var o900_CreateAllRepositoryAllProjectsSolutionFilesAction = Instances.ServiceAction.AddO900_CreateAllRepositoryAllProjectsSolutionFilesAction(
                allRepositoryDirectoryPathsProviderAction,
                localRepositoryContextProviderAction,
                solutionContextProviderAction);

            // Misc.
            var o999_ScratchAction = Instances.ServiceAction.AddO999_ScratchAction(
                fileSystemContextProviderAggregationAction,
                basicLocalRepositoryContextProviderAction,
                projectContextProviderAction,
                remoteRepositoryContextProviderAction,
                repositoriesDirectoryPathProviderAction,
                basicSolutionContextProviderAction);

            // Run.
            services.MarkAsServiceCollectonConfigurationStatement()
                .Run(servicesPlatform.ConfigurationAuditSerializerAction)
                .Run(servicesPlatform.ServiceCollectionAuditSerializerAction)
                // Operations.
                .Run(o001_CreateNewRepositoryAction)
                .Run(o002_DeleteRepositoryAction)
                .Run(o003_CreateNewBasicTypesLibraryAction)
                .Run(o004_CreateSolutionInExistingRepositoryAction)
                .Run(o005_CreateProjectForExistingSolutionAction)
                .Run(o006_CreateNewProgramAsServiceSolutionAction)
                .Run(o006a_ModifyHostStartupForA0003Action)
                .Run(o007_CreateNewProgramAsServiceRepositoryAction)
                // Operations - 100's.
                .Run(o100_CreateNewRepositoryAction)
                .Run(o101_DeleteNewRepositoryAction)
                .Run(o102_CreateSolutionInExistingRespositoryAction)
                .Run(o103_CreateProjectForExistingSolutionAction)
                .Run(o104_DeleteProjectFromSolutionAction)
                // Operations - 900's.
                .Run(o900_CreateAllRepositoryAllProjectsSolutionFilesAction)
                .Run(o999_ScratchAction)
                ;

            return Task.CompletedTask;
        }

        protected override Task FillRequiredServiceActions(IRequiredServiceActionAggregation requiredServiceActions)
        {
            // Do nothing since none are required.

            return Task.CompletedTask;
        }
    }
}
