using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.ClrTypes;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.ClrTypeTranslators
{
    public class ClassEntityTranslator
    {
        private readonly ClrTypeStore clrTypeStore;
        private readonly FunctionDefinitionTranslator functionDefinitionTranslator;
        private readonly PropertyDefinitionTranslator propertyDefinitionTranslator;

        public ClassEntityTranslator(ClrTypeStore clrTypeStore, FunctionDefinitionTranslator functionDefinitionTranslator, PropertyDefinitionTranslator propertyDefinitionTranslator)
        {
            this.clrTypeStore = clrTypeStore;
            this.functionDefinitionTranslator = functionDefinitionTranslator;
            this.propertyDefinitionTranslator = propertyDefinitionTranslator;
        }

        public IEnumerable<ClrTypeInfo> ShallowTranslate(ClassEntity classEntity)
        {
            var @namespace = string.IsNullOrEmpty(classEntity.NamespaceEntity.FormattedName) ? Constants.RelativeNamespaceToken : $"{Constants.RelativeNamespaceToken}.{classEntity.NamespaceEntity.FormattedName}";
            var clrTypeInfo = new ClrTypeInfo()
            {
                Id = $"{@namespace}.{classEntity.FormattedName}",
                Namespace = @namespace,
                Name = classEntity.Name,
                FullName = $"{@namespace}.{classEntity.FormattedName}",
                CSharpName = classEntity.FormattedName,
                IsNullable = classEntity.Type != ClassType.EnumClass,
                IsEnum = classEntity.Type == ClassType.EnumClass,
                EnumValues = classEntity.Type == ClassType.EnumClass ? classEntity.Properties.Select(EnumPropertyDefinitionTranslator.TranslatePropertyDefinition).ToArray() : null,
                IsInterface = false,
                IsNullType = false,
                IsGenericType = false,
                GenericTypeArguments = Enumerable.Empty<ClrTypeInfo>(),
                IsObsolete = classEntity.TypeDefinition?.IsDeprecated ?? false,
                ObsoleteMessage = classEntity.TypeDefinition?.Deprecated,
                IsGenerated = true,
                GeneratedNamespace = classEntity.NamespaceEntity.FormattedName,
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
                interfaceClrTypeInfo.CSharpName = interfaceTypeName;
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
            clrTypeInfo.Methods = classEntity.Functions.Select(functionDefinition => functionDefinitionTranslator.TranslateFunctionDefinition(functionDefinition, classEntity.NamespaceEntity, clrTypeInfo)).ToArray();
            clrTypeInfo.Properties = classEntity.Properties.Select(propertyDefinitionPair => propertyDefinitionTranslator.TranslatePropertyDefinition(propertyDefinitionPair.Key, propertyDefinitionPair.Value, classEntity.NamespaceEntity, clrTypeInfo)).ToArray();

            if (classEntity.Type == ClassType.ArrayClass)
            {
                var arrayItemClrType = clrTypeStore.GetClrType(classEntity.TypeDefinition?.ArrayItems, classEntity.NamespaceEntity);
                clrTypeInfo.BaseTypeName = clrTypeInfo.BaseTypeName?.Replace(Constants.ArrayTypeToken, arrayItemClrType.CSharpName);
                clrTypeInfo.RequiredNamespaces.Add("System.Collections.Generic");
                clrTypeInfo.AddRequiredNamespaces(arrayItemClrType.ReferenceNamespaces);
            }

            if (classEntity.Type == ClassType.MultitypeClass)
            {
                clrTypeInfo.TypeChoices = classEntity.TypeDefinition?.TypeChoices?.Select(typeChoice =>
                {
                    var choiceClrTypeInfo = clrTypeStore.GetClrType(typeChoice, classEntity.NamespaceEntity);
                    clrTypeInfo.AddRequiredNamespaces(choiceClrTypeInfo.ReferenceNamespaces);
                    return choiceClrTypeInfo;
                });
            }

            if (classEntity.Type == ClassType.StringFormatClass)
            {
                if (classEntity.TypeDefinition?.StringFormat is null)
                {
                    throw new InvalidOperationException("String format class should have string format value.");
                }
                clrTypeInfo.Metadata.Add(Constants.TypeMetadata.StringFormat, classEntity.TypeDefinition.StringFormat);
            }
        }
    }
}
