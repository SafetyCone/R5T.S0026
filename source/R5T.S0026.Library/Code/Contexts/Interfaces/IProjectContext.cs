using System;

using R5T.D0079;


namespace R5T.S0026.Library
{
    public interface IProjectContext : IDirectoryContext, IFileContext
    {
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
    }
}
