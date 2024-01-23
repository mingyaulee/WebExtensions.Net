using System;
using System.Collections.Generic;
using System.Text.Json;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.Extensions
{
    public static class ClrTypeInfoExtensions
    {
        public static ClrTypeInfo MakeEnumerableType(this ClrTypeInfo clrTypeInfo)
        {
            var enumerableClrType = (ClrTypeInfo)clrTypeInfo.Clone();
            enumerableClrType.IsGenericType = true;
            enumerableClrType.IsInterface = true;
            enumerableClrType.IsNullable = true;
            enumerableClrType.GenericTypeArguments = new[] { clrTypeInfo };
#pragma warning disable CS8601 // Possible null reference assignment.
            enumerableClrType.FullName = typeof(IEnumerable<>).FullName;
#pragma warning restore CS8601 // Possible null reference assignment.
            enumerableClrType.CSharpNameGetter = () => $"IEnumerable<{clrTypeInfo.CSharpName}>";
            enumerableClrType.ReferenceNamespaces.Add("System.Collections.Generic");
            return enumerableClrType;
        }

        public static ClrTypeInfo MakeNullable(this ClrTypeInfo clrTypeInfo)
        {
            if (clrTypeInfo.IsNullable)
            {
                throw new InvalidOperationException($"Type '{clrTypeInfo.FullName}' is already nullable.");
            }
            var genericClrType = (ClrTypeInfo)clrTypeInfo.Clone();
            genericClrType.CSharpName += "?";
            genericClrType.IsNullable = true;
            return genericClrType;
        }

        public static ClrTypeInfo MakeJsonElement(this ClrTypeInfo clrTypeInfo)
        {
            var type = typeof(JsonElement);
            var jsonElementClrType = (ClrTypeInfo)clrTypeInfo.Clone();
            jsonElementClrType.CSharpName = type.Name;
#pragma warning disable CS8601, CS8604 // Type should not have these properties as null
            jsonElementClrType.Id = type.FullName;
            jsonElementClrType.Namespace = type.Namespace;
            jsonElementClrType.ReferenceNamespaces.Add(type.Namespace);
#pragma warning restore CS8601, CS8604
            return jsonElementClrType;
        }

        public static void AddReferenceNamespaces(this ClrTypeInfo clrTypeInfo, IEnumerable<string> referenceNamespaces)
        {
            foreach (var referenceNamespace in referenceNamespaces)
            {
                clrTypeInfo.ReferenceNamespaces.Add(referenceNamespace);
            }
        }

        public static void AddRequiredNamespaces(this ClrTypeInfo clrTypeInfo, IEnumerable<string> requiredNamespaces)
        {
            foreach (var requiredNamespace in requiredNamespaces)
            {
                clrTypeInfo.RequiredNamespaces.Add(requiredNamespace);
            }
        }
    }
}
