using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration;

public class TypeEntityRegistrar(EntitiesContext entitiesContext, ILogger logger)
{
    private readonly EntitiesContext entitiesContext = entitiesContext;
    private readonly ILogger logger = logger;

    public void Reset() => entitiesContext.Types.Clear();

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
            logger.LogError("Type definition in namespace '{FullName}' must have an ID or extends another type. {TypeDefinition}", namespaceEntity.FullName, JsonSerializer.Serialize(typeDefinition));
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

    public bool HasTypeEntity(string typeId, NamespaceEntity namespaceEntity) => entitiesContext.Types.HasTypeEntity(typeId, namespaceEntity);

    public TypeEntity GetTypeEntity(string typeId, NamespaceEntity namespaceEntity) => entitiesContext.Types.GetTypeEntity(typeId, namespaceEntity);

    public IEnumerable<TypeEntity> GetAllEntities() => entitiesContext.Types.GetAllTypes();
}
