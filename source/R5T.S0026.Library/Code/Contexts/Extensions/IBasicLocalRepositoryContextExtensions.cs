using System;
using System.Threading.Tasks;


namespace R5T.S0026.Library
{
    public static class IBasicLocalRepositoryContextExtensions
    {
        public static async Task<bool> IsRepository(this IBasicLocalRepositoryContext localRepositoryContext)
        {
            var output = await localRepositoryContext.SourceControlOperator.IsRepository(
                localRepositoryContext.DirectoryPath);

            return output;
        }
    }
}
