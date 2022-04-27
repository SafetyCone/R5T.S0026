using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.T0126;

using R5T.S0026.Library;


namespace System
{
    public static class IClassContextProviderExtensions
    {
        public static async Task<CompilationUnitSyntax> InAcquiredClassContext(this IClassContextProvider classContextProvider,
            CompilationUnitSyntax compilationUnit,
            INamespaceContext namespaceContext,
            Func<NamespaceDeclarationSyntax, WasFound<ClassDeclarationSyntax>> classSelector,
            Func<CompilationUnitSyntax, IClassContext, Task<CompilationUnitSyntax>> classContextAction,
            Func<ClassDeclarationSyntax> classConstructor)
        {
            var outputCompilationUnit = compilationUnit;

            var @namespace = namespaceContext.NamespaceAnnotation.GetAnnotatedNode_Typed(outputCompilationUnit);

            var classWasFound = classSelector(@namespace);

            var unannotatedClass = classWasFound
                ? classWasFound.Result
                : classConstructor()
                ;

            var annotatedClass = unannotatedClass.Annotate(out var annotation);

            // Make sure the annotated class exists in the compilation unit.
            if (classWasFound)
            {
                outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(unannotatedClass, annotatedClass);
            }
            else
            {
                var newNamespace = @namespace.AddClassWithSurroundingSpacingAdjustment(annotatedClass);

                outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(@namespace, newNamespace);
            }

            var classAnnotation = ClassAnnotation.From(annotation);

            var classContext = classContextProvider.GetClassContext(classAnnotation);

            outputCompilationUnit = await classContextAction(
                outputCompilationUnit,
                classContext);

            return outputCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> InAcquiredClassContext(this IClassContextProvider classContextProvider,
            CompilationUnitSyntax compilationUnit,
            INamespaceContext namespaceContext,
            string className,
            Func<CompilationUnitSyntax, IClassContext, Task<CompilationUnitSyntax>> classContextAction,
            Func<ClassDeclarationSyntax> classConstructor)
        {
            var output = await classContextProvider.InAcquiredClassContext(
                compilationUnit,
                namespaceContext,
                xNamespace =>
                {
                    var classWasFound = xNamespace.HasClass(className);
                    return classWasFound;
                },
                classContextAction,
                classConstructor);

            return output;
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IClassContextProviderExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter
        public static ClassContext GetClassContext(this IClassContextProvider classContextProvider,
#pragma warning restore IDE0060 // Remove unused parameter
            ClassAnnotation classAnnotation)
        {
            var output = new ClassContext
            {
                ClassAnnotation = classAnnotation,
            };

            return output;
        }

        public static ClassContextHierarchy GetClassContextHierarchy(this IClassContextProvider classContextProvider,
            ClassAnnotation classAnnotation,
            INamespaceContext namespaceContext)
        {
            var classContext = classContextProvider.GetClassContext(
                classAnnotation);

            var output = new ClassContextHierarchy
            {
                ClassContext = classContext,
                NamespaceContext = namespaceContext,
            };

            return output;
        }
    }
}
