using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.X0003.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax CreateInstances(this IClassGenerator _,
            IEnumerable<(string ExtensionMethodBaseInterfaceTypeName, string PropertyName, string InitializationExpression)> instanceTuples = default)
        {
            var properties = instanceTuples is object
                ? instanceTuples
                    .OrderAlphabetically(xTuple => xTuple.ExtensionMethodBaseInterfaceTypeName)
                    .Select(xTuple => Instances.PropertyGenerator.GetInstancesInstanceProperty(
                        xTuple.ExtensionMethodBaseInterfaceTypeName,
                        xTuple.PropertyName,
                        xTuple.InitializationExpression)
                        .IndentStartLine(Instances.Indentation.Property()))
                    .Now()
                : Array.Empty<PropertyDeclarationSyntax>()
                ;

            var output = _.GetPublicStaticClass(Instances.ClassName.Instances())
                .AddMembers(properties)
                ;

            return output;
        }
    }
}
