using System;

using R5T.D0037;


namespace R5T.S0026.Library
{
    /// <summary>
    /// Represents a local Git repository.
    /// </summary>
    public interface IBasicLocalRepositoryContext : IDirectoryContext
    {
        IGitOperator SourceControlOperator { get; }
    }
}
