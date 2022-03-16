using System;
using System.Threading.Tasks;

using R5T.T0020;

using LocalData;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
    public class O102B_ModifyInitialSolution : IOperation
    {
        private ISolutionContextProvider SolutionContextProvider { get; }


        public O102B_ModifyInitialSolution(
            ISolutionContextProvider solutionContextProvider)
        {
            this.SolutionContextProvider = solutionContextProvider;
        }

        public async Task Run(
            string solutionFilePath)
        {
            await this.SolutionContextProvider.InSolutionContext(
                solutionFilePath,
                async solutionContext =>
                {
                    // Add Magyar as a dependency project reference.
                    // We really only want to add a dependencies solution folder, but the dotnet tool does not allow adding a solution folder without add a project. So, add a project.
                    var magyarProjectIdentityString = Instances.ProjectPath.R5T_Magyar();

                    await solutionContext.AddDependencyProjectReference(
                        magyarProjectIdentityString);
                });
        }
    }
}
