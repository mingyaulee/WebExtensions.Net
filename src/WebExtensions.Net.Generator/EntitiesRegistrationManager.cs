using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.EntitiesRegistration;
using WebExtensions.Net.Generator.Helpers;
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
        private readonly RegisteredClassEntityProcessor registeredClassEntityProcessor;

        public EntitiesRegistrationManager(
            ILogger logger,
            NamespaceRegistrationFilter namespaceRegistrationFilter,
            NamespaceEntityRegistrar namespaceEntityRegistrar,
            TypeEntityRegistrar typeEntityRegistrar,
            AnonymousTypeProcessor anonymousTypeProcessor,
            TypeUsageProcessor typeUsageProcessor,
            ClassEntityRegistrar classEntityRegistrar,
            RegisteredClassEntityProcessor registeredClassEntityProcessor)
        {
            this.logger = logger;
            this.namespaceRegistrationFilter = namespaceRegistrationFilter;
            this.namespaceEntityRegistrar = namespaceEntityRegistrar;
            this.typeEntityRegistrar = typeEntityRegistrar;
            this.anonymousTypeProcessor = anonymousTypeProcessor;
            this.typeUsageProcessor = typeUsageProcessor;
            this.classEntityRegistrar = classEntityRegistrar;
            this.registeredClassEntityProcessor = registeredClassEntityProcessor;
        }

        public IEnumerable<ClassEntity> RegisterEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            Reset();
            var apiNamespaceEntities = RegisterNamespaceTypesAsTypeEntities(namespaceDefinitions);
            var apiClassEntities = RegisterNamespaceEntitiesAsClassEntities(apiNamespaceEntities);
            RegisterApiRoot(apiClassEntities);
            RegisterAnonymousTypesAsTypeEntities(apiClassEntities);
            MarkApiClassEntitiesTypeUsage(apiClassEntities);
            RegisterTypeEntitiesAsClassEntities();

            return classEntityRegistrar.GetAllClassEntities();
        }

        private void Reset()
        {
            namespaceEntityRegistrar.Reset();
            typeEntityRegistrar.Reset();
            classEntityRegistrar.Reset();
        }

        private IEnumerable<NamespaceEntity> RegisterNamespaceTypesAsTypeEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            var apiNamespaceEntities = new HashSet<NamespaceEntity>();

            foreach (var namespaceDefinition in namespaceDefinitions)
            {
                var clonedNamespaceDefinition = SerializationHelper.DeserializeTo<NamespaceDefinition>(namespaceDefinition);
                var namespaceEntity = namespaceEntityRegistrar.RegisterNamespace(clonedNamespaceDefinition);
                if (namespaceEntity is null || !namespaceRegistrationFilter.ShouldProcess(namespaceEntity))
                {
                    continue;
                }

                typeEntityRegistrar.RegisterNamespaceTypes(clonedNamespaceDefinition.Types, namespaceEntity);

                if (ShouldRegisterNamespaceApi(clonedNamespaceDefinition))
                {
                    apiNamespaceEntities.Add(namespaceEntity);
                    while (namespaceEntity.Parent is not null)
                    {
                        namespaceEntity = namespaceEntity.Parent;
                        apiNamespaceEntities.Add(namespaceEntity);
                    }
                }
            }

            return apiNamespaceEntities;
        }

        private static bool ShouldRegisterNamespaceApi(NamespaceDefinition namespaceDefinition)
        {
            return !(namespaceDefinition.Events is null && namespaceDefinition.Functions is null && namespaceDefinition.Properties is null);
        }

        private IEnumerable<ClassEntity> RegisterNamespaceEntitiesAsClassEntities(IEnumerable<NamespaceEntity> namespaceEntities)
        {
            var nestedNamespaceEntities = namespaceEntities
                .Where(namespaceEntity => namespaceEntity.Parent is not null)
                .ToArray();
            return namespaceEntities
                .Except(nestedNamespaceEntities)
                .SelectMany(namespaceEntity =>
                {
                    var classEntity = classEntityRegistrar.RegisterNamespaceApi(namespaceEntity.NamespaceDefinitions, namespaceEntity);
                    var nestedClassEntities = RegisterNestedNamespaceEntitiesAsPropertyToClassEntity(classEntity, nestedNamespaceEntities);
                    return new[] { classEntity }.Concat(nestedClassEntities);
                })
                .ToArray();
        }

        private IEnumerable<ClassEntity> RegisterNestedNamespaceEntitiesAsPropertyToClassEntity(ClassEntity classEntity, IEnumerable<NamespaceEntity> namespaceEntities)
        {
            var nestedNamespaceEntities = namespaceEntities
                .Where(namespaceEntity => namespaceEntity.Parent == classEntity.NamespaceEntity)
                .ToArray();
            return nestedNamespaceEntities
                .Select(nestedNamespaceEntity =>
                {
                    var nestedClassEntity = classEntityRegistrar.RegisterNamespaceApi(nestedNamespaceEntity.NamespaceDefinitions, nestedNamespaceEntity);
                    classEntityRegistrar.RegisterNestedNamespaceApi(classEntity, nestedClassEntity);
                    return nestedClassEntity;
                })
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
                    logger.LogWarning("Skipped Type '{NamespaceQualifiedId}' because it is not referenced.", typeEntity.NamespaceQualifiedId);
                    continue;
                }

                if (classEntityRegistrar.TryRegisterTypeEntity(typeEntity, out var classEntity))
                {
                    registeredClassEntityProcessor.Process(classEntity);
                }
            }
        }
    }
}
