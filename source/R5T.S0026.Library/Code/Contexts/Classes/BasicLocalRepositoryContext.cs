using System;

using R5T.D0037;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public class BasicLocalRepositoryContext : IBasicLocalRepositoryContext
    {
        #region Static

        public static BasicLocalRepositoryContext From(
            IGitOperator gitOperator,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            string directoryPath)
        {
            var output = new BasicLocalRepositoryContext
            {
                SourceControlOperator = gitOperator,
                DirectoryPath = directoryPath,
                StringlyTypedPathOperator = stringlyTypedPathOperator,
            };

            return output;
        }

        #endregion


        public IGitOperator SourceControlOperator { get; set; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }

        public string DirectoryPath { get; set; }
    }
}
