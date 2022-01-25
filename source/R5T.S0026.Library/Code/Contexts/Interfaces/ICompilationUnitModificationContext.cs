using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0026.Library
{
    public interface ICompilationUnitModificationContext : ICodeFileContext
    {
        CompilationUnitSyntax CompilationUnit { get; }
    }
}
