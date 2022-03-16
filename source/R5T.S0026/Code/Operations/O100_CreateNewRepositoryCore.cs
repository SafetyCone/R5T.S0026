using System;
using System.Threading.Tasks;

using R5T.T0020;
using R5T.T0104;


namespace R5T.S0026
{
    [OperationMarker]
    public class O100_CreateNewRepositoryCore : IOperation
    {
        private O100A_CreateNewRepositoryOnly O100A_CreateNewRepositoryOnly { get; }
        private O100B_InitialSetupWithCheckIn O100B_InitialSetupWithCheckIn { get; }


        public O100_CreateNewRepositoryCore(
            O100A_CreateNewRepositoryOnly o100A_CreateNewRepositoryOnly,
            O100B_InitialSetupWithCheckIn o100B_InitialSetupWithCheckIn)
        {
            this.O100A_CreateNewRepositoryOnly = o100A_CreateNewRepositoryOnly;
            this.O100B_InitialSetupWithCheckIn = o100B_InitialSetupWithCheckIn;
        }

        public async Task Run(
            RepositorySpecification repositorySpecification)
        {
            await this.O100A_CreateNewRepositoryOnly.Run(repositorySpecification);
            await this.O100B_InitialSetupWithCheckIn.Run(repositorySpecification);
        }
    }
}
