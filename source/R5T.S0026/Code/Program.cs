using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.D0078;
using R5T.D0088;
using R5T.D0090;


namespace R5T.S0026
{
    public class Program : ProgramAsAServiceBase
    {
        #region Static

        static async Task Main()
        {
            //OverridableProcessStartTimeProvider.Override("20211214-163052");
            //OverridableProcessStartTimeProvider.DoNotOverride();

            await Instances.Host.NewBuilder()
                .UseProgramAsAService<Program, T0075.IHostBuilder>()
                .UseHostStartup<HostStartup, T0075.IHostBuilder>(Instances.ServiceAction.AddHostStartupAction())
                .Build()
                .SerializeConfigurationAudit()
                .SerializeServiceCollectionAudit()
                .RunAsync();
        }

        #endregion


        public Program(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected override Task ServiceMain(CancellationToken stoppingToken)
        {
            //return this.Scratch();
            return this.RunOperation();
        }

        private async Task RunOperation()
        {
            //await this.ServiceProvider.Run<O104_DeleteProjectFromSolution>();
            //await this.ServiceProvider.Run<O103_CreateProjectForExistingSolution>();
            //await this.ServiceProvider.Run<O102_CreateSolutionInExistingRespository>();
            //await this.ServiceProvider.Run<O101_DeleteNewRepository>();
            //await this.ServiceProvider.Run<O100_CreateNewRepository>();

            await this.ServiceProvider.Run<O007_CreateNewProgramAsServiceRepository>();
            //await this.ServiceProvider.Run<O006a_ModifyHostStartupForA0003>();
            //await this.ServiceProvider.Run<O006_CreateNewProgramAsServiceSolution>();
            //await this.ServiceProvider.Run<O005_CreateProjectForExistingSolution>();
            //await this.ServiceProvider.Run<O004_CreateSolutionInExistingRepository>();
            //await this.ServiceProvider.Run<O003_CreateNewBasicTypesLibrary>();
            //await this.ServiceProvider.Run<O002_DeleteRepository>();
            //await this.ServiceProvider.Run<O001_CreateNewRepository>();

            //await this.ServiceProvider.Run<O999_Scratch>();
        }

        private async Task Scratch()
        {
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing2.Private\source\R5T.Testing2\R5T.Testing2.csproj";

            var operation = this.ServiceProvider.GetRequiredService<O103B_ModifyInitialProjectForProjectType>();

            await operation.Run(
                projectFilePath,
                D0079.VisualStudioProjectType.Console,
                "Testing project.");
        }
    }
}