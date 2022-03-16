using System;

using R5T.D0079;
using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class ProjectContextProvider : IProjectContextProvider, IServiceImplementation
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }


        public ProjectContextProvider(
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
        }
    }
}
