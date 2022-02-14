using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;


namespace System
{
    public static class IPropertyGeneratorExtensions
    {
        public static PropertyDeclarationSyntax GetInstancesInstanceProperty(this IPropertyGenerator _,
            string typeName,
            string propertyName,
            string initializationExpression)
        {
            var output = _.GetStaticPropertyInitialized(
                typeName,
                propertyName,
                initializationExpression);

            return output;
        }
    }
}
