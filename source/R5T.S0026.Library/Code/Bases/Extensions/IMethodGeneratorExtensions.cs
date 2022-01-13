using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;


namespace System
{
    public static class IMethodGeneratorExtensions
    {
        public static MethodDeclarationSyntax GetAddHostStartupAddX(this IMethodGenerator _)
        {
            var text = $@"
public static IServiceCollection AddHostStartup(this IServiceCollection services)
{{
    var dependencyServiceActions = new DependencyServiceActionAggregation();

    services.AddHostStartup<HostStartup>(dependencyServiceActions)
        // Add services required by HostStartup, but not by HostStartupBase.
        ;

    return services;
}}
";
            var output = _.GetMethodDeclarationFromText(text);
            return output;
        }

        public static MethodDeclarationSyntax GetAddHostStartupAddXAction(this IMethodGenerator _)
        {
            var text = $@"
public static IServiceAction<HostStartup> AddStartupAction(this IServiceAction _)
{{
    var output = _.New<HostStartup>(services => services.AddHostStartup());

    return output;
}}
";
            var output = _.GetMethodDeclarationFromText(text);
            return output;
        }

        public static MethodDeclarationSyntax GetConfigureConfigurationEmpty(this IMethodGenerator _)
        {
            var text = $@"
public override Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
{{
    // Do nothing.

    return Task.CompletedTask;
}}
";
            var output = _.GetMethodDeclarationFromText(text);
            return output;
        }

        public static MethodDeclarationSyntax GetConfigureServicesStub(this IMethodGenerator _)
        {
            var text = $@"
protected override Task ConfigureServices(IServiceCollection services, IProvidedServiceActionAggregation providedServicesAggregation)
{{
    // Add services here.

    return Task.CompletedTask;
}}
";
            var output = _.GetMethodDeclarationFromText(text);
            return output;
        }

        public static MethodDeclarationSyntax GetFillRequiredServiceActionsNoneRequired(this IMethodGenerator _)
        {
            var text = $@"
protected override Task FillRequiredServiceActions(IRequiredServiceActionAggregation requiredServiceActions)
{{
    // Do nothing since none are required.

    return Task.CompletedTask;
}}
";
            var output = _.GetMethodDeclarationFromText(text);
            return output;
        }
    }
}
