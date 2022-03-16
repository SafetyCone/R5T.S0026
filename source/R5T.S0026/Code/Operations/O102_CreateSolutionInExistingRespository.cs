using System;
using System.Threading.Tasks;

using R5T.T0020;


namespace R5T.S0026
{
    [OperationMarker]
    public class O102_CreateSolutionInExistingRespository : IActionOperation
    {
        private O102_CreateSolutionInExistingRespositoryCore O102_CreateSolutionInExistingRespositoryCore { get; }


        public O102_CreateSolutionInExistingRespository(
            O102_CreateSolutionInExistingRespositoryCore o102_CreateSolutionInExistingRespositoryCore)
        {
            this.O102_CreateSolutionInExistingRespositoryCore = o102_CreateSolutionInExistingRespositoryCore;
        }

        public async Task Run()
        {
            /// Inputs.
            // Example: The exact repository name, so R5T.Testing.Private should be "R5T.Testing.Private".
            var repositoryName = "R5T.Testing2.Private";

            var solutionName = "R5T.Testing2.Private";

            /// Run.
            await this.O102_CreateSolutionInExistingRespositoryCore.Run(
                repositoryName,
                solutionName);
        }
    }
}
