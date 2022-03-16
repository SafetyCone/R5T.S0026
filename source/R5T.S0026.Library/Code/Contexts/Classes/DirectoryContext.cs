using System;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public class DirectoryContext : IDirectoryContext
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }

        public string DirectoryPath { get; set; }
    }
}
