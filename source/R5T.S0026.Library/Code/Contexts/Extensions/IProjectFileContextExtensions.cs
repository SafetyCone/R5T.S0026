using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.S0026.Library
{
    public static partial class IProjectFileContextExtensions
    {
        public static async Task<T> AddDependencyProjectReference<T>(this T projectFileContext,
            string projectReferenceFilePath)
            where T : IProjectFileContext
        {
            var output = await projectFileContext.AddDependencyProjectReferences(
                EnumerableHelper.From(projectReferenceFilePath));

            return output;
        }

        public static async Task<T> AddDependencyProjectReferences<T>(this T projectFileContext,
            IEnumerable<string> projectReferenceFilePaths)
            where T : IProjectFileContext
        {
            // Add the project reference to the project.
            await projectFileContext.VisualStudioProjectFileOperator.AddProjectReferences(
                projectFileContext.ProjectFilePath,
                projectReferenceFilePaths);

            // Add the project reference and all dependency project references to the solution.
            var recursiveProjectReferences = await Instances.ProjectOperator.GetAllRecursiveProjectReferencesInclusive(
                projectReferenceFilePaths,
                projectFileContext.VisualStudioProjectFileReferencesProvider);

            await projectFileContext.VisualStudioSolutionFileOperator.AddDependencyProjectReferences(
                projectFileContext.SolutionFilePath,
                recursiveProjectReferences);

            return projectFileContext;
        }

        public static CompilationUnitModificationContext GetCodeFileModificationContext(this IProjectFileContext projectFileContext,
            string codeFilePath,
            CompilationUnitSyntax compilationUnit)
        {
            var output = new CompilationUnitModificationContext
            {
                CodeFilePath = codeFilePath,
                ProjectFilePath = projectFileContext.ProjectFilePath,
                SolutionFilePath = projectFileContext.SolutionFilePath,
                VisualStudioProjectFileOperator = projectFileContext.VisualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = projectFileContext.VisualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = projectFileContext.VisualStudioSolutionFileOperator,
                CompilationUnit = compilationUnit,
            };

            return output;
        }
    }
}
