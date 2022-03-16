using System;

using R5T.D0084.D002;
using R5T.D0111.D001;


namespace R5T.S0026.Library
{
    public interface ILocalRepositoryContext : IBasicLocalRepositoryContext
    {
        IGitIgnoreTemplateFilePathProvider GitIgnoreTemplateFilePathProvider { get; }
        IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }
    }
}
