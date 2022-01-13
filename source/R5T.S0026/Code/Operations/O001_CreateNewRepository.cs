using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0104;


namespace R5T.S0026
{
    [OperationMarker]
    public class O001_CreateNewRepository : IActionOperation
    {
        private O001a_CreateNewRepositoryCore O001A_CreateNewRepositoryCore { get; }


        public O001_CreateNewRepository(
            O001a_CreateNewRepositoryCore o001A_CreateNewRepositoryCore)
        {
            this.O001A_CreateNewRepositoryCore = o001A_CreateNewRepositoryCore;
        }

        public async Task Run()
        {
            // Inputs.
            var unadjustedRepositoryName = "R5T.E1000"; // Unadjusted relative to whether the repository is private or not.
            var isPrivate = true;
            var repositoryDescription = "Experimental repository for creating files in a local repository (should be empty, and all code within can be deleted without commit/push).";

            // Run.
            var repositoryName = Instances.RepositoryNameOperator.AdjustRepositoryName(
                unadjustedRepositoryName,
                isPrivate);

            // Now create the repository.
            var repositorySpecification = new RepositorySpecification()
            {
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                Name = repositoryName,
            };

            await this.O001A_CreateNewRepositoryCore.Run(repositorySpecification);
        }
    }
}
