using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0060;


namespace R5T.S0026.Library
{
    public static class ISelectorExtensions
    {
        public static Func<SyntaxNode, bool> IsServiceCollectionConfigurationStatementRunInvocationExpression(this ISelector _,
            string runArgument)
        {
            var runMethodName = "Run";

            return xNode =>
            {
                if(xNode is InvocationExpressionSyntax invocationExpression
                && invocationExpression.ArgumentList.Arguments.ToFullString() == runArgument
                && invocationExpression.Expression is MemberAccessExpressionSyntax memberAccessExpression
                && memberAccessExpression.IsKind(SyntaxKind.SimpleMemberAccessExpression)
                && memberAccessExpression.Name.Identifier.Text == runMethodName)
                {
                    return true;
                }

                return false;
            };
        }

        public static Func<SyntaxNode, bool> IsBuildExpression(this ISelector _)
        {
            // Inputs.
            var buildMethodName = "Build";

            var output = _.IsMemberAccessExpressionWithMemberName(buildMethodName);
            return output;
        }
    }
}
