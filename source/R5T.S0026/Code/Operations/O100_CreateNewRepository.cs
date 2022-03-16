using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0104;


namespace R5T.S0026
{
    [OperationMarker]
    public class O100_CreateNewRepository : IActionOperation
    {
        private O100_CreateNewRepositoryCore O100_CreateNewRepositoryCore { get; }


        public O100_CreateNewRepository(
            O100_CreateNewRepositoryCore o100_CreateNewRepositoryCore)
        {
            this.O100_CreateNewRepositoryCore = o100_CreateNewRepositoryCore;
        }

        public async Task Run()
        {
            /// Inputs.
            // Example: "R5T.Testing", which will become "R5T.Testing.Private" if isPrivate = true.
            var repositoryNameUnadjustedForPrivacy = "R5T.Testing2";
            // The description for the repository. Shown as the reposiory description and in the README file.
            var description = "Repository for testing.";
            // Whether of not the GitHub repository will be private.
            var isPrivate = true;

            /// Run.
            var repositoryName = Instances.RepositoryNameOperator.AdjustRepositoryNameForPrivacy(
                repositoryNameUnadjustedForPrivacy,
                isPrivate);

            var repositorySpecification = new RepositorySpecification
            {
                Description = description,
                IsPrivate = isPrivate,
                Name = repositoryName,
            };

            await this.O100_CreateNewRepositoryCore.Run(repositorySpecification);
        }
    }
}
