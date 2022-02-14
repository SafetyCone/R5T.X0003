using System;
using System.Collections.Generic;

using R5T.T0045;

using Instances = R5T.X0003.Instances;


namespace System
{
    public static class ICodeFileGeneratorExtensions
    {
        public static void CreateInstances(this ICodeFileGenerator _,
            string filePath,
            string namespaceName,
            IEnumerable<string> extensionMethodBaseInterfaceNamespacedTypeNames = default)
        {
            var instancesCompilationUnit = Instances.CompilationUnitGenerator.CreateInstances(
                namespaceName,
                extensionMethodBaseInterfaceNamespacedTypeNames);

            instancesCompilationUnit.WriteToSynchronous(filePath);
        }
    }
}
