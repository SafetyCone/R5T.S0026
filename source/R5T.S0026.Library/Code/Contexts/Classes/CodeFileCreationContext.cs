using System;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;


namespace R5T.S0026.Library
{
    public class CodeFileCreationContext : ICodeFileCreationContext
    {
        public string SolutionFilePath { get; set; }
        public string ProjectFilePath { get; set; }
        public string CodeFilePath { get; set; }

        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }
    }
}
