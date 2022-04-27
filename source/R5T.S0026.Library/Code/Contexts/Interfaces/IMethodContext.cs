using System;

using R5T.T0126;


namespace R5T.S0026.Library
{
    public interface IMethodContext
    {
        // No services for now, but will contain method-related services.

        MethodAnnotation MethodAnnotation { get; }
    }
}
