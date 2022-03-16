using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.S0026.Library;


namespace System
{
    public static class ISolutionContextExtensions
    {
        public static async Task AddDependencyProjectReference(this ISolutionContext solutionContext,
            string dependencyProjectReferenceIdentityString)
        {
            await solutionContext.AddDependencyProjectReferences(
                EnumerableHelper.From(dependencyProjectReferenceIdentityString));
        }

        public static async Task AddDependencyProjectReferences(this ISolutionContext solutionContext,
            IEnumerable<string> dependencyProjectReferenceIdentityStrings)
        {
            var dependencyProjectReferenceFilePaths = await Instances.ProjectOperator.GetFilePathsForProjectIdentityStrings(
                dependencyProjectReferenceIdentityStrings,
                solutionContext.ProjectRepository);

            await Instances.SolutionOperator.AddDependencyProjectReferencesAndRecursiveDependencies(
                solutionContext.FilePath,
                dependencyProjectReferenceFilePaths,
                solutionContext.StringlyTypedPathOperator,
                solutionContext.VisualStudioProjectFileReferencesProvider,
                solutionContext.VisualStudioSolutionFileOperator);
        }
    }
}
