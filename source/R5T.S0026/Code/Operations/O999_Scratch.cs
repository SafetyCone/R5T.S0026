using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.S0026.Library;


namespace R5T.S0026
{
    public class O999_Scratch : IActionOperation
    {
        #region Static

#pragma warning disable IDE0051 // Remove unused private members

        private static async Task CreateProgramFile()
        {
            var filePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\Test\Code\Program.cs";
            var namespaceName = "Test";

            var programCompilationUnit = Instances.CompilationUnitGenerator.NewCompilationUnit();

            programCompilationUnit = await Instances.CompilationUnitOperator.ModifyProgramAsAService_Initial(programCompilationUnit, namespaceName);

            await programCompilationUnit.WriteTo(filePath);

            programCompilationUnit = await Instances.CompilationUnitOperator.ModifyProgramAsAService_AddSerializeConfigurationAudit(programCompilationUnit);

            await programCompilationUnit.WriteTo(filePath);

            programCompilationUnit = await Instances.CompilationUnitOperator.ModifyProgramAsAService_AddSerializeServiceCollectionAudit(programCompilationUnit);

            await programCompilationUnit.WriteTo(filePath);
        }

        private static async Task CreateHostStartupFile()
        {
            var filePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\Test\Code\HostStartup.cs";
            var namespaceName = "Test";

            var hostStartupCompilationUnit = Instances.CompilationUnitGenerator.NewCompilationUnit();
            
            hostStartupCompilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_Initial(hostStartupCompilationUnit, namespaceName);

            await hostStartupCompilationUnit.WriteTo(filePath);

            hostStartupCompilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_AddA0003(hostStartupCompilationUnit);

            await hostStartupCompilationUnit.WriteTo(filePath);

            hostStartupCompilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_AddSerializeConfigurationAudit(hostStartupCompilationUnit);

            await hostStartupCompilationUnit.WriteTo(filePath);

            hostStartupCompilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_AddSerializeServiceCollectionAudit(hostStartupCompilationUnit);

            await hostStartupCompilationUnit.WriteTo(filePath);
        }

        private static void WhatIsMultipleStatementParseType()
        {
            var statements = @"
var executionSynchronicityProviderAction = Instances.ServiceAction.AddConstructorBasedExecutionSynchronicityProviderAction(Synchronicity.Synchronous);
var organizationProviderAction = Instances.ServiceAction.AddOrganizationProviderAction(); // Rivet organization.
var rootOutputDirectoryPathProviderAction = Instances.ServiceAction.AddConstructorBasedRootOutputDirectoryPathProviderAction(@""C:\Temp\Output"");
";

            Instances.SyntaxFactory.ParseStatements(statements);
            //var syntax = Instances.SyntaxFactory.ParseStatements(statements);
        }

#pragma warning restore IDE0051 // Remove unused private members

        #endregion


        public async Task Run()
        {
            //await O999_Scratch.CreateProgramFile();
            await O999_Scratch.CreateHostStartupFile();
            //O999_Scratch.WhatIsMultipleStatementParseType();

            //return Task.CompletedTask;
        }
    }
}
