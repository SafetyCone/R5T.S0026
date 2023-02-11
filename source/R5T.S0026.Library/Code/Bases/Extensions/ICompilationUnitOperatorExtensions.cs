using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;


namespace R5T.S0026.Library
{
    public static partial class ICompilationUnitOperatorExtensions
    {
        public static async Task<CompilationUnitSyntax> ModifyHostStartup_AddSerializeServiceCollectionAudit(this ICompilationUnitOperator _,
            CompilationUnitSyntax compilationUnit)
        {
            // Inputs.
            //var servicesParameterName = "services"; // TODO, find in method signature.
            var serviceCollectionAuditSerializerActionMethodName = "ServiceCollectionAuditSerializerAction";
            var servicesPlatformVariableName = "servicesPlatform";
            var afterActionName = $"{servicesPlatformVariableName}.ConfigurationAuditSerializerAction";
            var runMethodName = "Run";

            // Acquire the services.Run() fluent statement.
            //  // Find the first services run statement.
            //      // First statement marked with R5T.T0063.IServiceCollectionExtensions.MarkAsServiceCollectonConfigurationStatement() extension method.
            //      // Else, first statement starting with the variable name of the IServiceCollection typed input parameter.
            //  // If not found, create the root services run statement.

            var outputCompilationUnit = await compilationUnit.ModifyClassMethod(
                Instances.Selector.ClassNamed(Instances.ClassName.HostStartup()),
                Instances.Selector.MethodNamed(Instances.MethodName.ConfigureServices()),
                async method =>
                {
                    var outputMethod = await method.ModifyMethodBody(
                        methodBody =>
                        {
                            // Acquire the services statement (find or create new if none found).
                            var (outputMethodBody, servicesStatement) = Instances.StatementOperator.AcquireServicesConfigurationStatement(methodBody);

                            // Get the prior run statement.
                            var afterRunInvocation = servicesStatement.DescendantNodes()
                                .Where(Instances.Selector.IsServiceCollectionConfigurationStatementRunInvocationExpression(afterActionName))
                                .Cast<InvocationExpressionSyntax>()
                                .Single();

                            var newServicesStatement = Instances.StatementOperator.InsertFluentMethodCallAfter(
                                servicesStatement,
                                runMethodName,
                                afterRunInvocation,
                                SyntaxFactory.ArgumentList(
                                    SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName(servicesPlatformVariableName),
                                                SyntaxFactory.IdentifierName(serviceCollectionAuditSerializerActionMethodName))))));

                            outputMethodBody = outputMethodBody.ReplaceNode(servicesStatement, newServicesStatement);

                            return Task.FromResult(outputMethodBody);
                        });

