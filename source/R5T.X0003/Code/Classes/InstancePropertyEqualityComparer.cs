using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.X0003
{
    /// <summary>
    /// <see cref="IEqualityComparer{T}"/> for instance class instance properties.
    /// </summary>
    public class InstancePropertyEqualityComparer : IEqualityComparer<PropertyDeclarationSyntax>
    {
        #region Static

        public static InstancePropertyEqualityComparer Instance { get; } = new();

        #endregion


        public bool Equals(PropertyDeclarationSyntax x, PropertyDeclarationSyntax y)
        {
            var xTypeExpression = x.GetTypeExpressionText();
            var yTypeExpression = y.GetTypeExpressionText();

            var xIdentifier = x.GetIdentifierText();
            var yIdentifier = y.GetIdentifierText();

            var xInitializationExpression = x.GetInitializationExpressionText();
            var yInitializationExpression = y.GetInitializationExpressionText();

            var output = true
                && xTypeExpression == yTypeExpression
                && xIdentifier == yIdentifier
                && xInitializationExpression == yInitializationExpression
                ;

            return output;
        }

        public int GetHashCode(PropertyDeclarationSyntax obj)
        {
            // Only use the identifier, since it must be unique in a class for the class to be valid.
            var identifier = obj.GetIdentifierText();

            var output = identifier.GetHashCode();
            return output;
        }
    }
}
