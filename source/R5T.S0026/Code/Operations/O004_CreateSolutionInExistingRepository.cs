﻿using System;
using System.Threading.Tasks;

using R5T.O0001;
using R5T.T0020;


namespace R5T.S0026
{
    /// <summary>
    /// Creates a solution in an existing repository context.
    /// </summary>
    [OperationMarker]
    public class O004_CreateSolutionInExistingRepository : IActionOperation
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
            var repositoryDirectoryPath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test";
            var solutionName = "TestSolution";

            // Run.
            await this.CreateSolutionInExistingRepository.Run(
                repositoryDirectoryPath,
                solutionName);
        }
    }
}