                    return outputMethod;
                });

            return outputCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> ModifyHostStartup_AddSerializeConfigurationAudit(this ICompilationUnitOperator _,
            CompilationUnitSyntax compilationUnit)
        {
            // Inputs.
            //var servicesParameterName = "services"; // TODO, find in method signature.
            var configureAuditSerializerActionName = "ConfigurationAuditSerializerAction";
            var servicesPlatformVariableName = "servicesPlatform";
            var runMethodName = "Run";

            // Acquire the services.Run() fluent statement.
            //  // Find the first services run statement.
            //      // First statement marked with R5T.T0063.IServiceCollectionExtensions.MarkAsServiceCollectonConfigurationStatement() extension method.
            //      // Else, first statement starting with the variable name of the IServiceCollection typed input parameter.
            //  // If not found, create the root services run statement.

            var outputCompilationUnit = await compilationUnit.ModifyClassMethod(
                Instances.Selector.ClassNamed(Instances.ClassName.HostStartup()),
                Instances.Selector.MethodNamed(Instances.MethodName.ConfigureServices()),
                async method =>
                {
                    var outputMethod = await method.ModifyMethodBody(
                        methodBody =>
                        {
                            // Acquire the services statement (find or create new if none found).
                            var (outputMethodBody, servicesStatement) = Instances.StatementOperator.AcquireServicesConfigurationStatement(methodBody);

                            // Modify the services statement.
                            //  // Wrap the invocation expression of the services expression statement in a call to services.Run(servicesPlatform.ConfigurationAuditSerializerAction) (this puts the call at the end of the fluent chain).
                            //  // I.e. another invocation expression, with an arguments list, that is a member access expression.
                            var existingInvocationExpression = servicesStatement.Expression as InvocationExpressionSyntax;

                            var newMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                existingInvocationExpression.WithoutTrailingTrivia(), // Remove any existing trailing trivia.
                                SyntaxFactory.IdentifierName(runMethodName))
                                .WithIndentedDotToken(Instances.Indentation.Statement().IndentByTab()); // Indent the following dot token.

                            var newInvocationExpression = SyntaxFactory.InvocationExpression(
                                newMemberAccessExpression,
                                SyntaxFactory.ArgumentList(
                                    SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName(servicesPlatformVariableName),
                                                SyntaxFactory.IdentifierName(configureAuditSerializerActionName))))));

                            var newServicesStatement = servicesStatement.WithExpression(newInvocationExpression)
                                .WithSemicolonIndentation(Instances.Indentation.Statement().IndentByTab());

                            outputMethodBody = outputMethodBody.ReplaceNode(servicesStatement, newServicesStatement);

                            return Task.FromResult(outputMethodBody);
                        });

                    return outputMethod;
                });

            return outputCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> ModifyHostStartup_Initial(this ICompilationUnitOperator _,
            CompilationUnitSyntax hostStartupCompilationUnit,
            string namespaceName)
        {
            // Get using directives.
            var usingDirectives = hostStartupCompilationUnit.GetUsingDirectivesSpecification();

            usingDirectives.AddUsingNamespaceNames(
                Instances.NamespaceName.Values().System(),
                Instances.NamespaceName.Values().System_Threading_Tasks(),
                Instances.NamespaceName.Values().Microsoft_Extensions_Configuration(),
                Instances.NamespaceName.Values().Microsoft_Extensions_DependencyInjection(),
                Instances.NamespaceName.Values().R5T_D0088_I0002());

            var outputHostStartupCompilationUnit = await hostStartupCompilationUnit
                .SetUsings(usingDirectives)
                .InNamespace(namespaceName,
                @namespace =>
                {
                    var hostStartupClass = Instances.ClassGenerator.CreateHostStartup_Initial();

                    var outputNamespace = @namespace.AddClass(hostStartupClass);

                    return Task.FromResult(outputNamespace);
                })
                ;

            return outputHostStartupCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> ModifyHostStartup_AddA0003(this ICompilationUnitOperator _,
            CompilationUnitSyntax compilationUnit)
        {
            // Add using directives.
            var usingDirectives = compilationUnit.GetUsingDirectivesSpecification();

            usingDirectives.AddUsingNamespaceNames(
                "R5T.A0003",
                "R5T.Magyar",
                "R5T.D0081.I001",
                "R5T.Ostrogothia.Rivet",
                "R5T.D0048.Default",
                "R5T.T0063");

            usingDirectives.AddAliases(
                ("IProvidedServiceActionAggregation", "R5T.D0088.I0002.IProvidedServiceActionAggregation"),
                ("IRequiredServiceActionAggregation", "R5T.D0088.I0002.IRequiredServiceActionAggregation"),
                ("ServicesPlatformRequiredServiceActionAggregation", "R5T.A0003.RequiredServiceActionAggregation"));

            var outputCompilationUnit = compilationUnit.SetUsings(usingDirectives);

            // Add code in ConfigureServices method.
            // Identify and modify HostStartup class.
            outputCompilationUnit = await outputCompilationUnit.ModifyClass(
                Instances.Selector.ClassNamed(Instances.ClassName.HostStartup()),
                async hostStartupClass =>
                {
                    // Identify and modify ConfigureServices method.
                    var outputHostStartupClass = await hostStartupClass.ModifyMethodBody(
                        Instances.Selector.MethodNamed(Instances.MethodName.ConfigureServices()),
                        methodBody =>
                        {
                            var outputMethodBody = methodBody;

                            // Add Inputs variables.
                            var inputVariableStatementTexts = new[]
                            {
                                @"
// Inputs.
var executionSynchronicityProviderAction = Instances.ServiceAction.AddConstructorBasedExecutionSynchronicityProviderAction(Synchronicity.Synchronous);
",
                                @"var organizationProviderAction = Instances.ServiceAction.AddOrganizationProviderAction(); // Rivet organization.",
                                @"var rootOutputDirectoryPathProviderAction = Instances.ServiceAction.AddConstructorBasedRootOutputDirectoryPathProviderAction(@""C:\Temp\Output"");"
                            }
                            ;

                            var inputVariableStatements = Instances.StatementGenerator.GetStatementsFromText(inputVariableStatementTexts).Now();

                            // Add services platform.
                            var hostStartupNamespaceName = hostStartupClass.GetNamespaceName();

                            var iMachineMessageOutputSinkProviderNamespaceRelativeTypeName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeName(
                                "R5T.D0099.D002.IMachineMessageOutputSinkProvider",
                                hostStartupNamespaceName);

                            var iMachineMessageTypeJsonSerializationHandlerRelativeTypeName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeName(
                                "R5T.D0098.IMachineMessageTypeJsonSerializationHandler",
                                hostStartupNamespaceName);

                            var servicesPlatformStatementTexts = new[]
                            {
$@"
// Services platform.
var servicesPlatformRequiredServiceActionAggregation = new ServicesPlatformRequiredServiceActionAggregation
{{
    ConfigurationAction = providedServicesAggregation.ConfigurationAction,
    ExecutionSynchronicityProviderAction = executionSynchronicityProviderAction,
    LoggerAction = providedServicesAggregation.LoggerAction,
    LoggerFactoryAction = providedServicesAggregation.LoggerFactoryAction,
    MachineMessageOutputSinkProviderActions = EnumerableHelper.Empty<IServiceAction<{iMachineMessageOutputSinkProviderNamespaceRelativeTypeName}>>(),
    MachineMessageTypeJsonSerializationHandlerActions = EnumerableHelper.Empty<IServiceAction<{iMachineMessageTypeJsonSerializationHandlerRelativeTypeName}>>(),
    OrganizationProviderAction = organizationProviderAction,
    RootOutputDirectoryPathProviderAction = rootOutputDirectoryPathProviderAction,
}};
",
@"
var servicesPlatform = Instances.ServiceAction.AddProvidedServiceActionAggregation(
    servicesPlatformRequiredServiceActionAggregation);
"
                            }
                            ;

                            var servicesPlatformStatements = Instances.StatementGenerator.GetStatementsFromText(servicesPlatformStatementTexts).Now();

                            var allStatements = inputVariableStatements.Concat(servicesPlatformStatements);

                            // Separate all statements, except the first, with blank lines.
                            var statements = allStatements
                                .TakeFirst2()
                                .Concat(allStatements
                                    .SkipFirst()
                                    .PrependBlankLine()) // All statements should start on a new line.
                                .Now();

                            // Insert before the last existing statement (return Task.CompletedTask).
                            var firstStatement = outputMethodBody.Statements.First();

                            outputMethodBody = outputMethodBody.InsertStatementsBefore(
                                firstStatement,
                                statements,
                                true);

                            // Set new lines for the last statement.
                            outputMethodBody = outputMethodBody.ReplaceNodeSynchronous(
                                xMethodBody => xMethodBody.Statements.Last(),
                                xStatement =>
                                {
                                    var outputStatement = xStatement
                                        .SetIndentationPreservingNonWhitespaceTrivia(Instances.Indentation.Statement())
                                        //.PrependBlankLine()
                                        ;

                                    return outputStatement;
                                });

                            return Task.FromResult(outputMethodBody);
                        });

                    return outputHostStartupClass;
                });

            return outputCompilationUnit;
        }
    }
}
