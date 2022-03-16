using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class RepositorySolutionProjectFileSystemConventions : IRepositorySolutionProjectFileSystemConventions, IServiceImplementation
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public RepositorySolutionProjectFileSystemConventions(
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        /// <summary>
        /// <inheritdoc cref="IRepositorySolutionProjectFileSystemConventions.GetRepositoryDirectoryPathFromSolutionFilePath(string)"/>
        /// </summary>
        /// <example>
        /// C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing2.Private\source\R5T.Testing2.Private.sln
        /// =>
        /// C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing2.Private\
        /// </example>
        public Task<string> GetRepositoryDirectoryPathFromSolutionFilePath(string solutionFilePath)
        {
            var solutionDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPathForFilePath(solutionFilePath);

            var repositoryDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(solutionDirectoryPath);
            
            return Task.FromResult(repositoryDirectoryPath);
        }

        public Task<string> GetSolutionFilePathFromRepositoryDirectoryPath(string repositoryDirectoryPath, string solutionName)
        {
            var solutionDirectoryPath = Instances.SolutionPathsOperator.GetSourceSolutionDirectoryPath(
                repositoryDirectoryPath);

            var solutionFileName = Instances.SolutionFileNameOperator.GetSolutionFileName(solutionName);

            var solutionFilePath = this.StringlyTypedPathOperator.GetFilePath(
                solutionDirectoryPath,
                solutionFileName);

            return Task.FromResult(solutionFilePath);
        }
    }
}
