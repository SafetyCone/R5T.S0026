using System;

using R5T.T0126;


namespace R5T.S0026.Library
{
    public interface IClassContext
    {
        // No services for now, but will contain class-related services.

        ClassAnnotation ClassAnnotation { get; }
    }
}
