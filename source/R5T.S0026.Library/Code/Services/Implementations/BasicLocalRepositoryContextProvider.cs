using System;

using R5T.D0037;
using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class BasicLocalRepositoryContextProvider : IBasicLocalRepositoryContextProvider, IServiceImplementation
    {
        public IGitOperator SourceControlOperator { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public BasicLocalRepositoryContextProvider(
            IGitOperator sourceControlOperator,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.SourceControlOperator = sourceControlOperator;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }
    }
}
