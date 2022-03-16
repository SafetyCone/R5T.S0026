using System;

using R5T.D0037;
using R5T.D0082;


namespace R5T.S0026.Library
{
    /// <summary>
    /// Represents a GitHub remote repository.
    /// </summary>
    public interface IRemoteRepositoryContext
    {
        IGitHubOperator RemoteRepositoryOperator { get; }

        string Name { get; }
    }
}
