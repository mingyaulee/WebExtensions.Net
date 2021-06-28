using System;
using System.Collections.Generic;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class EnumClassEntityRegistrar : BaseClassEntityRegistrar
    {
        private readonly RegistrationOptions registrationOptions;

        public EnumClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : base(entitiesContext)
        {
            this.registrationOptions = registrationOptions;
        }

        protected override ClassType GetClassType() => ClassType.EnumClass;
        protected override bool ShouldSortProperties() => false;

        protected override void AddClassProperties(TypeEntity typeEntity, List<KeyValuePair<string, PropertyDefinition>> classProperties)
        {
            if (typeEntity.Definition.EnumValues is not null)
            {
                foreach (var enumValueDefinition in typeEntity.Definition.EnumValues)
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
    }
}
