using System;

using R5T.D0078;
using R5T.D0083;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public class BasicSolutionContext : IBasicSolutionContext
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }

        public string DirectoryPath { get; set; }
        public string FilePath { get; set; }
    }
}
