using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.EntityRegistrars;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator
{
    public class EntitiesRegistrationManager
    {
        private readonly ILogger logger;
        private readonly RegistrationOptions registrationOptions;
        private readonly NamespaceEntityRegistrar namespaceEntityRegistrar;
        private readonly TypeEntityRegistrar typeEntityRegistrar;
        private readonly ClassEntityRegistrar classEntityRegistrar;

        public EntitiesRegistrationManager(ILogger logger, RegistrationOptions registrationOptions, NamespaceEntityRegistrar namespaceEntityRegistrar, TypeEntityRegistrar typeEntityRegistrar, ClassEntityRegistrar classEntityRegistrar)
        {
            this.logger = logger;
            this.registrationOptions = registrationOptions;
            this.namespaceEntityRegistrar = namespaceEntityRegistrar;
            this.typeEntityRegistrar = typeEntityRegistrar;
            this.classEntityRegistrar = classEntityRegistrar;
        }

        public void RegisterEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            RegisterNamespaceEntities(namespaceDefinitions);
            RegisterTypeEntitiesAsClassEntities();
        }

        private void RegisterNamespaceEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            var apiClassList = new List<ClassEntity>();
            foreach (var namespaceDefinition in namespaceDefinitions)
            {
                var namespaceEntity = namespaceEntityRegistrar.RegisterNamespace(namespaceDefinition);
                if (namespaceEntity is null)
                {
                    continue;
                }

                if (registrationOptions.ExcludeNamespaces.Contains(namespaceEntity.Name))
                {
                    logger.LogWarning($"Skipped namespace '{namespaceEntity.Name}'.");
                    continue;
                }

                if (!registrationOptions.IncludeNamespaces.Contains(namespaceEntity.Name))
                {
                    logger.LogError($"Namespace '{namespaceEntity.Name}' is not recognized.");
                    continue;
                }

                typeEntityRegistrar.RegisterNamespaceTypes(namespaceDefinition.Types, namespaceEntity);
                var classEntity = classEntityRegistrar.RegisterNamespaceApi(namespaceDefinition, namespaceEntity);
                if (classEntity is not null)
                {
                    apiClassList.Add(classEntity);
                }
            }
            classEntityRegistrar.RegisterRootApi(apiClassList);
        }

        private void RegisterTypeEntitiesAsClassEntities()
        {
            var typeEntities = typeEntityRegistrar.GetAllEntities();
            foreach (var typeEntity in typeEntities)
            {
                classEntityRegistrar.RegisterTypeEntity(typeEntity);
            }
        }
    }
}
