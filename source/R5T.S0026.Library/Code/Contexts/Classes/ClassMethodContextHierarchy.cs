using System;


namespace R5T.S0026.Library
{
    public class ClassMethodContextHierarchy : IClassMethodContextHierarchy
    {
        public INamespaceContext NamespaceContext { get; set; }
        public IClassContext ClassContext { get; set; }
        public IMethodContext MethodContext { get; set; }
    }
}
