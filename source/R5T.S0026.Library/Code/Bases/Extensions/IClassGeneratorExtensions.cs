using System;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.S0026.Library.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax CreateHostStartup_Initial(this IClassGenerator _)
        {
            var configureConfigurationMethod = Instances.MethodGenerator.GetConfigureConfigurationEmpty();
            var configureServicesMethod = Instances.MethodGenerator.GetConfigureServicesStub();
            var fillRequiredServiceActionsMethod = Instances.MethodGenerator.GetFillRequiredServiceActionsNoneRequired();

            var methods = new[]
            {
                configureConfigurationMethod,
                configureServicesMethod,
                fillRequiredServiceActionsMethod,
            }
            //.Select(x => x.IndentBlock(Instances.Indentation.Method()))
            .Now();

            var output = _.GetPublicClass(
                Instances.ClassName.HostStartup(),
                Instances.TypeName.HostStartupBase()) // Namespace handled elsewhere.
                .AddMethods(methods)
                ;

            return output;
        }

        public static ClassDeclarationSyntax CreateIServiceActionExtensions_Initial(this IClassGenerator _)
        {
            var addHostStartupAddXAction = Instances.MethodGenerator.GetAddHostStartupAddXAction()
                .IndentBlock(Instances.Indentation.Method())
                ;

            var output = _.GetPublicStaticPartialClass(
                Instances.TypeName.IServiceActionExtensions())
                .AddMembers(addHostStartupAddXAction)
                ;

            return output;
        }

        public static ClassDeclarationSyntax CreateIServiceCollectionExtensions_Initial(this IClassGenerator _)
        {
            var addHostStartupAddX = Instances.MethodGenerator.GetAddHostStartupAddX()
                .IndentBlock(Instances.Indentation.Method())
                ;

            var output = _.GetPublicStaticPartialClass(
                Instances.TypeName.IServiceCollectionExtensions())
                .AddMembers(addHostStartupAddX)
                ;

            return output;
        }
    }
}
