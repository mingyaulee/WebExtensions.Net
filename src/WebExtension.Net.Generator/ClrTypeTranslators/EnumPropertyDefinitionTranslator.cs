using System.Collections.Generic;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.ClrTypes;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.ClrTypeTranslators
{
    public static class EnumPropertyDefinitionTranslator
    {
        public static ClrEnumValueInfo TranslatePropertyDefinition(KeyValuePair<string, PropertyDefinition> propertyDefinitionPair)
        {
            return new ClrEnumValueInfo()
            {
                Name = propertyDefinitionPair.Key,
                CSharpName = SanitizeValueName(propertyDefinitionPair.Key.ToCapitalCase()),
                Description = propertyDefinitionPair.Value.Description
            };
        }

        private static string SanitizeValueName(string valueName)
        {
            return valueName.Replace("-", "_");
        }
    }
}
