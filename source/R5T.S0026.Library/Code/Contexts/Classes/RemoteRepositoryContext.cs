using System;

using R5T.D0082;


namespace R5T.S0026.Library
{
    public class RemoteRepositoryContext : IRemoteRepositoryContext
    {
        #region Static

        public static RemoteRepositoryContext From(
            IGitHubOperator gitHubOperator,
            string name)
        {
            var output = new RemoteRepositoryContext
            {
                RemoteRepositoryOperator = gitHubOperator,
                Name = name
            };

            return output;
        }

        #endregion


        public IGitHubOperator RemoteRepositoryOperator { get; set; }

        public string Name { get; set; }
    }
}
