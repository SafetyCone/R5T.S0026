using System;


namespace R5T.S0026.Library
{
    public interface ICompilationUnitContextAggregation
    {
        IBasicSolutionContext SolutionContext { get; }
        IProjectContext ProjectContext { get; }
        ICompilationUnitContext CompilationUnitContext { get; }
    }
}
