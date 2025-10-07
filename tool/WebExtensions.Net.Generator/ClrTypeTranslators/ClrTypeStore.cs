using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.ClrTypes;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.ClrTypeTranslators
{
    public class ClrTypeStore
    {
        private readonly Dictionary<string, ClrTypeInfo> clrTypeStore = [];

        public void Reset()
        {
            clrTypeStore.Clear();
            CreateClrTypeFromSystemType(typeof(bool));
            CreateClrTypeFromSystemType(typeof(int));
            CreateClrTypeFromSystemType(typeof(double));
            CreateClrTypeFromSystemType(typeof(string));
            CreateClrTypeFromSystemType(typeof(object));
            CreateClrTypeFromSystemType(typeof(EpochTime));
        }

        public void AddClrType(ClrTypeInfo clrTypeInfo)
            => clrTypeStore.Add(clrTypeInfo.Id, clrTypeInfo);

        public ClrTypeInfo GetClrType(TypeReference? typeReference, NamespaceEntity namespaceEntity)
        {
            ArgumentNullException.ThrowIfNull(typeReference);

            if (typeReference.Type == ObjectType.Array)
            {
                var arrayItemType = GetClrType(typeReference.ArrayItems, namespaceEntity);
                return arrayItemType.MakeEnumerableType();
            }

            if (typeReference.Type == ObjectType.Null && typeReference.Ref is null && typeReference.TypeChoices is null)
            {
                return GetClrType(typeof(void));
            }

            if (typeReference.Ref is null && typeReference.TypeChoices is not null)
            {
                return GetClrType(typeof(JsonElement));
            }

            if (typeReference.Type == ObjectType.Function)
            {
                return GetFunctionClrType(typeReference, namespaceEntity);
            }

            var typeId = GetTypeId(typeReference, namespaceEntity);

            return !clrTypeStore.TryGetValue(typeId, out var clrType)
                ? throw new InvalidOperationException($"Type id '{typeId}' is not defined in the CLR types store.")
                : clrType;
        }

        private ClrTypeInfo GetClrType(Type type)
        {
            if (type.FullName is null)
            {
                throw new InvalidOperationException("Type full name must not be null.");
            }

            if (!clrTypeStore.ContainsKey(type.FullName))
            {
                CreateClrTypeFromSystemType(type);
            }

            return clrTypeStore[type.FullName];
        }

        private void CreateClrTypeFromSystemType(Type type)
        {
            if (type.FullName is null)
            {
                throw new InvalidOperationException("Type full name must not be null.");
            }
            var clrTypeInfo = GetClrTypeFromSystemType(type);
            clrTypeStore.Add(type.FullName, clrTypeInfo);
        }

        private ClrTypeInfo GetClrTypeFromSystemType(Type type)
        {
#pragma warning disable CS8601, CS8604 // Type should not have these properties as null
            var clrTypeInfo = new ClrTypeInfo()
            {
                Id = type.FullName,
                Namespace = type.Namespace,
                Name = type.Name,
                FullName = type.FullName,
                CSharpName = type.Name,
                IsEnum = type.IsEnum,
                EnumValues = null,
                IsNullable = type.IsClass,
                IsInterface = type.IsInterface,
                IsNullType = type == typeof(void),
                IsGenericType = type.IsGenericType,
                GenericTypeArguments = [.. type.GenericTypeArguments.Select(GetClrTypeFromSystemType)],
                IsObsolete = false,
                ObsoleteMessage = null,
                IsGenerated = false,
                GeneratedNamespace = null,
                InitialGeneratedNamespace = null,
                RequiredNamespaces = new HashSet<string>(),
                ReferenceNamespaces = new HashSet<string>() { type.Namespace },
                Interfaces = new HashSet<string>(),
                BaseTypeName = null,
                Description = null,
                Metadata = new Dictionary<string, object>(),
                Methods = [],
                Properties = [],
                TypeChoices = null
            };
#pragma warning restore CS8601, CS8604

            if (type.IsGenericType)
            {
                clrTypeInfo.CSharpName = clrTypeInfo.CSharpName[..clrTypeInfo.CSharpName.IndexOf('`')];
            }

            switch (type.FullName)
            {
                case string fullName when fullName == typeof(bool).FullName:
                    clrTypeInfo.CSharpName = "bool";
                    clrTypeInfo.ReferenceNamespaces.Remove(type.Namespace);
                    break;
                case string fullName when fullName == typeof(int).FullName:
                    clrTypeInfo.CSharpName = "int";
                    clrTypeInfo.ReferenceNamespaces.Remove(type.Namespace);
                    break;
                case string fullName when fullName == typeof(double).FullName:
                    clrTypeInfo.CSharpName = "double";
                    clrTypeInfo.ReferenceNamespaces.Remove(type.Namespace);
                    break;
                case string fullName when fullName == typeof(string).FullName:
                    clrTypeInfo.CSharpName = "string";
                    clrTypeInfo.ReferenceNamespaces.Remove(type.Namespace);
                    break;
                case string fullName when fullName == typeof(object).FullName:
                    clrTypeInfo.CSharpName = "object";
                    clrTypeInfo.ReferenceNamespaces.Remove(type.Namespace);
                    break;
                case string fullName when fullName == typeof(void).FullName:
                    clrTypeInfo.CSharpName = "void";
                    clrTypeInfo.ReferenceNamespaces.Remove(type.Namespace);
                    break;
                case string fullName when fullName == typeof(EpochTime).FullName:
                    clrTypeInfo.ReferenceNamespaces.Remove(type.Namespace);
                    break;
            }

            return clrTypeInfo;
        }

        private ClrTypeInfo GetFunctionClrType(TypeReference typeReference, NamespaceEntity namespaceEntity)
        {
            if ((typeReference.FunctionParameters is null || !typeReference.FunctionParameters.Any()) && typeReference.FunctionReturns is null)
            {
                return GetClrType(typeof(Action));
            }

            var functionType = typeof(Action<>);
            var genericTypeArguments = new List<ClrTypeInfo>();

            if (typeReference.FunctionParameters is not null)
            {
                var parameterTypes = typeReference.FunctionParameters.Select(parameterDefinition =>
                {
                    var parameterType = GetClrType(parameterDefinition, namespaceEntity);
                    if (parameterDefinition.IsOptional && !parameterType.IsNullable)
                    {
                        parameterType = parameterType.MakeNullable();
                    }

                    return parameterType;
                });
                genericTypeArguments.AddRange(parameterTypes);
            }

            if (typeReference.FunctionReturns is not null)
            {
                var functionReturnClrType = GetClrType(typeReference.FunctionReturns, namespaceEntity);
                if (functionReturnClrType.FullName != typeof(void).FullName)
                {
                    functionType = typeof(Func<>);
                    genericTypeArguments.Add(functionReturnClrType);
                }
            }

            var clrType = GetClrTypeFromSystemType(functionType);
            clrType.GenericTypeArguments = genericTypeArguments;
            clrType.CSharpName = $"{clrType.CSharpName}<{string.Join(", ", genericTypeArguments.Select(genericTypeArgument => genericTypeArgument.CSharpName))}>";
            foreach (var genericTypeArgument in genericTypeArguments)
            {
                clrType.AddReferenceNamespaces(genericTypeArgument.ReferenceNamespaces);
                clrType.AddRequiredNamespaces(genericTypeArgument.RequiredNamespaces);
            }
            return clrType;
        }

        private string GetTypeId(TypeReference? typeReference, NamespaceEntity namespaceEntity)
        {
            ArgumentNullException.ThrowIfNull(typeReference);

            if (typeReference.Ref is not null)
            {
                if (typeReference.Ref.Contains('.') || string.IsNullOrEmpty(namespaceEntity.FullFormattedName))
                {
                    var capitalizedRef = string.Join('.', typeReference.Ref.Split('.').Select(x => x.ToCapitalCase()));
                    return $"{Constants.RelativeNamespaceToken}.{capitalizedRef}";
                }
                return $"{Constants.RelativeNamespaceToken}.{namespaceEntity.FullFormattedName}.{typeReference.Ref.ToCapitalCase()}";
            }

            return IsEpochMillisecondsType(typeReference)
                ? GetTypeFullName(typeof(EpochTime))
                : typeReference.Type switch
            {
                ObjectType.Array => GetTypeId(typeReference.ArrayItems, namespaceEntity) + "Array",
                ObjectType.Boolean => GetTypeFullName(typeof(bool)),
                ObjectType.Function => throw new InvalidOperationException($"Functions should be handled by the method '{nameof(GetFunctionClrType)}'."),
                ObjectType.Integer => GetTypeFullName(typeof(int)),
                ObjectType.Number => GetTypeFullName(typeof(double)),
                ObjectType.String => GetTypeFullName(typeof(string)),
                _ => GetTypeFullName(typeof(object))
            };
        }

        private static string GetTypeFullName(Type type)
            => type.FullName ?? throw new InvalidOperationException("Type full name should not be null.");

        private static bool IsEpochMillisecondsType(TypeReference typeReference)
            => (typeReference.Type is ObjectType.Integer or ObjectType.Number) && typeReference is PropertyDefinition { Description: not null } propertyDefinition && propertyDefinition.Description.Contains("milliseconds");
    }
}
