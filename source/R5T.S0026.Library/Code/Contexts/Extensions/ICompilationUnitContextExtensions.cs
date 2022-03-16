using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.S0026.Library;


namespace System
{
    public static class ICompilationUnitContextExtensions
    {
        public static Task<CompilationUnitSyntax> InAcquiredNamespaceContext(this ICompilationUnitContext _,
            INamespaceContextProvider namespaceContextProvider,
            CompilationUnitSyntax compilationUnit,
            Func<CompilationUnitSyntax, WasFound<NamespaceDeclarationSyntax>> namespaceSelector,
            Func<CompilationUnitSyntax, INamespaceContext, Task<CompilationUnitSyntax>> namespaceContextAction,
            Func<NamespaceDeclarationSyntax> namespaceConstructor)
        {
            return namespaceContextProvider.InAcquiredNamespaceContext(
                compilationUnit,
                namespaceSelector,
                namespaceContextAction,
                namespaceConstructor);
        }

        public static Task<CompilationUnitSyntax> InAcquiredNamespaceContext(this ICompilationUnitContext compilationUnitContext,
            INamespaceContextProvider namespaceContextProvider,
            CompilationUnitSyntax compilationUnit,
            string namespaceName,
            Func<CompilationUnitSyntax, INamespaceContext, Task<CompilationUnitSyntax>> namespaceContextAction)
        {
            return namespaceContextProvider.InAcquiredNamespaceContext(
                compilationUnit,
                namespaceName,
                namespaceContextAction);
        }
    }
}
