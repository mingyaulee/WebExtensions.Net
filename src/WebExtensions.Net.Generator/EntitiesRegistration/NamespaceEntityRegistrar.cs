using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class NamespaceEntityRegistrar
    {
        private readonly EntitiesContext entitiesContext;
        private readonly ILogger logger;

        public NamespaceEntityRegistrar(EntitiesContext entitiesContext, ILogger logger)
        {
            this.entitiesContext = entitiesContext;
            this.logger = logger;
        }

        public IEnumerable<NamespaceEntity> GetAllNamespaceEntities()
        {
            return entitiesContext.Namespaces.GetAllNamespaceEntities();
        }

        public NamespaceEntity? RegisterNamespace(NamespaceDefinition namespaceDefinition)
        {
            if (namespaceDefinition.Namespace is null)
            {
                logger.LogInformation($"Namespace is null for namespace definition in source '{namespaceDefinition.Source?.HttpUrl}'");
                return null;
            }
            return entitiesContext.Namespaces.RegisterNamespace(namespaceDefinition.Namespace, namespaceDefinition);
        }
    }
}
