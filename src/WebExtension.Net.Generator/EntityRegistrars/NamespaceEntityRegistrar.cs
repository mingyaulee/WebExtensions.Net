using Microsoft.Extensions.Logging;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntityRegistrars
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
