using System;

using R5T.D0078;
using R5T.D0083;


namespace R5T.S0026.Library
{
    public interface IBasicSolutionContext : IDirectoryContext, IFileContext
    {
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }
    }
}
