using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.T0126;

using R5T.S0026.Library;


namespace System
{
    public static class IMethodContextProviderExtensions
    {
        public static async Task<CompilationUnitSyntax> InAcquiredMethodContext(this IMethodContextProvider methodContextProvider,
            CompilationUnitSyntax compilationUnit,
            IClassContext classContext,
            Func<ClassDeclarationSyntax, WasFound<MethodDeclarationSyntax>> methodSelector,
            Func<CompilationUnitSyntax, IMethodContext, Task<CompilationUnitSyntax>> methodContextAction,
            Func<MethodDeclarationSyntax> methodConstructor)
        {
            var outputCompilationUnit = compilationUnit;

            var @class = classContext.ClassAnnotation.GetAnnotatedNode_Typed(outputCompilationUnit);

            var methodWasFound = methodSelector(@class);

            var unannotatedMethod = methodWasFound
                ? methodWasFound.Result
                : methodConstructor()
                ;

            var annotatedMethod = unannotatedMethod.Annotate(out var annotation);

            // Make sure the annotated method exists in the compilation unit.
            if(methodWasFound)
            {
                outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(unannotatedMethod, annotatedMethod);
            }
            else
            {
                var newClass = @class.AddMethod(annotatedMethod);

                outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(@class, newClass);
            }

            var methodAnnotation = MethodDeclarationAnnotation.From(annotation);

            var methodContext = methodContextProvider.GetMethodContext(methodAnnotation);

            outputCompilationUnit = await methodContextAction(
                outputCompilationUnit,
                methodContext);

            return outputCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> InAcquiredMethodContext(this IMethodContextProvider methodContextProvider,
            CompilationUnitSyntax compilationUnit,
            IClassContext classContext,
            string methodName,
            Func<CompilationUnitSyntax, IMethodContext, Task<CompilationUnitSyntax>> methodContextAction,
            Func<MethodDeclarationSyntax> methodConstructor)
        {
            var output = await methodContextProvider.InAcquiredMethodContext(
                compilationUnit,
                classContext,
                xClass =>
                {
                    var methodWasFound = xClass.HasMethod(methodName);
                    return methodWasFound;
                },
                methodContextAction,
                methodConstructor);

            return output;
        }
    }
}


namespace R5T.S0026.Library
{
    public static class IMethodContextProviderExtensions
    {
        public static MethodContext GetMethodContext(this IMethodContextProvider methodContextProvider,
            MethodDeclarationAnnotation methodAnnotation)
        {
            var output = new MethodContext
            {
                MethodAnnotation = methodAnnotation,
            };

            return output;
        }
    }
}

