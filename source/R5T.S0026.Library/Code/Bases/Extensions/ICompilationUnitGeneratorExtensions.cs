using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.S0026.Library.Instances;


namespace System
{
    public static class ICompilationUnitGeneratorExtensions
    {
        public static CompilationUnitSyntax CreateHostStartup(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    // System namespace already added.
                    // Add the namespace for the HostStartupBase type.
                    xNamespaceNames.Add(
                        Instances.NamespaceName.Values().R5T_D0088_I0002());

                    var hostStartupClass = Instances.ClassGenerator.CreateHostStartup();

                    var outputNamespace = xNamespace.AddClass(hostStartupClass);
                    return outputNamespace;
                });

            return output;
        }

        public static CompilationUnitSyntax CreateIServiceActionExtensions_Initial(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    // System namespace already added.
                    // Add the namespace for the HostStartupBase type.
                    xNamespaceNames.AddRange(
                        Instances.NamespaceName.Values().R5T_T0062(),
                        Instances.NamespaceName.Values().R5T_T0063());

                    var iServiceActionExtensionsClass = Instances.ClassGenerator.CreateIServiceActionExtensions_Initial();

                    var outputNamespace = xNamespace.AddClass(iServiceActionExtensionsClass);
                    return outputNamespace;
                });

            return output;
        }

        public static CompilationUnitSyntax CreateIServiceCollectionExtensions_Initial(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    // System namespace already added.
                    // Add the namespace for the HostStartupBase type.
                    xNamespaceNames.Add(
                        Instances.NamespaceName.Values().R5T_D0088_I0002());

                    var iServiceCollectionExtensionsClass = Instances.ClassGenerator.CreateIServiceCollectionExtensions_Initial();

                    var outputNamespace = xNamespace.AddClass(iServiceCollectionExtensionsClass);
                    return outputNamespace;
                });

            return output;
        }
    }
}
