using System;


namespace R5T.S0026.Library
{
    public class ClassContextHierarchy : IClassContextHierarchy
    {
        public IClassContext ClassContext { get; set; }
        public INamespaceContext NamespaceContext { get; set; }
    }
}
