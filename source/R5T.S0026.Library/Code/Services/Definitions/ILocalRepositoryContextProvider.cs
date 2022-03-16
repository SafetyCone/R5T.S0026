using System;

using R5T.D0037;
using R5T.D0084.D002;
using R5T.D0111.D001;
using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceDefinitionMarker]
    public interface ILocalRepositoryContextProvider : IBasicLocalRepositoryContextProvider, IServiceDefinition
    {
        IGitIgnoreTemplateFilePathProvider GitIgnoreTemplateFilePathProvider { get; }
        IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }
    }
}
