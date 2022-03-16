using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceDefinitionMarker]
    public interface IRepositorySolutionProjectFileSystemConventions : IServiceDefinition
    {
        /// <summary>
        /// Provides the source control repository directory path for a solution file within the repository.
        /// </summary>
        Task<string> GetRepositoryDirectoryPathFromSolutionFilePath(string solutionFilePath);
        Task<string> GetSolutionFilePathFromRepositoryDirectoryPath(
            string repositoryDirectoryPath,
            string solutionName);
    }
}
