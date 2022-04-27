using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class IBasicSolutionContextExtensions
    {
        public static async Task AddProjectReferences(this IBasicSolutionContext solutionContext,
            IEnumerable<string> projectFilePaths)
        {
            await solutionContext.VisualStudioSolutionFileOperator.AddProjectReferences(
                solutionContext.FilePath,
                projectFilePaths);
        }

        public static async Task AddProjectReference(this IBasicSolutionContext solutionContext,
            string projectFilePath)
        {
            await solutionContext.VisualStudioSolutionFileOperator.AddProjectReference(
                solutionContext.FilePath,
                projectFilePath);
        }

        public static async Task Create(this IBasicSolutionContext solutionContext)
        {
            await solutionContext.VisualStudioSolutionFileOperator.Create(
                solutionContext.FilePath);
        }

        public static async Task<Dictionary<string, bool>> HasProjectReferences(this IBasicSolutionContext solutionContext,
            IEnumerable<string> projectReferenceFilePaths)
        {
            var output = await solutionContext.VisualStudioSolutionFileOperator.HasProjectReferences(
                solutionContext.FilePath,
                projectReferenceFilePaths,
                solutionContext.StringlyTypedPathOperator);

            return output;
        }

        public static async Task RemoveProjectReference(this IBasicSolutionContext solutionContext,
            string projectFilePath)
        {
            await solutionContext.VisualStudioSolutionFileOperator.RemoveProjectReference(
                solutionContext.FilePath,
                projectFilePath);
        }
    }
}
