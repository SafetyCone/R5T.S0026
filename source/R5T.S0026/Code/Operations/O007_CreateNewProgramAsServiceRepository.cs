using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0104;


namespace R5T.S0026
{
    [OperationMarker]
    public class O007_CreateNewProgramAsServiceRepository : IActionOperation
    {
        private O001a_CreateNewRepositoryCore O001A_CreateNewRepositoryCore { get; }
        private O006_CreateNewProgramAsServiceSolutionCore O006_CreateNewProgramAsServiceSolutionCore { get; }


        public O007_CreateNewProgramAsServiceRepository(
            O001a_CreateNewRepositoryCore o001A_CreateNewRepositoryCore,
            O006_CreateNewProgramAsServiceSolutionCore o006_CreateNewProgramAsServiceSolutionCore)
        {
            this.O001A_CreateNewRepositoryCore = o001A_CreateNewRepositoryCore;
            this.O006_CreateNewProgramAsServiceSolutionCore = o006_CreateNewProgramAsServiceSolutionCore;
        }

        public async Task Run()
        {
            // Inputs.
            var unadjustedRepositoryName = "R5T.S0030"; // Unadjusted relative to whether the repository is private or not.
            var isPrivate = false;
            var repositoryDescription = "Nomad functionality: Survey service definitions, implementations, and dependency mappings and store these in a database.";

            // Run.
            var libraryName = Instances.RepositoryNameOperator.GetLibraryName(unadjustedRepositoryName);
            var libraryDescription = repositoryDescription; // TODO, create new base.

            var repositoryName = Instances.RepositoryNameOperator.AdjustRepositoryNameForPrivacy(
                unadjustedRepositoryName,
                isPrivate);

            var repositorySpecification = new RepositorySpecification()
            {
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                Name = repositoryName,
            };

            var localRepositoryDirectoryPath = await this.O001A_CreateNewRepositoryCore.Run(
                repositorySpecification,
                async localRepositoryContext =>
                {
                    await this.O006_CreateNewProgramAsServiceSolutionCore.Run(
                        localRepositoryContext.DirectoryPath,
                        libraryName,
                        libraryDescription);
                });
        }
    }
}
