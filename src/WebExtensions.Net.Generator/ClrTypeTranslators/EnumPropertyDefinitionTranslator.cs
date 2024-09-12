using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.ClrTypes;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.ClrTypeTranslators
{
    public static partial class EnumPropertyDefinitionTranslator
    {
        public static ClrEnumValueInfo TranslatePropertyDefinition(KeyValuePair<string, PropertyDefinition> propertyDefinitionPair)
        {
            return new ClrEnumValueInfo()
            {
                Name = propertyDefinitionPair.Key,
                CSharpName = TranslateValueName(propertyDefinitionPair.Key),
                Description = propertyDefinitionPair.Value.Description
            };
        }

        private static string TranslateValueName(string valueName)
        {
            var tokenizedNameSegments = valueName.Split(new[] { '-', '_' });
            return string.Join("", tokenizedNameSegments.Select(tokenizedNameSegment =>
            {
                if (tokenizedNameSegment.Length == 0)
                {
                    return tokenizedNameSegment;
                }

                if (char.IsAsciiLetter(tokenizedNameSegment[0]))
                {
                    return tokenizedNameSegment.ToCapitalCase();
                }

                return $"_{tokenizedNameSegment}";
            }));
        }
    }
}
