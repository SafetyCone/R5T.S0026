using System;
using System.Threading.Tasks;


namespace R5T.S0026
{
    /// <summary>
    /// WARNING: will delete both GitHub and local copies of the repository!
    /// (The inverse of the create new repository operation.)
    /// </summary>
    public class O002_DeleteRepository : T0020.IOperation
    {
        private O002a_DeleteRepositoryCore O002A_DeleteRepositoryCore { get; }


        public O002_DeleteRepository(
            O002a_DeleteRepositoryCore o002A_DeleteRepositoryCore)
        {
            this.O002A_DeleteRepositoryCore = o002A_DeleteRepositoryCore;
        }

        public async Task Run()
        {
            // Input.
            var unadjustedRepositoryName = "R5T.T9999"; // Unadjusted relative to whether the repository is private or not.
            var isPrivate = false;
            //var repositoryNameOverride = 

            // Run.
            var repositoryName = Instances.RepositoryNameOperator.AdjustRepositoryName(
                unadjustedRepositoryName,
                isPrivate);

            await this.O002A_DeleteRepositoryCore.Run(repositoryName);
        }
    }
}
