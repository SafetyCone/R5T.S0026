using System;
using System.Threading.Tasks;

using R5T.D0079;
using R5T.T0020;


namespace R5T.S0026
{
    [OperationMarker]
    public class O103_CreateProjectForExistingSolution : IActionOperation
    {
        private O103_CreateProjectForExistingSolutionCore O103_CreateProjectForExistingSolutionCore { get; }


        public O103_CreateProjectForExistingSolution(
            O103_CreateProjectForExistingSolutionCore o103_CreateProjectForExistingSolutionCore)
        {
            this.O103_CreateProjectForExistingSolutionCore = o103_CreateProjectForExistingSolutionCore;
        }

        public async Task Run()
        {
            /// Inputs.
            var projectName = "R5T.Testing2";
            var projectDescription = "Testing project.";
            var projectType = VisualStudioProjectType.Console;
            var solutionFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing2.Private\source\R5T.Testing2.Private.sln";

            /// Run.
            await this.O103_CreateProjectForExistingSolutionCore.Run(
                projectName,
                projectDescription,
                projectType,
                solutionFilePath);
        }
    }
}
