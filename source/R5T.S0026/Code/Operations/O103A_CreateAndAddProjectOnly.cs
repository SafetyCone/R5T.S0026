using System;
using System.Threading.Tasks;

using R5T.D0079;
using R5T.T0020;

using R5T.S0026.Library;


namespace R5T.S0026
{
    [OperationMarker]
    public class O103A_CreateAndAddProjectOnly : IOperation
    {
        private IProjectContextProvider ProjectContextProvider { get; }
        private ISolutionContextProvider SolutionContextProvider { get; }


        public O103A_CreateAndAddProjectOnly(
            IProjectContextProvider projectContextProvider,
            ISolutionContextProvider solutionContextProvider)
        {
            this.ProjectContextProvider = projectContextProvider;
            this.SolutionContextProvider = solutionContextProvider;
        }

        public async Task<string> Run(
            string projectName,
            VisualStudioProjectType projectType,
            string solutionFilePath)
        {
            // Will be assigned in context.
            string projectFilePath = null;

            await this.SolutionContextProvider.InSolutionContext(
                solutionFilePath,
                async solutionContext =>
                {
                    await this.ProjectContextProvider.InProjectContext_WithoutExistenceCheck(
                        projectName,
                        solutionContext,
                        async projectContext =>
                        {
                            await projectContext.Create(projectType);

                            await solutionContext.AddProjectReference(
                                projectContext.FilePath);

                            projectFilePath = projectContext.FilePath;
                        });
                });

            return projectFilePath;
        }
    }
}
