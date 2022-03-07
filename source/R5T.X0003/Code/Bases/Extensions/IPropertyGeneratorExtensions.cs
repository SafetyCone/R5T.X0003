using System;
using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<PropertyDeclarationSyntax> GetInstancesInstanceProperties(this IPropertyGenerator _,
            IEnumerable<(string ExtensionMethodBaseInterfaceTypeName, string PropertyName, string InitializationExpression)> instanceTuples)
        {
            var output = instanceTuples
                .Select(x => _.GetInstancesInstanceProperty(
                    x.ExtensionMethodBaseInterfaceTypeName,
                    x.PropertyName,
                    x.InitializationExpression));

            return output;
        }
    }
}
