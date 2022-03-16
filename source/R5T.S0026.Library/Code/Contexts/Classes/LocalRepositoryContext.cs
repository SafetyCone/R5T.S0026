using System;

using R5T.D0037;
using R5T.D0084.D002;
using R5T.D0111.D001;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public class LocalRepositoryContext : ILocalRepositoryContext
    {
        public IGitIgnoreTemplateFilePathProvider GitIgnoreTemplateFilePathProvider { get; set; }
        public IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; set; }
        public IGitOperator SourceControlOperator { get; set; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }

        public string DirectoryPath { get; set; }
    }
}
