using System;
using System.Threading.Tasks;

using R5T.D0084.D002;
using R5T.T0020;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
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


        #endregion


        private ICompilationUnitContextProvider CompilationUnitContextProvider { get; }
        private IFileSystemContextProviderAggregation FileSystemContextProviderAggregation { get; }
        private ILocalRepositoryContextProvider LocalRepositoryContextProvider { get; }
        private IProjectContextProvider ProjectContextProvider { get; }
        private IRemoteRepositoryContextProvider RemoteRepositoryContextProvider { get; }
        private IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }
        private IBasicSolutionContextProvider SolutionContextProvider { get; }


        public O999_Scratch(
            IFileSystemContextProviderAggregation fileSystemContextProviderAggregation,
            ILocalRepositoryContextProvider localRepositoryContextProvider,
            IProjectContextProvider projectContextProvider,
            IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider,
            IBasicSolutionContextProvider solutionContextProvider)
        {
            this.FileSystemContextProviderAggregation = fileSystemContextProviderAggregation;
            this.LocalRepositoryContextProvider = localRepositoryContextProvider;
            this.ProjectContextProvider = projectContextProvider;
            this.RemoteRepositoryContextProvider = remoteRepositoryContextProvider;
            this.RepositoriesDirectoryPathProvider = repositoriesDirectoryPathProvider;
            this.SolutionContextProvider = solutionContextProvider;
        }

        public async Task Run()
        {
            await this.TryRemoteRepositoryContext();

            //await O999_Scratch.CreateProgramFile();
            //await O999_Scratch.CreateHostStartupFile();
            //O999_Scratch.WhatIsMultipleStatementParseType();

            //return Task.CompletedTask;
        }

        private async Task ModifyProjectFiles()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing\source\R5T.Testing\R5T.Testing.csproj";

            // Run.
            var projectName = Instances.ProjectPathsOperator.GetProjectName(projectFilePath);
            var defaultNamespaceName = Instances.ProjectNameOperator.GetDefaultNamespaceNameFromProjectName(projectName);

            await this.ProjectContextProvider.InProjectContext(
                projectFilePath,
                async projectContext =>
                {
                    projectContext.InProjectDirectoryContextSynchronous(
                        projectDirectoryContext =>
                        {
                            projectDirectoryContext.DeleteChildFileOnlyIfExists(Instances.CodeFileName.Program());
                        });

                    await this.FileSystemContextProviderAggregation.DirectoryContextProvider.InAcquiredChildDirectoryContext(
                        projectContext,
                        Instances.CodeDirectoryName.Code(),
                        async codeDirectoryContext =>
                        {
                            await this.FileSystemContextProviderAggregation.FileContextProvider.InChildFileContext(
                                codeDirectoryContext,
                                Instances.CodeFileName.Program(),
                                async programCodeFileContext =>
                                {
                                    await this.CompilationUnitContextProvider.InAcquiredCompilationUnitContext(
                                        programCodeFileContext,
                                        async (compilationUnitContext, compilationUnit) =>
                                        {
                                            var outputCompilationUnit = compilationUnit;

                                            // Add usings.
                                            outputCompilationUnit = await compilationUnitContext.UsingDirectivesFormatter.AddAndFormatNamespaceNames(
                                                outputCompilationUnit,
                                                new[]
                                                {
                                                    Instances.NamespaceName.System(),
                                                },
                                                defaultNamespaceName);

                                            return outputCompilationUnit;
                                        });
                                });
                        });
                });
        }

        private async Task TryRemoteRepositoryContext()
        {
            //var repositoriesDirectoryPath = await this.RepositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

            await this.RemoteRepositoryContextProvider.InAcquiredRemoteRepositoryContext(
                "R5T.Testing",
                async remoteRepositoryContext =>
                {
                    // Yes, it exists.
                    //var exists = await remoteRepositoryContext.Exists();

                    await this.LocalRepositoryContextProvider.InClonedLocalRepositoryContext(
                        remoteRepositoryContext,
                        async localRepositoryContext =>
                        {
                            // Yes, the local repository is a repository.
                            //var isRepository = await localRepositoryContext.IsRepository();

                            await this.SolutionContextProvider.InAcquiredSolutionContext(
                                "R5T.Testing.Private",
                                localRepositoryContext,
                                async solutionContext =>
                                {
                                    // Yes, the solution file exists.
                                    //var exists = solutionContext.FileExists();

                                    await this.ProjectContextProvider.InAcquiredProjectContext(
                                        "R5T.Testing",
                                        solutionContext,
                                        projectContext =>
                                        {
                                            var exists = projectContext.FileExists();

                                            return Task.CompletedTask;
                                        },
                                        async initialProjectContext =>
                                        {
                                            var projectName = Instances.ProjectPathsOperator.GetProjectName(initialProjectContext.FilePath);

                                            await initialProjectContext.VisualStudioProjectFileOperator.CreateConsole(
                                                projectName,
                                                initialProjectContext.DirectoryPath);

                                            await solutionContext.VisualStudioSolutionFileOperator.AddProjectReference(
                                                solutionContext.FilePath,
                                                initialProjectContext.FilePath);
                                        });
                                });
                        });
                },
                repositorySpecification =>
                {
                    repositorySpecification.Description = "Testing repository.";
                    repositorySpecification.IsPrivate(true);

                    return Task.FromResult(repositorySpecification);
                });

        }

#pragma warning restore IDE0051 // Remove unused private members
    }
}
