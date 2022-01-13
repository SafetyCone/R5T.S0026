using System;

using R5T.T0045;

using Instances = R5T.S0026.Library.Instances;


namespace System
{
    public static class ICodeFileGeneratorExtensions
    {
        public static void CreateHostStartup(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var instancesCompilationUnit = Instances.CompilationUnitGenerator.CreateHostStartup(
                namespaceName);

            instancesCompilationUnit.WriteTo(filePath);
        }

        public static void CreateIServiceActionExtensions_Initial(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var instancesCompilationUnit = Instances.CompilationUnitGenerator.CreateIServiceActionExtensions_Initial(
                namespaceName);

            instancesCompilationUnit.WriteTo(filePath);
        }

        public static void CreateIServiceCollectionExtensions_Initial(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var instancesCompilationUnit = Instances.CompilationUnitGenerator.CreateIServiceCollectionExtensions_Initial(
                namespaceName);

            instancesCompilationUnit.WriteTo(filePath);
        }
    }
}
