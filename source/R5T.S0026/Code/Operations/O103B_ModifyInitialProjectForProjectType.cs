using System;
using System.Threading.Tasks;

using R5T.D0079;
using R5T.T0020;

using R5T.Magyar;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
    public class O103B_ModifyInitialProjectForProjectType : IOperation
    {
        #region Static

        private static async Task ModifyInitialProject(IProjectContext projectContext,
            string projectDescription)
        {
            // Add Project Plan file.
            await projectContext.InNewChildTextFileContext(
                Instances.FileName.ProjectPlan(),
                async textWriterContext =>
                {
                    var projectName = projectContext.GetProjectName();

                    var line = $"{projectName} - {projectDescription}";

                    await textWriterContext.TextWriter.WriteLineAsync(line);
                });
        }

        #endregion


        private IFileSystemContextProviderAggregation FileSystemContextProviderAggregation { get; }
        private IProjectContextProvider ProjectContextProvider { get; }
        private ISyntaxContextProviderAggregation SyntaxContextProviderAggregation { get; }


        public O103B_ModifyInitialProjectForProjectType(
            IFileSystemContextProviderAggregation fileSystemContextProviderAggregation,
            IProjectContextProvider projectContextProvider,
            ISyntaxContextProviderAggregation syntaxContextProviderAggregation)
        {
            this.FileSystemContextProviderAggregation = fileSystemContextProviderAggregation;
            this.ProjectContextProvider = projectContextProvider;
            this.SyntaxContextProviderAggregation = syntaxContextProviderAggregation;
        }

        public async Task Run(
            string projectFilePath,
            VisualStudioProjectType projectType,
            string projectDescription)
        {
            await this.ProjectContextProvider.InProjectContext(
                projectFilePath,
                async projectContext =>
                {
                    await O103B_ModifyInitialProjectForProjectType.ModifyInitialProject(projectContext,
                        projectDescription);

                    switch (projectType)
                    {
                        case VisualStudioProjectType.ClassLibrary:
                            break;

                        case VisualStudioProjectType.Console:
                            await this.ModifyInitialConsoleProject(projectContext);
                            break;

                        default:
                            throw EnumerationHelper.SwitchDefaultCaseException(projectType);
                    }
                });
        }

        private async Task ModifyInitialConsoleProject(IProjectContext projectContext)
        {
            // Delete initial Program file.
            projectContext.DeleteChildFileOnlyIfExists(Instances.CodeFileName.Program());

            // Add Program file in Code directory.
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
                            var defaultNamespaceName = projectContext.GetDefaultNamespaceName();

                            var programCompilationUnit = Instances.CompilationUnitGenerator.GetDefaultProgram(
                                defaultNamespaceName);

                            await programCompilationUnit.WriteTo(programCodeFileContext.FilePath);

                            //await this.SyntaxContextProviderAggregation.CompilationUnitContextProvider.InAcquiredCompilationUnitContext(
                            //    programCodeFileContext,
                            //    async (compilationUnitContext, compilationUnit) =>
                            //    {
                            //        var outputCompilationUnit = compilationUnit;

                            //        // Add usings.
                            //        outputCompilationUnit = await compilationUnitContext.UsingDirectivesFormatter.AddAndFormatNamespaceNames(
                            //            outputCompilationUnit,
                            //            new[]
                            //            {
                            //                Instances.NamespaceName.System(),
                            //            },
                            //            defaultNamespaceName);

                            //        outputCompilationUnit = await this.SyntaxContextProviderAggregation.NamespaceContextProvider.InAcquiredNamespaceContext(
                            //            outputCompilationUnit,
                            //            defaultNamespaceName,
                            //            async (namespaceCompilationUnit, namespaceContext) =>
                            //            {
                            //                var outputNamespaceCompilationUnit = namespaceCompilationUnit;

                            //                outputNamespaceCompilationUnit = await this.SyntaxContextProviderAggregation.ClassContextProvider.InAcquiredClassContext(
                            //                    outputNamespaceCompilationUnit,
                            //                    namespaceContext,
                            //                    Instances.ClassName.Program(),
                            //                    async (classCompilationUnit, classContext) =>
                            //                    {
                            //                        var outputClassCompilationUnit = classCompilationUnit;

                            //                        outputClassCompilationUnit = await this.SyntaxContextProviderAggregation.MethodContextProvider.InAcquiredMethodContext(
                            //                            outputClassCompilationUnit,
                            //                            classContext,
                            //                            Instances.MethodName.Main(),
                            //                            async (methodCompilationUnit, methodContext) =>
                            //                            {
                            //                                var outputMethodCompilationUnit = methodCompilationUnit;

                            //                                // Do nothing.s

                            //                                return outputMethodCompilationUnit;
                            //                            },
                            //                            () =>
                            //                            {
                            //                                var mainMethod = Instances.MethodGenerator.GetDefaultMain();
                            //                                return mainMethod;
                            //                            });


                            //                        return outputClassCompilationUnit;
                            //                    },
                            //                    () =>
                            //                    {
                            //                        // Create an empty Program class.
                            //                        var outputProgramClass = Instances.ClassGenerator.GetClass(Instances.ClassName.Program())
                            //                            .IndentBlock(Instances.Indentation.Class())
                            //                            ;

                            //                        return outputProgramClass;
                            //                    });


                            //                return outputNamespaceCompilationUnit;
                            //            });

                            //        return outputCompilationUnit;
                            //    });
                        });
                });   
        }
    }
}
