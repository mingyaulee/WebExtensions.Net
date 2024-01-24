using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.ClrTypes;
using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.ClrTypeTranslators
{
    public class ClassEntityTranslator
    {
        private readonly ClrTypeStore clrTypeStore;
        private readonly FunctionDefinitionTranslator functionDefinitionTranslator;
        private readonly PropertyDefinitionTranslator propertyDefinitionTranslator;
        private readonly ClassTranslationOptions classTranslationOptions;

        public ClassEntityTranslator(ClrTypeStore clrTypeStore, FunctionDefinitionTranslator functionDefinitionTranslator, PropertyDefinitionTranslator propertyDefinitionTranslator, ClassTranslationOptions classTranslationOptions)
        {
            this.clrTypeStore = clrTypeStore;
            this.functionDefinitionTranslator = functionDefinitionTranslator;
            this.propertyDefinitionTranslator = propertyDefinitionTranslator;
            this.classTranslationOptions = classTranslationOptions;
        }

        public IEnumerable<ClrTypeInfo> ShallowTranslate(ClassEntity classEntity)
        {
            var classEntityName = classEntity.FormattedName;
            if (classTranslationOptions.Aliases.ContainsKey(classEntityName))
            {
                classEntityName = classTranslationOptions.Aliases[classEntityName];
            }

            foreach (var replace in classTranslationOptions.ReplaceNames)
            {
                classEntityName = classEntityName.Replace(replace.Key, replace.Value);
            }

            var namespaceName = classEntity.NamespaceEntity.FullFormattedName;
            if (namespaceName is not null && classTranslationOptions.NamespaceAliases.ContainsKey(namespaceName))
            {
                namespaceName = classTranslationOptions.NamespaceAliases[namespaceName];
            }
            var @namespace = FullyQualifyNamespace(namespaceName);

            var clrTypeInfo = new ClrTypeInfo()
            {
                Id = $"{FullyQualifyNamespace(classEntity.NamespaceEntity.FullFormattedName)}.{classEntity.FormattedName}",
                Namespace = @namespace,
                Name = classEntity.Name,
                FullName = $"{@namespace}.{classEntity.FormattedName}",
                CSharpName = classEntityName,
                IsNullable = classEntity.Type != ClassType.EnumClass,
                IsEnum = classEntity.Type == ClassType.EnumClass,
                EnumValues = classEntity.Type == ClassType.EnumClass ? classEntity.Properties.Select(EnumPropertyDefinitionTranslator.TranslatePropertyDefinition).ToArray() : null,
                IsInterface = false,
                IsNullType = false,
                IsGenericType = false,
                GenericTypeArguments = Enumerable.Empty<ClrTypeInfo>(),
                IsObsolete = classEntity.TypeDefinition.IsDeprecated,
                ObsoleteMessage = classEntity.TypeDefinition.Deprecated,
                IsGenerated = true,
                GeneratedNamespace = namespaceName,
                InitialGeneratedNamespace = classEntity.NamespaceEntity.FullFormattedName,
                RequiredNamespaces = new HashSet<string>(),
                ReferenceNamespaces = new HashSet<string>() { @namespace },
                Interfaces = new HashSet<string>(),
                BaseTypeName = classEntity.BaseClassName,
                Description = classEntity.Description,
                Metadata = new Dictionary<string, object>()
                {
                    { Constants.TypeMetadata.ClassType, classEntity.Type },
                    { Constants.TypeMetadata.ApiNamespace, classEntity.NamespaceEntity.Name }
                }
            };

            if (classEntity.ImplementInterface)
            {
                var interfaceTypeName = $"I{classEntity.FormattedName}";
                clrTypeInfo.Interfaces.Add(interfaceTypeName);
                var interfaceClrTypeInfo = (ClrTypeInfo)clrTypeInfo.Clone();
                interfaceClrTypeInfo.Id = $"{@namespace}.{interfaceTypeName}";
                interfaceClrTypeInfo.Name = interfaceTypeName;
                interfaceClrTypeInfo.FullName = $"{@namespace}.{interfaceTypeName}";
                interfaceClrTypeInfo.CSharpName = $"I{classEntityName}";
                interfaceClrTypeInfo.IsInterface = true;
                interfaceClrTypeInfo.Interfaces = new HashSet<string>();
                interfaceClrTypeInfo.BaseTypeName = null;

                clrTypeStore.AddClrType(interfaceClrTypeInfo);
                yield return interfaceClrTypeInfo;
            }

            clrTypeStore.AddClrType(clrTypeInfo);
            yield return clrTypeInfo;
        }

        public void DeepTranslate(ClassEntity classEntity, ClrTypeInfo clrTypeInfo)
        {
            if (clrTypeInfo.BaseTypeName is not null && clrTypeInfo.BaseTypeName.Contains('.'))
            {
                var namespaceSeparatorIndex = clrTypeInfo.BaseTypeName.LastIndexOf('.');
                clrTypeInfo.RequiredNamespaces.Add(clrTypeInfo.BaseTypeName[..namespaceSeparatorIndex]);
                clrTypeInfo.BaseTypeName = clrTypeInfo.BaseTypeName[(namespaceSeparatorIndex + 1)..];
            }

            clrTypeInfo.Methods = classEntity.Functions.Select(functionDefinition => functionDefinitionTranslator.TranslateFunctionDefinition(functionDefinition, classEntity.NamespaceEntity, clrTypeInfo)).ToArray();
            clrTypeInfo.Properties = classEntity.Properties.Select(propertyDefinitionPair => propertyDefinitionTranslator.TranslatePropertyDefinition(propertyDefinitionPair.Key, propertyDefinitionPair.Value, classEntity.NamespaceEntity, clrTypeInfo)).ToArray();

            if (classEntity.Type == ClassType.ArrayClass)
            {
                var arrayItemClrType = clrTypeStore.GetClrType(classEntity.TypeDefinition.ArrayItems, classEntity.NamespaceEntity);
                clrTypeInfo.BaseTypeName = clrTypeInfo.BaseTypeName?.Replace(Constants.ArrayTypeToken, arrayItemClrType.CSharpName);
                clrTypeInfo.AddRequiredNamespaces(arrayItemClrType.ReferenceNamespaces);
            }

            if (classEntity.Type == ClassType.MultitypeClass)
            {
                clrTypeInfo.TypeChoices = classEntity.TypeDefinition.TypeChoices?.Select(typeChoice =>
                {
                    var choiceClrTypeInfo = clrTypeStore.GetClrType(typeChoice, classEntity.NamespaceEntity);
                    clrTypeInfo.AddRequiredNamespaces(choiceClrTypeInfo.ReferenceNamespaces);
                    return choiceClrTypeInfo;
                }).ToArray();
            }

            if (classEntity.Type == ClassType.StringFormatClass)
            {
                if (classEntity.TypeDefinition.StringFormat is not null)
                {
                    clrTypeInfo.Metadata.Add(Constants.TypeMetadata.StringFormat, classEntity.TypeDefinition.StringFormat);
                }

                if (classEntity.TypeDefinition.StringPattern is not null)
                {
                    clrTypeInfo.Metadata.Add(Constants.TypeMetadata.StringPattern, classEntity.TypeDefinition.StringPattern);
                }
            }
        }

        private string FullyQualifyNamespace(string? @namespace)
        {
            return string.IsNullOrEmpty(@namespace) ? Constants.RelativeNamespaceToken : $"{Constants.RelativeNamespaceToken}.{@namespace}";
        }
    }
}
