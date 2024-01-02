using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class ClassEntityRegistrar
    {
        private readonly ClassEntityRegistrarFactory classEntityRegistrarFactory;
        private readonly ApiRootClassEntityRegistrar rootApiClassEntityRegistrar;
        private readonly ApiClassEntityRegistrar apiClassEntityRegistrar;
        private readonly EntitiesContext entitiesContext;
        private readonly NamespaceApiToTypeDefinitionConverter namespaceApiToTypeDefinitionConverter;
        private readonly RegistrationOptions registrationOptions;

        public ClassEntityRegistrar(ClassEntityRegistrarFactory classEntityRegistrarFactory, ApiRootClassEntityRegistrar rootApiClassEntityRegistrar, ApiClassEntityRegistrar apiClassEntityRegistrar, EntitiesContext entitiesContext, NamespaceApiToTypeDefinitionConverter namespaceApiToTypeDefinitionConverter, RegistrationOptions registrationOptions)
        {
            this.classEntityRegistrarFactory = classEntityRegistrarFactory;
            this.rootApiClassEntityRegistrar = rootApiClassEntityRegistrar;
            this.apiClassEntityRegistrar = apiClassEntityRegistrar;
            this.entitiesContext = entitiesContext;
            this.namespaceApiToTypeDefinitionConverter = namespaceApiToTypeDefinitionConverter;
            this.registrationOptions = registrationOptions;
        }

        public void Reset()
        {
            entitiesContext.Classes.Clear();
        }

        public IEnumerable<ClassEntity> GetAllClassEntities()
        {
            return entitiesContext.Classes.GetAllClassEntities();
        }

        public ClassEntity RegisterNamespaceApi(IEnumerable<NamespaceDefinition> namespaceDefinitions, NamespaceEntity namespaceEntity)
        {
            var namespaceDefinition = namespaceDefinitions.First();
            if (namespaceDefinitions.Count() > 1)
            {
                namespaceDefinition = new NamespaceDefinition()
                {
                    Description = namespaceDefinitions.FirstOrDefault(definition => definition.Description is not null)?.Description,
                    Deprecated = namespaceDefinitions.FirstOrDefault(definition => definition.Deprecated is not null)?.Deprecated,
                    Events = namespaceDefinitions.SelectMany(definition => definition.Events ?? Enumerable.Empty<EventDefinition>()).ToArray(),
                    Functions = namespaceDefinitions.SelectMany(definition => definition.Functions ?? Enumerable.Empty<FunctionDefinition>()).ToArray(),
                    Namespace = namespaceDefinition.Namespace,
                    Permissions = namespaceDefinitions.SelectMany(definition => definition.Permissions ?? Enumerable.Empty<string>()).Distinct().ToArray(),
                    Properties = namespaceDefinitions.SelectMany(definition => definition.Properties ?? Enumerable.Empty<KeyValuePair<string, PropertyDefinition>>()).ToDictionary(propertyDefinitionPair => propertyDefinitionPair.Key, propertyDefinitionPair => propertyDefinitionPair.Value),
                    Source = namespaceDefinition.Source,
                    Types = namespaceDefinitions.SelectMany(definition => definition.Types ?? Enumerable.Empty<TypeDefinition>()).ToArray()
                };
            }
            var namespaceApiTypeDefinition = namespaceApiToTypeDefinitionConverter.Convert(namespaceDefinition, namespaceEntity);

            if (namespaceApiTypeDefinition.Id is null)
            {
                throw new InvalidOperationException("Namespace Api should have an Id.");
            }

            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(namespaceApiTypeDefinition.Id);
            var typeEntity = new TypeEntity(namespaceApiTypeDefinition.Id, namespaceQualifiedId, namespaceEntity, namespaceApiTypeDefinition);
            return apiClassEntityRegistrar.RegisterClass(typeEntity);
        }

        public void RegisterNestedNamespaceApi(ClassEntity classEntity, ClassEntity nestedClassEntity)
        {
            var propertyDefinition = GetPropertyDefinition(nestedClassEntity);
            classEntity.Properties.Add(nestedClassEntity.NamespaceEntity.Name, propertyDefinition);
        }

        public void RegisterRootApi(IEnumerable<ClassEntity> classEntities)
        {
            var namespaceEntity = new NamespaceEntity(null, string.Empty, string.Empty);
            var typeDefinition = new TypeDefinition()
            {
                Description = registrationOptions.RootApiClassDescription,
                ObjectProperties = classEntities
                    .Where(classEntity => classEntity.NamespaceEntity.Parent is null)
                    .Select(classEntity =>
                    {
                        var propertyDefinition = GetPropertyDefinition(classEntity);
                        return KeyValuePair.Create(classEntity.NamespaceEntity.Name, propertyDefinition);
                    }).ToDictionary(p => p.Key, p => p.Value)
            };
            var typeEntity = new TypeEntity(registrationOptions.RootApiClassName, registrationOptions.RootApiClassName, namespaceEntity, typeDefinition);
            rootApiClassEntityRegistrar.RegisterClass(typeEntity);
        }

        public bool TryRegisterTypeEntity(TypeEntity typeEntity, [MaybeNullWhen(false)] out ClassEntity classEntity)
        {
            var registrar = classEntityRegistrarFactory.GetClassEntityRegistrar(typeEntity.Definition);
            if (registrar is null)
            {
                classEntity = null;
                return false;
            }

            classEntity = registrar.RegisterClass(typeEntity);
            return true;
        }

        private static PropertyDefinition GetPropertyDefinition(ClassEntity classEntity)
        {
            var description = string.Join(" ", classEntity.NamespaceEntity.NamespaceDefinitions
                .Select(namespaceDefinition => namespaceDefinition.Description)
                .Where(namespaceDescription => !string.IsNullOrEmpty(namespaceDescription)));
            var permissions = string.Join(", ", classEntity.NamespaceEntity.NamespaceDefinitions
                .SelectMany(namespaceDefinition => namespaceDefinition.Permissions ?? Enumerable.Empty<string>())
                .Where(permission => !string.IsNullOrEmpty(permission))
                .Distinct());
            if (!string.IsNullOrEmpty(permissions))
            {
                description += $"<br>Requires manifest permission {permissions}.";
            }

            return new PropertyDefinition()
            {
                Description = description,
                Deprecated = classEntity.TypeDefinition.Deprecated,
                Type = ObjectType.ApiObject,
                Ref = classEntity.NamespaceQualifiedId
            };
        }
    }
}
