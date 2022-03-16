using System;

using R5T.T0064;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class FileContextProvider : IFileContextProvider, IServiceImplementation
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public FileContextProvider(
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }
    }
}
