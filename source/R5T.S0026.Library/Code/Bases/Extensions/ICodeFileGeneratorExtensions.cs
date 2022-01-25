using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0045;

using R5T.S0026.Library;

using Instances = R5T.S0026.Library.Instances;


namespace System
{
    public static class ICodeFileGeneratorExtensions
    {
        public static async Task CreateHostStartup(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var compilationUnit = Instances.CompilationUnitGenerator.NewCompilationUnit();

            compilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_Initial(compilationUnit, namespaceName);
            compilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_AddA0003(compilationUnit);
            compilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_AddSerializeConfigurationAudit(compilationUnit);
            compilationUnit = await Instances.CompilationUnitOperator.ModifyHostStartup_AddSerializeServiceCollectionAudit(compilationUnit);

            await compilationUnit.WriteTo(filePath);
        }

        public static void CreateIServiceActionExtensions_Initial(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var instancesCompilationUnit = Instances.CompilationUnitGenerator.CreateIServiceActionExtensions_Initial(
                namespaceName);

            instancesCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateIServiceCollectionExtensions_Initial(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var instancesCompilationUnit = Instances.CompilationUnitGenerator.CreateIServiceCollectionExtensions_Initial(
                namespaceName);

            instancesCompilationUnit.WriteToSynchronous(filePath);
        }

        public static async Task InCreationContext(this ICodeFileGenerator _,
            string solutionFilePath,
            string projectFilePath,
            string codeFilePath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator,
            Func<ICodeFileCreationContext, Task<CompilationUnitSyntax>> codeFileCreationContextAction = default)
        {
            await Instances.CodeFileOperator.InCreationContext(
                solutionFilePath,
                projectFilePath,
                codeFilePath,
                visualStudioProjectFileOperator,
                visualStudioProjectFileReferencesProvider,
                visualStudioSolutionFileOperator,
                codeFileCreationContextAction);
        }
    }
}
