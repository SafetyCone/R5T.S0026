using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
using R5T.D0084.D002.I001;
using R5T.D0088.I0002;
using R5T.D0101.I0001;
using R5T.D0101.I001;
using R5T.D0111.D001.I001;
using R5T.O0001;
using R5T.T0063;

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

            // Core competencies.
            // Level 0.
            var repositoriesDirectoryPathProviderAction = Instances.ServiceAction.AddConstructorBasedRepositoriesDirectoryPathProviderAction(
                 @"C:\Code\DEV\Git\GitHub\SafetyCone");

            // Level 01.
            var gitHubOperatorServiceActions = Instances.ServiceAction.AddGitHubOperatorServiceActions(
                servicesPlatform.SecretsDirectoryFilePathProviderAction);

            // Level 02.
            var gitOperatorServices = Instances.ServiceAction.AddGitOperatorServices(
                gitHubOperatorServiceActions.GitHubAuthenticationProviderAction,
                servicesPlatform.SecretsDirectoryFilePathProviderAction);

            var gitIgnoreTemplateFilePathProviderAction = Instances.ServiceAction.AddDefaultGitIgnoreTemplateFilePathProviderAction(
                servicesPlatform.ExecutableDirectoryPathProviderAction,
                servicesPlatform.StringlyTypedPathOperatorAction);

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

            // Misc.
            var o999_ScratchAction = Instances.ServiceAction.AddO999_ScratchAction();

            // Run.
            services.MarkAsServiceCollectonConfigurationStatement()
                .Run(servicesPlatform.ConfigurationAuditSerializerAction)
                .Run(servicesPlatform.ServiceCollectionAuditSerializerAction)
                // Operations.
                .Run(o999_ScratchAction)
                .Run(o001_CreateNewRepositoryAction)
                .Run(o002_DeleteRepositoryAction)
                .Run(o003_CreateNewBasicTypesLibraryAction)
                .Run(o004_CreateSolutionInExistingRepositoryAction)
                .Run(o005_CreateProjectForExistingSolutionAction)
                .Run(o006_CreateNewProgramAsServiceSolutionAction)
                .Run(o006a_ModifyHostStartupForA0003Action)
                .Run(o007_CreateNewProgramAsServiceRepositoryAction)
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
