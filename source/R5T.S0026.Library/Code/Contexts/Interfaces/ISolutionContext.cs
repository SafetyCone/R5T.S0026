using System;

using R5T.D0101;


namespace R5T.S0026.Library
{
    public interface ISolutionContext : IBasicSolutionContext
    {
        IProjectRepository ProjectRepository { get; }
    }
}
