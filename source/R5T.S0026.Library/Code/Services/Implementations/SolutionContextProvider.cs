using System;

using R5T.D0078;
using R5T.D0083;
using R5T.D0101;
using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class SolutionContextProvider : ISolutionContextProvider, IServiceImplementation
    {
        public IProjectRepository ProjectRepository { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public SolutionContextProvider(
            IProjectRepository projectRepository,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.ProjectRepository = projectRepository;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }
    }
}
