using System;

using R5T.T0126;


namespace R5T.S0026.Library
{
    public interface INamespaceContext
    {
        // No services for now, but will contain namespace-related services.

        NamespaceAnnotation NamespaceAnnotation { get; }
    }
}
