﻿using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.S0026.Library;

using Instances = R5T.S0026.Library.Instances;


namespace System
{
    public static class ICompilationUnitContextProviderExtensions
    {
        public static async Task InAcquiredCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string codeFilePath,
            Func<ICompilationUnitContext, CompilationUnitSyntax, Task<CompilationUnitSyntax>> compilationUnitContextAction)
        {
            var compilationUnitContext = compilationUnitContextProvider.GetCompilationUnitContext();

            await Instances.CompilationUnitOperator.ModifyAcquired(
                codeFilePath,
                async compilationUnit =>
                {
                    var outputCompilationUnit = await compilationUnitContextAction(
                        compilationUnitContext,
                        compilationUnit);

                    return outputCompilationUnit;
                },
                compilationUnit => Task.FromResult(compilationUnit));
        }

        public static Task InAcquiredCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            IFileContext fileContext,
            Func<ICompilationUnitContext, CompilationUnitSyntax, Task<CompilationUnitSyntax>> compilationUnitContextAction)
        {
            return compilationUnitContextProvider.InAcquiredCompilationUnitContext(
                fileContext.FilePath,
                compilationUnitContextAction);
        }
    }
}


namespace R5T.S0026.Library
{
    public static class ICompilationUnitContextProviderExtensions
    {
        public static CompilationUnitContext GetCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider)
        {
            var output = new CompilationUnitContext
            {
                UsingDirectivesFormatter = compilationUnitContextProvider.UsingDirectivesFormatter,
            };

            return output;
        }
    }
}
