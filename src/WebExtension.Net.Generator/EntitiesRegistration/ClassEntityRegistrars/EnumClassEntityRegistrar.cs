using System;
using System.Collections.Generic;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class EnumClassEntityRegistrar : BaseClassEntityRegistrar
    {
        public EnumClassEntityRegistrar(EntitiesContext entitiesContext) : base(entitiesContext)
        {
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
        }
    }
}
