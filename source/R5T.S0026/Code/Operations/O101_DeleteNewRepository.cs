using System;
using System.Threading.Tasks;

using R5T.T0020;


namespace R5T.S0026
{
    [OperationMarker]
    public class O101_DeleteNewRepository : IActionOperation
    {
        private O101_DeleteNewRepositoryCore O101_DeleteNewRepositoryCore { get; }


        public O101_DeleteNewRepository(
            O101_DeleteNewRepositoryCore o101_DeleteNewRepositoryCore)
        {
            this.O101_DeleteNewRepositoryCore = o101_DeleteNewRepositoryCore;
        }

        public async Task Run()
        {
            /// Inputs.
            // Example: The exact repository name, so R5T.Testing.Private should be "R5T.Testing.Private".
            var repositoryName = "R5T.Testing2.Private";

            /// Run.
            await this.O101_DeleteNewRepositoryCore.Run(repositoryName);
        }
    }
}
