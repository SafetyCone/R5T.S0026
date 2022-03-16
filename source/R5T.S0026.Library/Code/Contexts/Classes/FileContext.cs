using System;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public class FileContext : IFileContext
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }

        public string FilePath { get; set; }
    }
}
