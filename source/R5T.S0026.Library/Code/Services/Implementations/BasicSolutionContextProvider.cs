using System;

using R5T.D0078;
using R5T.D0083;
using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class BasicSolutionContextProvider : IBasicSolutionContextProvider, IServiceImplementation
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public BasicSolutionContextProvider(
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }
    }
}
