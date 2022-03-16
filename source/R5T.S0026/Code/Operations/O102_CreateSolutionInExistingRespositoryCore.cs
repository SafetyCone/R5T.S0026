using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.D0084.D002;

using R5T.Lombardy;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
    public class O102_CreateSolutionInExistingRespositoryCore : IOperation
    {
        private IRepositoriesDirectoryPathProvider RepositoriesDirectoryPathProvider { get; }
        private IRepositorySolutionProjectFileSystemConventions RepositorySolutionProjectFileSystemConventions { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }

        private O102A_CreateSolutionOnly O102A_CreateSolutionOnly { get; }
        private O102B_ModifyInitialSolution O102B_ModifyInitialSolution { get; }


        public O102_CreateSolutionInExistingRespositoryCore(
            IRepositoriesDirectoryPathProvider repositoriesDirectoryPathProvider,
            IRepositorySolutionProjectFileSystemConventions repositorySolutionProjectFileSystemConventions,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            O102A_CreateSolutionOnly o102A_CreateSolutionOnly,
            O102B_ModifyInitialSolution o102B_ModifyInitialSolution)
        {
            this.RepositoriesDirectoryPathProvider = repositoriesDirectoryPathProvider;
            this.RepositorySolutionProjectFileSystemConventions = repositorySolutionProjectFileSystemConventions;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;

            this.O102A_CreateSolutionOnly = o102A_CreateSolutionOnly;
            this.O102B_ModifyInitialSolution = o102B_ModifyInitialSolution;
        }

        public async Task Run(
            string repositoryName,
            string solutionName)
        {
            var repositoriesDirectoryPath = await this.RepositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

            var repositoryDirectoryName = Instances.RepositoryNameOperator.GetRepositoryDirectoryName(repositoryName);

            var repositoryDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(
                repositoriesDirectoryPath,
                repositoryDirectoryName);

            var solutionFilePath = await this.RepositorySolutionProjectFileSystemConventions.GetSolutionFilePathFromRepositoryDirectoryPath(
                repositoryDirectoryPath,
                solutionName);

            await this.O102A_CreateSolutionOnly.Run(solutionFilePath);
            await this.O102B_ModifyInitialSolution.Run(solutionFilePath);
        }
    }
}
