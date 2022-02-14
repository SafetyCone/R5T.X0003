using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.X0003.Instances;


namespace System
{
    public static class ICompilationUnitGeneratorExtensions
    {
        public static CompilationUnitSyntax CreateInstances(this ICompilationUnitGenerator _,
            string namespaceName,
            IEnumerable<string> extensionMethodBaseInterfaceNamespacedTypeNames = default)
        {
            var distinctExtensionMethodBaseInterfaceNamespacedTypeNames = extensionMethodBaseInterfaceNamespacedTypeNames
                .EmptyIfDefault()
                .Distinct()
                ;

            // Get namespaces.
            var extensionMethodBaseNamespaceNames = distinctExtensionMethodBaseInterfaceNamespacedTypeNames
                .Select(x => Instances.NamespacedTypeName.GetNamespaceName(x))
                .OrderAlphabetically()
                .Now();

            // Compute instance tuples.
            var instanceTuples = distinctExtensionMethodBaseInterfaceNamespacedTypeNames
                .Select(x =>
                {
                    var embNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(x);
                    var embInterfaceTypeName = Instances.NamespacedTypeName.GetTypeName(x);
                    var embTypeName = Instances.TypeName.GetTypeNameStemFromInterfaceName(embInterfaceTypeName);
                    var embNamespacedTypeName = Instances.NamespacedTypeName.GetNamespacedName(
                        embNamespaceName,
                        embTypeName);

                    var embTypeRelativeNamespacedTypeName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeName(
                        embNamespacedTypeName,
                        namespaceName);

                    var initializationExpression = $"{embTypeRelativeNamespacedTypeName}.{Instances.PropertyName.Instance()}";

                    var propertyName = embTypeName;

                    return (embInterfaceTypeName, propertyName, initializationExpression);
                })
                .Now();

            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    // System namespace already added.
                    xNamespaceNames.AddRange(extensionMethodBaseNamespaceNames);

                    var instancesClass = Instances.ClassGenerator.CreateInstances(instanceTuples);

                    var outputNamespace = xNamespace.AddClass(instancesClass);
                    return outputNamespace;
                });

            return output;
        }
    }
}
