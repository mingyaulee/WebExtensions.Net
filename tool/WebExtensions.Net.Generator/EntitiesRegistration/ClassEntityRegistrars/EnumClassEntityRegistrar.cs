using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars;

public class EnumClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : BaseClassEntityRegistrar(entitiesContext)
{
    private readonly RegistrationOptions registrationOptions = registrationOptions;

    protected override ClassType GetClassType() => ClassType.EnumClass;
    protected override bool ShouldSortProperties() => false;

    protected override void AddClassProperties(TypeEntity typeEntity, List<KeyValuePair<string, PropertyDefinition>> classProperties)
    {
        if (typeEntity.Definition.EnumValues is not null)
        {
            AddEnumValueProperties(typeEntity.Definition.EnumValues, classProperties);
        }

        if (typeEntity.Definition.TypeChoices is not null)
        {
            AddEnumValueProperties(typeEntity.Definition.TypeChoices.SelectMany(typeChoice => typeChoice.EnumValues ?? []), classProperties);
        }

        if (registrationOptions.EnumClassExtensions is not null &&
            registrationOptions.EnumClassExtensions.TryGetValue(typeEntity.NamespaceQualifiedId, out var enumClassExtensions) &&
            enumClassExtensions is not null)
        {
            foreach (var enumClassExtension in enumClassExtensions)
            {
                var propertyDefinitionPair = KeyValuePair.Create(enumClassExtension.Name, new PropertyDefinition()
                {
                    Description = enumClassExtension.Description
                });
                classProperties.Add(propertyDefinitionPair);
            }
        }
    }

    private static void AddEnumValueProperties(IEnumerable<EnumValueDefinition> enumValueDefinitions, List<KeyValuePair<string, PropertyDefinition>> classProperties)
    {
        foreach (var enumValueDefinition in enumValueDefinitions)
        {
            if (enumValueDefinition.Name is null)
            {
                throw new InvalidOperationException("Enum value definition should have a name property.");
            }

            var propertyDefinitionPair = KeyValuePair.Create(enumValueDefinition.Name, new PropertyDefinition()
            {
                Description = enumValueDefinition.Description
            });
            classProperties.Add(propertyDefinitionPair);
        }
    }
}
