using System;

using R5T.D0079;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public class ProjectContext : IProjectContext
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; set; }

        public string DirectoryPath { get; set; }
        public string FilePath { get; set; }
    }
}
