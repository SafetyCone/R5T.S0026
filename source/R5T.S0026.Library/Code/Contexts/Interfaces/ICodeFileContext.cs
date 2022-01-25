using System;


namespace R5T.S0026.Library
{
    public interface ICodeFileContext : IProjectFileContext
    {
        string CodeFilePath { get; }
    }
}
