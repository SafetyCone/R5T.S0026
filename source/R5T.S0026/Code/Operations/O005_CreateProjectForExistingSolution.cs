﻿using System;
using System.Threading.Tasks;

using R5T.O0001;
using R5T.T0114;


namespace R5T.S0026
{
    /// <summary>
    /// Creates a new project in an existing solution.
    /// </summary>
    public class O005_CreateProjectForExistingSolution : T0020.IActionOperation
    {
        private CreateProjectForExistingSolution CreateProjectForExistingSolution { get; }


        public O005_CreateProjectForExistingSolution(
            CreateProjectForExistingSolution createProjectForExistingSolution)
        {
            this.CreateProjectForExistingSolution = createProjectForExistingSolution;
        }

        public async Task Run()
        {
            // Inputs.
            var solutionFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.E1000.Private\source\TestSolution.sln";
            var projectName = "TestProject";
            var projectDescription = "A test project.";
            var projectType = Instances.ProjectType.Console();

            // Run.
            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
                Type = projectType,
            };

            await this.CreateProjectForExistingSolution.Run(
                solutionFilePath,
                projectSpecification);
        }
    }
}
