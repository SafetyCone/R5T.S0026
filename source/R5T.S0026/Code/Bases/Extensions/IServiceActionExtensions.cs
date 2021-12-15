using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.S0026
{
    public static class IServiceActionExtensions
    {
        public static IServiceAction<HostStartup> AddStartupAction(this IServiceAction _)
        {
            var output = _.New<HostStartup>(services => services.AddHostStartup());

            return output;
        }
    }
}
