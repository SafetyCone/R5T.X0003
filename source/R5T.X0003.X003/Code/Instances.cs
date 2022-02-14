using System;

using R5T.T0037;
using R5T.T0041;


namespace R5T.X0003.X003
{
    public static class Instances
    {
        public static ICodeFileName CodeFileName { get; } = T0037.CodeFileName.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
    }
}
