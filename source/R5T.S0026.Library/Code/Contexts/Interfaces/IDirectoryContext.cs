using System;

using R5T.Lombardy;


namespace R5T.S0026.Library
{
    public interface IDirectoryContext : IHasStringlyTypedPathOperator
    {
        string DirectoryPath { get; }
    }
}
