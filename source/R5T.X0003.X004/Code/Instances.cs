using System;

using R5T.T0034;
using R5T.T0036;


namespace R5T.X0003.X004
{
    public static class Instances
    {
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static IPropertyName PropertyName { get; } = T0036.PropertyName.Instance;
        public static ITypeName TypeName { get; } = T0034.TypeName.Instance;
    }
}
