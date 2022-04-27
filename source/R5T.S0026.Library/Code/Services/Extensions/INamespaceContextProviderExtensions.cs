using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.T0126;

using R5T.S0026.Library;


namespace System
{
    public static class INamespaceContextProviderExtensions
    {
        public static async Task<CompilationUnitSyntax> InAcquiredNamespaceContext(this INamespaceContextProvider namespaceContextProvider,
            CompilationUnitSyntax compilationUnit,
            Func<CompilationUnitSyntax, WasFound<NamespaceDeclarationSyntax>> namespaceSelector,
            Func<CompilationUnitSyntax, INamespaceContext, Task<CompilationUnitSyntax>> namespaceContextAction,
            Func<NamespaceDeclarationSyntax> namespaceConstructor)
        {
            var outputCompilationUnit = compilationUnit;

            var namespaceWasFound = namespaceSelector(outputCompilationUnit);

            var unannotatedNamespace = namespaceWasFound
                ? namespaceWasFound.Result
                : namespaceConstructor()
                ;

            var annotatedNamespace = unannotatedNamespace.Annotate(out var annotation);

            // Make sure the annotated namespace exists in the compilation unit.
            if (namespaceWasFound)
            {
                outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(unannotatedNamespace, annotatedNamespace);
            }
            else
            {
                // Add the namspace.
                outputCompilationUnit = outputCompilationUnit.AddNamespace(annotatedNamespace);
            }

            var namespaceAnnotation = NamespaceAnnotation.From(annotation);

            var namespaceContext = namespaceContextProvider.GetNamespaceContext(namespaceAnnotation);

            outputCompilationUnit = await namespaceContextAction(
                outputCompilationUnit,
                namespaceContext);

            return outputCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> InAcquiredNamespaceContext(this INamespaceContextProvider namespaceContextProvider,
            CompilationUnitSyntax compilationUnit,
            string namespaceName,
            Func<CompilationUnitSyntax, INamespaceContext, Task<CompilationUnitSyntax>> namespaceContextAction)
        {
            var outputCompilationUnit = await namespaceContextProvider.InAcquiredNamespaceContext(
                compilationUnit,
                xCompilationUnit =>
                {
                    var namespaceWasFound = xCompilationUnit.HasNamespace(namespaceName);
                    return namespaceWasFound;
                },
                namespaceContextAction,
                () =>
                {
                    var @namespace = Instances.NamespaceGenerator.GetNewNamespace2(namespaceName);
                    return @namespace;
                });

            return outputCompilationUnit;
        }
    }
}


namespace R5T.S0026.Library
{
    public static class INamespaceContextProviderExtensions
    {
        // Will use parameter when namespace-related services are available.
#pragma warning disable IDE0060 // Remove unused parameter
        public static NamespaceContext GetNamespaceContext(this INamespaceContextProvider namespaceContextProvider,
#pragma warning restore IDE0060 // Remove unused parameter
            NamespaceAnnotation namespaceDeclarationAnnotation)
        {
            var output = new NamespaceContext
            {
                NamespaceAnnotation = namespaceDeclarationAnnotation,
            };

            return output;
        }
    }
}