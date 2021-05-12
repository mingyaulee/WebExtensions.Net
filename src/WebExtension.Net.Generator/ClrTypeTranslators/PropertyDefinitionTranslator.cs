using System;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.ClrTypes;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.ClrTypeTranslators
{
    public class PropertyDefinitionTranslator
    {
        private readonly ClrTypeStore clrTypeStore;

        public PropertyDefinitionTranslator(ClrTypeStore clrTypeStore)
        {
            this.clrTypeStore = clrTypeStore;
        }

        public ClrPropertyInfo TranslatePropertyDefinition(string propertyName, PropertyDefinition propertyDefinition, NamespaceEntity namespaceEntity, ClrTypeInfo clrTypeInfo)
        {
            var propertyType = clrTypeStore.GetClrType(propertyDefinition, namespaceEntity);
            if (propertyDefinition.IsOptional && !propertyType.IsNullable)
            {
                propertyType = propertyType.MakeNullable();
            }
            clrTypeInfo.AddRequiredNamespaces(propertyType.ReferenceNamespaces);

            if (propertyName.Equals(clrTypeInfo.CSharpName, StringComparison.OrdinalIgnoreCase))
            {
                // Property name cannot be the same as declaring type, prefer to change the type name instead of the property name
                clrTypeInfo.CSharpName = $"{clrTypeInfo.CSharpName}Type";
            }

            return new ClrPropertyInfo()
            {
                Name = propertyName,
                PrivateName = propertyName.ToCamelCase(),
                PublicName = propertyName.ToCapitalCase(),
                Description = propertyDefinition.Description,
                DeclaringType = clrTypeInfo,
                PropertyType = propertyType,
                IsConstant = propertyDefinition.IsConstant,
                ConstantValue = propertyDefinition.ConstantValue,
                IsObsolete = propertyDefinition.IsDeprecated,
                ObsoleteMessage = propertyDefinition.Deprecated
            };
        }
    }
}
