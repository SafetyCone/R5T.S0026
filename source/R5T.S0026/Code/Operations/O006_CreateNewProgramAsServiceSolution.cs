using System;
using System.Threading.Tasks;

using R5T.T0020;


namespace R5T.S0026
{
    public class O006_CreateNewProgramAsServiceSolution : IActionOperation
    {
        private O006_CreateNewProgramAsServiceSolutionCore O006_CreateNewProgramAsServiceSolutionCore { get; }


        public O006_CreateNewProgramAsServiceSolution(
            O006_CreateNewProgramAsServiceSolutionCore o006_CreateNewProgramAsServiceSolutionCore)
        {
            this.O006_CreateNewProgramAsServiceSolutionCore = o006_CreateNewProgramAsServiceSolutionCore;
        }

        public async Task Run()
        {
            // Inputs.
            var repositoriesDirectoryPath = @"C:\Code\DEV\Git\GitHub\SafetyCone";
            var libraryName = "R5T.S0029";
            var libraryDescription = "A test of program-as-a-service solution/project creation.";

            // Run.
            // Repository.
            var repositoryName = Instances.LibraryNameOperator.GetRepositoryName(libraryName);
    
            var repositoryDirectoryPath = Instances.RepositoryPathOperator.GetRepositoryDirectoryPath(
                repositoriesDirectoryPath,
                repositoryName);

            await this.O006_CreateNewProgramAsServiceSolutionCore.Run(
                repositoryDirectoryPath,
                libraryName,
                libraryDescription);
        }
    }
}
