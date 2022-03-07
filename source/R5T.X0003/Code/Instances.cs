using System;

using R5T.T0034;
using R5T.T0036;
using R5T.T0045;
using R5T.T0098;


namespace R5T.X0003
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICompilationUnitGenerator CompilationUnitGenerator { get; } = T0045.CompilationUnitGenerator.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static IPropertyGenerator PropertyGenerator { get; } = T0045.PropertyGenerator.Instance;
        public static IPropertyName PropertyName { get; } = T0036.PropertyName.Instance;
        public static ITypeName TypeName { get; } = T0034.TypeName.Instance;
    }
}
