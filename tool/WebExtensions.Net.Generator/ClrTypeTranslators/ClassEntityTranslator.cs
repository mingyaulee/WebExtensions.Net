using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.ClrTypes;
using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.ClrTypeTranslators;

public class ClassEntityTranslator(ClrTypeStore clrTypeStore, FunctionDefinitionTranslator functionDefinitionTranslator, PropertyDefinitionTranslator propertyDefinitionTranslator, ClassTranslationOptions classTranslationOptions)
{
    private readonly ClrTypeStore clrTypeStore = clrTypeStore;
    private readonly FunctionDefinitionTranslator functionDefinitionTranslator = functionDefinitionTranslator;
    private readonly PropertyDefinitionTranslator propertyDefinitionTranslator = propertyDefinitionTranslator;
    private readonly ClassTranslationOptions classTranslationOptions = classTranslationOptions;

    public IEnumerable<ClrTypeInfo> ShallowTranslate(ClassEntity classEntity)
    {
        var classCSharpName = classEntity.FormattedName.ToCSharpName(toCapitalCase: true);
        if (classTranslationOptions.Aliases.TryGetValue($"{classEntity.NamespaceEntity.FullFormattedName}.{classEntity.FormattedName}", out var classAlias))
        {
            classCSharpName = classAlias;
        }

        foreach (var replace in classTranslationOptions.ReplaceNames)
        {
            classCSharpName = classCSharpName.Replace(replace.Key, replace.Value);
        }

        var namespaceName = classEntity.NamespaceEntity.FullFormattedName;
        if (namespaceName is not null && classTranslationOptions.NamespaceAliases.TryGetValue(namespaceName, out var namespaceAlias))
        {
            namespaceName = namespaceAlias;
        }
        var @namespace = FullyQualifyNamespace(namespaceName);

        var clrTypeInfo = new ClrTypeInfo()
        {
            Id = $"{FullyQualifyNamespace(classEntity.NamespaceEntity.FullFormattedName)}.{classEntity.FormattedName}",
            Namespace = @namespace,
            Name = classEntity.Name,
            FullName = $"{@namespace}.{classEntity.FormattedName}",
            CSharpName = classCSharpName,
            IsNullable = classEntity.Type != ClassType.EnumClass,
            IsEnum = classEntity.Type == ClassType.EnumClass,
            EnumValues = classEntity.Type == ClassType.EnumClass ? classEntity.Properties.Select(EnumPropertyDefinitionTranslator.TranslatePropertyDefinition).ToArray() : null,
            IsInterface = false,
            IsNullType = false,
            IsGenericType = false,
            GenericTypeArguments = [],
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
            interfaceClrTypeInfo.CSharpName = $"I{classCSharpName}";
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

        clrTypeInfo.Methods = [.. classEntity.Functions.SelectMany(functionDefinition => functionDefinitionTranslator.TranslateFunctionDefinition(functionDefinition, classEntity.NamespaceEntity, clrTypeInfo))];
        clrTypeInfo.Properties = [.. classEntity.Properties.Select(propertyDefinitionPair => propertyDefinitionTranslator.TranslatePropertyDefinition(propertyDefinitionPair.Key, propertyDefinitionPair.Value, classEntity.NamespaceEntity, clrTypeInfo))];

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

    private static string FullyQualifyNamespace(string? @namespace)
        => string.IsNullOrEmpty(@namespace) ? Constants.RelativeNamespaceToken : $"{Constants.RelativeNamespaceToken}.{@namespace}";
}
