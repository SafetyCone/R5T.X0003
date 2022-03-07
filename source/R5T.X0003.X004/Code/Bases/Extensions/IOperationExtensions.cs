using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0098;

using Instances = R5T.X0003.X004.Instances;


namespace System
{
    public static class IOperationExtensions
    {
        public static
            (string ExtensionMethodBaseInterfaceTypeName, string PropertyName, string InitializationExpression)
        GetInstanceTuple(this IOperation _,
            string extensionMethodBaseInterfaceTypeNamespacedTypeName,
            string containingNamespaceName)
        {
            var embNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(extensionMethodBaseInterfaceTypeNamespacedTypeName);
            var embInterfaceTypeName = Instances.NamespacedTypeName.GetTypeName(extensionMethodBaseInterfaceTypeNamespacedTypeName);
            var embTypeName = Instances.TypeName.GetTypeNameStemFromInterfaceName(embInterfaceTypeName);
            var embNamespacedTypeName = Instances.NamespacedTypeName.GetNamespacedName(
                embNamespaceName,
                embTypeName);

            var embTypeRelativeNamespacedTypeName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeName(
                embNamespacedTypeName,
                containingNamespaceName);

            var initializationExpression = $"{embTypeRelativeNamespacedTypeName}.{Instances.PropertyName.Instance()}";

            var propertyName = embTypeName;

            return (embInterfaceTypeName, propertyName, initializationExpression);
        }

        public static
            IEnumerable<(string ExtensionMethodBaseInterfaceTypeName, string PropertyName, string InitializationExpression)>
        GetInstanceTuples(this IOperation _,
            IEnumerable<string> extensionMethodBaseInterfaceTypeNamespacedTypeNames,
            string containingNamespaceName)
        {
            var output = extensionMethodBaseInterfaceTypeNamespacedTypeNames
                .Select(xExtensionMethodBaseInterfaceTypeNamespacedTypeName => _.GetInstanceTuple(
                    xExtensionMethodBaseInterfaceTypeNamespacedTypeName,
                    containingNamespaceName))
                ;

            return output;
        }
    }
}