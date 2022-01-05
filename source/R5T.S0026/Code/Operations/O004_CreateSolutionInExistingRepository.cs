using System;
using System.Threading.Tasks;

using R5T.D0078;
using R5T.O0001;


namespace R5T.S0026
{
    /// <summary>
    /// Creates a solution in an existing repository context.
    /// </summary>
    public class O004_CreateSolutionInExistingRepository : T0020.IActionOperation
    {
        private CreateSolutionInExistingRepository CreateSolutionInExistingRepository { get; }


        public O004_CreateSolutionInExistingRepository(
            CreateSolutionInExistingRepository createSolutionInExistingRepository)
        {
            this.CreateSolutionInExistingRepository = createSolutionInExistingRepository;
        }

        public async Task Run()
        {
            // Inputs.
            var repositoryDirectoryPath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.E1000.Private";
            var solutionName = "TestSolution";

            // Run.
            await this.CreateSolutionInExistingRepository.Run(
                repositoryDirectoryPath,
                solutionName);
        }
    }
}
