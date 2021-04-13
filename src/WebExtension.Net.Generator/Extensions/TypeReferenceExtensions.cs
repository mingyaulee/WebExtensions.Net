using System;
using System.Collections.Generic;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Extensions
{
    public static class TypeReferenceExtensions
    {
        public static string ToTypeName(this TypeReference? typeReference, ISet<string>? usingNamespaces = null, bool makeNullable = false)
        {
            if (typeReference is null)
            {
                throw new ArgumentNullException(nameof(typeReference));
            }

            if (typeReference.Ref is not null)
            {
                return HandleRefValue(typeReference.Ref);
            }

            switch (typeReference.Type)
            {
                case ObjectType.Array:
                    if (typeReference.ArrayItems is null)
                    {
                        throw new InvalidOperationException("Array type must have array items value.");
                    }
                    usingNamespaces?.Add("System.Collections.Generic");
                    return $"IEnumerable<{typeReference.ArrayItems.ToTypeName(usingNamespaces, makeNullable)}>";
                case ObjectType.Boolean:
                    return "bool" + (makeNullable ? "?" : string.Empty);
                case ObjectType.Function:
                    usingNamespaces?.Add("System");
                    return "Action";
                case ObjectType.Integer:
                    return "int" + (makeNullable ? "?" : string.Empty);
                case ObjectType.Number:
                    return "double" + (makeNullable ? "?" : string.Empty);
                case ObjectType.String:
                    return "string";
                default:
                    return "object";
            }
        }

        private static string HandleRefValue(string reference)
        {
            if (reference.Contains('.'))
            {
                return reference.ToCapitalCase();
            }
            return reference;
        }
    }
}
