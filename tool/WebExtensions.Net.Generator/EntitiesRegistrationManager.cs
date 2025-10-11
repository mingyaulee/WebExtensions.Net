using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.EntitiesRegistration;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator;

public class EntitiesRegistrationManager(
    ILogger logger,
    RegistrarFactory registrarFactory,
    NamespaceRegistrationFilter namespaceRegistrationFilter,
    AnonymousTypeProcessor anonymousTypeProcessor,
    TypeUsageProcessor typeUsageProcessor,
    RegisteredClassEntityProcessor registeredClassEntityProcessor)
{
    private readonly ILogger logger = logger;
    private readonly RegistrarFactory registrarFactory = registrarFactory;
    private readonly NamespaceRegistrationFilter namespaceRegistrationFilter = namespaceRegistrationFilter;
    private readonly AnonymousTypeProcessor anonymousTypeProcessor = anonymousTypeProcessor;
    private readonly TypeUsageProcessor typeUsageProcessor = typeUsageProcessor;
    private readonly RegisteredClassEntityProcessor registeredClassEntityProcessor = registeredClassEntityProcessor;

    public IEnumerable<ClassEntity> RegisterEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
    {
        Reset();
        var apiNamespaceEntities = RegisterNamespaceTypesAsTypeEntities(namespaceDefinitions);
        var apiClassEntities = RegisterNamespaceEntitiesAsClassEntities(apiNamespaceEntities);
        RegisterApiRoot(apiClassEntities);
        RegisterAnonymousTypesAsTypeEntities(apiClassEntities);
        MarkApiClassEntitiesTypeUsage(apiClassEntities);
        RegisterTypeEntitiesAsClassEntities();

        return registrarFactory.ClassEntityRegistrar.GetAllClassEntities();
    }

    private void Reset()
    {
        registrarFactory.NamespaceEntityRegistrar.Reset();
        registrarFactory.TypeEntityRegistrar.Reset();
        registrarFactory.ClassEntityRegistrar.Reset();
    }

    private HashSet<NamespaceEntity> RegisterNamespaceTypesAsTypeEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
    {
        var apiNamespaceEntities = new HashSet<NamespaceEntity>();

        foreach (var namespaceDefinition in namespaceDefinitions)
        {
            var clonedNamespaceDefinition = SerializationHelper.DeserializeTo<NamespaceDefinition>(namespaceDefinition);
            var namespaceEntity = registrarFactory.NamespaceEntityRegistrar.RegisterNamespace(clonedNamespaceDefinition);
            if (namespaceEntity is null || !namespaceRegistrationFilter.ShouldProcess(namespaceEntity))
            {
                continue;
            }

            registrarFactory.TypeEntityRegistrar.RegisterNamespaceTypes(clonedNamespaceDefinition.Types, namespaceEntity);

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
        => !(namespaceDefinition.Events is null && namespaceDefinition.Functions is null && namespaceDefinition.Properties is null);

    private ClassEntity[] RegisterNamespaceEntitiesAsClassEntities(IEnumerable<NamespaceEntity> namespaceEntities)
    {
        var nestedNamespaceEntities = namespaceEntities
            .Where(namespaceEntity => namespaceEntity.Parent is not null)
            .ToArray();
        return [.. namespaceEntities
            .Except(nestedNamespaceEntities)
            .SelectMany(namespaceEntity =>
            {
                var classEntity = registrarFactory.ClassEntityRegistrar.RegisterNamespaceApi(namespaceEntity.NamespaceDefinitions, namespaceEntity);
                var nestedClassEntities = RegisterNestedNamespaceEntitiesAsPropertyToClassEntity(classEntity, nestedNamespaceEntities);
                return new[] { classEntity }.Concat(nestedClassEntities);
            })];
    }

    private ClassEntity[] RegisterNestedNamespaceEntitiesAsPropertyToClassEntity(ClassEntity classEntity, IEnumerable<NamespaceEntity> namespaceEntities)
    {
        var nestedNamespaceEntities = namespaceEntities
            .Where(namespaceEntity => namespaceEntity.Parent == classEntity.NamespaceEntity)
            .ToArray();
        return [.. nestedNamespaceEntities
            .Select(nestedNamespaceEntity =>
            {
                var nestedClassEntity = registrarFactory.ClassEntityRegistrar.RegisterNamespaceApi(nestedNamespaceEntity.NamespaceDefinitions, nestedNamespaceEntity);
                registrarFactory.ClassEntityRegistrar.RegisterNestedNamespaceApi(classEntity, nestedClassEntity);
                return nestedClassEntity;
            })];
    }

    private void RegisterApiRoot(IEnumerable<ClassEntity> apiClassEntities)
        => registrarFactory.ClassEntityRegistrar.RegisterRootApi(apiClassEntities);

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
        var typeEntities = registrarFactory.TypeEntityRegistrar.GetAllEntities();
        foreach (var typeEntity in typeEntities)
        {
            if (!typeEntity.IsReferenced)
            {
                logger.LogWarning("Skipped Type '{NamespaceQualifiedId}' because it is not referenced.", typeEntity.NamespaceQualifiedId);
                continue;
            }

            if (registrarFactory.ClassEntityRegistrar.TryRegisterTypeEntity(typeEntity, out var classEntity))
            {
                registeredClassEntityProcessor.Process(classEntity);
            }
        }
    }
}
