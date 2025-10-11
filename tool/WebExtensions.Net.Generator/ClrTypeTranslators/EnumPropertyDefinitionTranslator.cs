using System.Collections.Generic;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.ClrTypes;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.ClrTypeTranslators;

public static partial class EnumPropertyDefinitionTranslator
{
    public static ClrEnumValueInfo TranslatePropertyDefinition(KeyValuePair<string, PropertyDefinition> propertyDefinitionPair) => new()
    {
        Name = propertyDefinitionPair.Key,
        CSharpName = propertyDefinitionPair.Key.ToCSharpName(toCapitalCase: true, avoidReservedKeywords: false),
        Description = propertyDefinitionPair.Value.Description
    };
}
