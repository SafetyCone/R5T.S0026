using System;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;


namespace R5T.S0026.Library
{
    public interface IProjectFileContext
    {
        string SolutionFilePath { get; }
        string ProjectFilePath { get; }

        IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }
    }
}
