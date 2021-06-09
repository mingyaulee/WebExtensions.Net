using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.EntitiesRegistration;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator
{
    public class EntitiesRegistrationManager
    {
        private readonly ILogger logger;
        private readonly NamespaceRegistrationFilter namespaceRegistrationFilter;
        private readonly NamespaceEntityRegistrar namespaceEntityRegistrar;
        private readonly TypeEntityRegistrar typeEntityRegistrar;
        private readonly AnonymousTypeProcessor anonymousTypeProcessor;
        private readonly TypeUsageProcessor typeUsageProcessor;
        private readonly ClassEntityRegistrar classEntityRegistrar;

        public EntitiesRegistrationManager(
            ILogger logger,
            NamespaceRegistrationFilter namespaceRegistrationFilter,
            NamespaceEntityRegistrar namespaceEntityRegistrar,
            TypeEntityRegistrar typeEntityRegistrar,
            AnonymousTypeProcessor anonymousTypeProcessor,
            TypeUsageProcessor typeUsageProcessor,
            ClassEntityRegistrar classEntityRegistrar)
        {
            this.logger = logger;
            this.namespaceRegistrationFilter = namespaceRegistrationFilter;
            this.namespaceEntityRegistrar = namespaceEntityRegistrar;
            this.typeEntityRegistrar = typeEntityRegistrar;
            this.anonymousTypeProcessor = anonymousTypeProcessor;
            this.typeUsageProcessor = typeUsageProcessor;
            this.classEntityRegistrar = classEntityRegistrar;
        }

        public IEnumerable<ClassEntity> RegisterEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            var apiNamespaceDefinitions = RegisterNamespaceTypesAsTypeEntities(namespaceDefinitions);
            var apiClassEntities = RegisterNamespaceDefinitionsAsClassEntities(apiNamespaceDefinitions);
            RegisterApiRoot(apiClassEntities);
            RegisterAnonymousTypesAsTypeEntities(apiClassEntities);
            MarkApiClassEntitiesTypeUsage(apiClassEntities);
            RegisterTypeEntitiesAsClassEntities();

            return classEntityRegistrar.GetAllClassEntities();
        }

        private IEnumerable<KeyValuePair<NamespaceDefinition, NamespaceEntity>> RegisterNamespaceTypesAsTypeEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            var apiNamespaceDefinitions = new List<KeyValuePair<NamespaceDefinition, NamespaceEntity>>();

            foreach (var namespaceDefinition in namespaceDefinitions)
            {
                var namespaceEntity = namespaceEntityRegistrar.RegisterNamespace(namespaceDefinition);
                if (namespaceEntity is null || !namespaceRegistrationFilter.ShouldProcess(namespaceEntity))
                {
                    continue;
                }

                typeEntityRegistrar.RegisterNamespaceTypes(namespaceDefinition.Types, namespaceEntity);

                if (ShouldRegisterNamespaceApi(namespaceDefinition))
                {
                    apiNamespaceDefinitions.Add(KeyValuePair.Create(namespaceDefinition, namespaceEntity));
                }
            }

            return apiNamespaceDefinitions;
        }

        private static bool ShouldRegisterNamespaceApi(NamespaceDefinition namespaceDefinition)
        {
            return !(namespaceDefinition.Events is null && namespaceDefinition.Functions is null && namespaceDefinition.Properties is null);
        }

        private IEnumerable<ClassEntity> RegisterNamespaceDefinitionsAsClassEntities(IEnumerable<KeyValuePair<NamespaceDefinition, NamespaceEntity>> namespaceDefinitions)
        {
            return namespaceDefinitions.Select(namespaceDefinitionPair => classEntityRegistrar.RegisterNamespaceApi(namespaceDefinitionPair.Key, namespaceDefinitionPair.Value))
                .ToArray();
        }

        private void RegisterApiRoot(IEnumerable<ClassEntity> apiClassEntities)
        {
            classEntityRegistrar.RegisterRootApi(apiClassEntities);
        }

        private void RegisterAnonymousTypesAsTypeEntities(IEnumerable<ClassEntity> apiClassEntities)
        {
            anonymousTypeProcessor.Reset();
            foreach (var classEntity in apiClassEntities)
            {
                anonymousTypeProcessor.ProcessTypeDefinition(classEntity.FormattedName, classEntity.TypeDefinition, classEntity.NamespaceEntity);
            }
            anonymousTypeProcessor.Complete();
        }

        private void MarkApiClassEntitiesTypeUsage(IEnumerable<ClassEntity> apiClassEntities)
        {
            foreach (var classEntity in apiClassEntities)
            {
                typeUsageProcessor.MarkTypeUsage(classEntity.Functions, classEntity.NamespaceEntity);
                typeUsageProcessor.MarkTypeUsage(classEntity.Properties.Select(property => property.Value), classEntity.NamespaceEntity);
            }
        }

        private void RegisterTypeEntitiesAsClassEntities()
        {
            var typeEntities = typeEntityRegistrar.GetAllEntities();
            foreach (var typeEntity in typeEntities)
            {
                if (!typeEntity.IsReferenced)
                {
                    logger.LogWarning($"Skipped Type '{typeEntity.NamespaceQualifiedId}' because it is not referenced.");
                    continue;
                }
                classEntityRegistrar.RegisterTypeEntity(typeEntity);
            }
        }
    }
}
