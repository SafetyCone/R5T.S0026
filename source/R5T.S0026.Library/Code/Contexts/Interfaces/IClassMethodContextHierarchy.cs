using System;


namespace R5T.S0026.Library
{
    public interface IClassMethodContextHierarchy : IClassContextHierarchy
    {
        IMethodContext MethodContext { get; }
    }
}
