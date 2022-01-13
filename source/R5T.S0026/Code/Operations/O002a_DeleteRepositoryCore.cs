using System;
using System.Threading.Tasks;

using R5T.D0082;
using R5T.D0084.D002;
using R5T.T0020;


namespace R5T.S0026
{
    /// <summary>
    /// WARNING: will delete both GitHub and local copies of the repository!
    /// (The inverse of the create new repository operation.)
    /// </summary>
    [OperationMarker]
    public class O002a_DeleteRepositoryCore : IOperation
    {
        private IGitHubOperator GitHubOperator { get; }
        private IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }


        public O002a_DeleteRepositoryCore(
            IGitHubOperator gitHubOperator,
            IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider)
        {
            this.GitHubOperator = gitHubOperator;
            this.RepositoriesDirectoryPathProvider = repositoriesDirectoryPathProvider;
        }

        public async Task Run(string repositoryName)
        {
            var repositoriesDirectoryPath = await this.RepositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

            var repositoryDirectoryName = Instances.RepositoryNameOperator.GetRepositoryDirectoryName(repositoryName);

            var repositoryDirectoryPath = Instances.PathOperator.GetDirectoryPath(repositoriesDirectoryPath, repositoryDirectoryName);

            // Delete the local directory for the repository.
            Instances.FileSystemOperator.DeleteDirectoryOkIfNotExists(repositoryDirectoryPath);

            // Delete the GitHub remote repository.
            await Instances.RepositoryOperator.DeleteRepositoryOkIfNotExists(
                this.GitHubOperator,
                repositoryName);
        }
    }
}
