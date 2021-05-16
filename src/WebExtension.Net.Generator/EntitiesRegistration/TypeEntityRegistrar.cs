using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration
{
    public class TypeEntityRegistrar
    {
        private readonly EntitiesContext entitiesContext;
        private readonly ILogger logger;

        public TypeEntityRegistrar(EntitiesContext entitiesContext, ILogger logger)
        {
            this.entitiesContext = entitiesContext;
            this.logger = logger;
        }

        public void RegisterNamespaceType(TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
        {
            if (!string.IsNullOrEmpty(typeDefinition.Id))
            {
                entitiesContext.Types.RegisterType(typeDefinition.Id, typeDefinition, namespaceEntity);
            }
            else if (!string.IsNullOrEmpty(typeDefinition.Extend))
            {
                entitiesContext.Types.RegisterTypeExtension(typeDefinition.Extend, typeDefinition, namespaceEntity);
            }
            else
            {
                logger.LogError($"Type definition in namespace '{namespaceEntity.Name}' must have an ID or extends another type. {JsonSerializer.Serialize(typeDefinition)}");
            }
        }

        public void RegisterNamespaceTypes(IEnumerable<TypeDefinition>? typeDefinitions, NamespaceEntity namespaceEntity)
        {
            if (typeDefinitions is null)
            {
                return;
            }

            foreach (var typeDefinition in typeDefinitions)
            {
                RegisterNamespaceType(typeDefinition, namespaceEntity);
            }
        }

        public bool HasTypeEntity(string typeId, NamespaceEntity namespaceEntity)
        {
            return entitiesContext.Types.HasTypeEntity(typeId, namespaceEntity);
        }

        public TypeEntity GetTypeEntity(string typeId, NamespaceEntity namespaceEntity)
        {
            return entitiesContext.Types.GetTypeEntity(typeId, namespaceEntity);
        }

        public IEnumerable<TypeEntity> GetAllEntities()
        {
            return entitiesContext.Types.GetAllTypes();
        }
    }
}
