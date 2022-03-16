using System;
using System.Threading.Tasks;

using R5T.D0079;
using R5T.T0020;


namespace R5T.S0026
{
    [OperationMarker]
    public class O103_CreateProjectForExistingSolutionCore : IOperation
    {
        private O103A_CreateAndAddProjectOnly O103A_CreateAndAddProjectOnly { get; }
        private O103B_ModifyInitialProjectForProjectType O103B_ModifyInitialProjectForProjectType { get; }


        public O103_CreateProjectForExistingSolutionCore(
            O103A_CreateAndAddProjectOnly o103A_CreateAndAddProjectOnly,
            O103B_ModifyInitialProjectForProjectType o103B_ModifyInitialProjectForProjectType)
        {
            this.O103A_CreateAndAddProjectOnly = o103A_CreateAndAddProjectOnly;
            this.O103B_ModifyInitialProjectForProjectType = o103B_ModifyInitialProjectForProjectType;
        }

        public async Task Run(
            string projectName,
            string projectDescription,
            VisualStudioProjectType projectType,
            string solutionFilePath)
        {
            var projectFilePath =await this.O103A_CreateAndAddProjectOnly.Run(
                projectName,
                projectType,
                solutionFilePath);

            await this.O103B_ModifyInitialProjectForProjectType.Run(
                projectFilePath,
                projectType,
                projectDescription);
        }
    }
}
