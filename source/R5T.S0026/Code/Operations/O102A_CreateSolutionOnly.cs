using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
    public class O102A_CreateSolutionOnly : IOperation
    {
        private IBasicSolutionContextProvider SolutionContextProvider { get; }


        public O102A_CreateSolutionOnly(
            IBasicSolutionContextProvider solutionContextProvider)
        {
            this.SolutionContextProvider = solutionContextProvider;
        }

        public async Task Run(
            string solutionFilePath)
        {
            await this.SolutionContextProvider.InSolutionContext_WithoutExistenceCheck(
                solutionFilePath,
                async solutionContext =>
                {
                    var solutionExists = solutionContext.FileExists();
                    if(solutionExists)
                    {
                        throw new Exception($"Solution already exists:\n{solutionContext.FilePath}");
                    }

                    await solutionContext.Create();
                });
        }
    }
}
