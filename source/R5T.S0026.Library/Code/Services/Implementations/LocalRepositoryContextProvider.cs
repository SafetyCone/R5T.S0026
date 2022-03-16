using System;

using R5T.D0037;
using R5T.D0084.D002;
using R5T.D0111.D001;
using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class LocalRepositoryContextProvider : ILocalRepositoryContextProvider, IServiceImplementation
    {
        public IGitIgnoreTemplateFilePathProvider GitIgnoreTemplateFilePathProvider { get; }
        public IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }
        public IGitOperator SourceControlOperator { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public LocalRepositoryContextProvider(
            IGitIgnoreTemplateFilePathProvider gitIgnoreTemplateFilePathProvider,
            IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider,
            IGitOperator sourceControlOperator,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.GitIgnoreTemplateFilePathProvider = gitIgnoreTemplateFilePathProvider;
            this.RepositoriesDirectoryPathProvider = repositoriesDirectoryPathProvider;
            this.SourceControlOperator = sourceControlOperator;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }
    }
}
