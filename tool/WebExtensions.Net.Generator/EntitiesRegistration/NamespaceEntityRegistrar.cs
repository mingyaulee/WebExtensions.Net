using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration;

public class NamespaceEntityRegistrar(EntitiesContext entitiesContext, ILogger logger)
{
    private readonly EntitiesContext entitiesContext = entitiesContext;
    private readonly ILogger logger = logger;

    public void Reset() => entitiesContext.Namespaces.Clear();

    public IEnumerable<NamespaceEntity> GetAllNamespaceEntities() => entitiesContext.Namespaces.GetAllNamespaceEntities();

    public NamespaceEntity? RegisterNamespace(NamespaceDefinition namespaceDefinition)
    {
        if (namespaceDefinition.Namespace is null)
        {
            logger.LogInformation("Namespace is null for namespace definition in source '{HttpUrl}'", namespaceDefinition.Source?.HttpUrl);
            return null;
        }

        NamespaceEntity? parentEntity = null;
        var @namespace = namespaceDefinition.Namespace;
        if (@namespace.Contains('.'))
        {
            var parentNamespaces = @namespace.Split('.');
            @namespace = parentNamespaces[^1];
            foreach (var parentNamespace in parentNamespaces.SkipLast(1))
            {
                parentEntity = entitiesContext.Namespaces.RegisterNamespace(parentEntity, parentNamespace);
            }
        }

        var entity = entitiesContext.Namespaces.RegisterNamespace(parentEntity, @namespace);
        entity.NamespaceDefinitions.Add(namespaceDefinition);
        entity.OriginalNamespaceDefinitions.Add(SerializationHelper.DeserializeTo<NamespaceDefinition>(namespaceDefinition));
        return entity;
    }
}
