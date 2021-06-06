using System;
using System.Collections.Generic;
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
            enumerableClrType.CSharpName = $"IEnumerable<{clrTypeInfo.CSharpName}>";
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

        public static void AddRequiredNamespaces(this ClrTypeInfo clrTypeInfo, IEnumerable<string> requiredNamespaces)
        {
            foreach (var requiredNamespace in requiredNamespaces)
            {
                clrTypeInfo.RequiredNamespaces.Add(requiredNamespace);
            }
        }
    }
}
