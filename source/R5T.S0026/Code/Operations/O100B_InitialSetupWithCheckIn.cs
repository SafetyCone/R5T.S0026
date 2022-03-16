using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0104;

using R5T.S0026.Library;


namespace R5T.S0026
{
    /// <summary>
    /// Performs initial repository setup, then performs a check-in:
    /// * Add git-ignore template file.
    /// </summary>
    [OperationMarker]
    public class O100B_InitialSetupWithCheckIn : IOperation
    {
        private ILocalRepositoryContextProvider LocalRepositoryContextProvider { get; }


        public O100B_InitialSetupWithCheckIn(
            ILocalRepositoryContextProvider localRepositoryContextProvider)
        {
            this.LocalRepositoryContextProvider = localRepositoryContextProvider;
        }

        public async Task Run(
             RepositorySpecification repositorySpecification)
        {
            await this.LocalRepositoryContextProvider.InLocalRepositoryContext(
                repositorySpecification.Name,
                async localRepositoryContext =>
                {
                    await localRepositoryContext.CopyGitIgnoreTemplateFile();

                    await localRepositoryContext.CheckIn(
                        Instances.CommitMessage.AddGitIgnoreFile());
                });
        }
    }
}
