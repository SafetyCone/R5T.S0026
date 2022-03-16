using System;

using R5T.D0116;


namespace R5T.S0026.Library
{
    /// <summary>
    /// Note: does *not* include the CompilationUnitSyntax object itself. That will be passed around separately as a "data-object".
    /// </summary>
    public interface ICompilationUnitContext
    {
        IUsingDirectivesFormatter UsingDirectivesFormatter { get; }
    }
}
