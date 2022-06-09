using System;
using System.Threading.Tasks;

using R5T.D0037;
using R5T.D0082;
using R5T.D0084.D002;
using R5T.D0111.D001;
using R5T.T0020;
using R5T.T0104;
using R5T.T0106;


namespace R5T.S0026
{
    /// <summary>
    /// Creates a new repository, and returns the local repository directory path.
    /// </summary>
    [OperationMarker]
    public class O001a_CreateNewRepositoryCore : IOperation
    {
        private IGitHubOperator GitHubOperator { get; }
        private IGitIgnoreTemplateFilePathProvider GitIgnoreTemplateFilePathProvider { get; }
        private IGitOperator GitOperator { get; }
        private IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }


        public O001a_CreateNewRepositoryCore(
            IGitHubOperator gitHubOperator,
            IGitIgnoreTemplateFilePathProvider gitIgnoreTemplateFilePathProvider,
            IGitOperator gitOperator,
            IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider)
        {
            this.GitHubOperator = gitHubOperator;
            this.GitIgnoreTemplateFilePathProvider = gitIgnoreTemplateFilePathProvider;
            this.GitOperator = gitOperator;
            this.RepositoriesDirectoryPathProvider = repositoriesDirectoryPathProvider;
        }

        public async Task<string> Run(
            RepositorySpecification repositorySpecification,
            Func<ILocalRepositoryContext, Task> localRepositoryContextAction = default)
        {
            // Run.
            // Safety checks.
            // Verify that the repository can be created (i.e. it doesn't already exist).
            await this.GitHubOperator.VerifyCanCreateRepository_SafetyCone(repositorySpecification.Name);

            // Verify that the local repository directory does not already exist.
            var repositoriesDirectoryPath = await this.RepositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

            var localRepositoryDirectoryName = Instances.RepositoryNameOperator.GetRepositoryDirectoryName(repositorySpecification.Name);
            var localRepositoryDirectoryPath = Instances.PathOperator.GetDirectoryPath(repositoriesDirectoryPath, localRepositoryDirectoryName);

            Instances.FileSystemOperator.VerifyDirectoryDoesNotAlreadyExist(localRepositoryDirectoryPath);

            // Now perform action to create repository.
            var gitIgnoreTemplateFilePath = await this.GitIgnoreTemplateFilePathProvider.GetGitIgnoreTemplateFilePath();

            await Instances.RepositoryGenerator.CreateRepository(
                repositorySpecification,
                repositoriesDirectoryPath,
                gitIgnoreTemplateFilePath,
                this.GitHubOperator,
                this.GitOperator,
                localRepositoryContextAction);

            return localRepositoryDirectoryPath;
        }
    }
}
