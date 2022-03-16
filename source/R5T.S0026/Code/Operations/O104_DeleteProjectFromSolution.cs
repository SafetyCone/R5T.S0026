using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.S0026.Library;


namespace R5T.S0026
{
    public class O104_DeleteProjectFromSolution : IActionOperation
    {
        private IProjectContextProvider ProjectContextProvider { get; }
        private IBasicSolutionContextProvider SolutionContextProvider { get; }


        public O104_DeleteProjectFromSolution(
            IProjectContextProvider projectContextProvider,
            IBasicSolutionContextProvider solutionContextProvider)
        {
            this.ProjectContextProvider = projectContextProvider;
            this.SolutionContextProvider = solutionContextProvider;
        }

        public async Task Run()
        {
            /// Inputs.
            var solutionFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing2.Private\source\R5T.Testing2.Private.sln";
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Testing2.Private\source\R5T.Testing2\R5T.Testing2.csproj";

            /// Run.
            await this.SolutionContextProvider.InSolutionContext(
                solutionFilePath,
                async solutionContext =>
                {
                    await this.ProjectContextProvider.InProjectContext(
                        projectFilePath,
                        async projectContext =>
                        {
                            // Delete the whole project directory.
                            projectContext.DeleteDirectory();

                            await solutionContext.RemoveProjectReference(
                                projectContext.FilePath);
                        });
                });
        }
    }
}
