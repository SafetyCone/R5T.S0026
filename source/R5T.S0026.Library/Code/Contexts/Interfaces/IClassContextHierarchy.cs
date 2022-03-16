using System;


namespace R5T.S0026.Library
{
    public interface IClassContextHierarchy
    {
        INamespaceContext NamespaceContext { get; }
        IClassContext ClassContext { get; }
    }
}
