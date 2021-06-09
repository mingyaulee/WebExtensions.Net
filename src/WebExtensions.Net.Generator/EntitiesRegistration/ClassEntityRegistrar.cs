using System;
using System.Collections.Generic;
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

        public IEnumerable<ClassEntity> GetAllClassEntities()
        {
            return entitiesContext.Classes.GetAllClassEntities();
        }

        public ClassEntity RegisterNamespaceApi(NamespaceDefinition namespaceDefinition, NamespaceEntity namespaceEntity)
        {
            var namespaceApiTypeDefinition = namespaceApiToTypeDefinitionConverter.Convert(namespaceDefinition, namespaceEntity);

            if (namespaceApiTypeDefinition.Id is null)
            {
                throw new InvalidOperationException("Namespace Api should have an Id.");
            }

            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(namespaceApiTypeDefinition.Id);
            var typeEntity = new TypeEntity(namespaceApiTypeDefinition.Id, namespaceQualifiedId, namespaceEntity, namespaceApiTypeDefinition);
            return apiClassEntityRegistrar.RegisterClass(typeEntity);
        }

        public void RegisterRootApi(IEnumerable<ClassEntity> classEntities)
        {
            var namespaceEntity = new NamespaceEntity(string.Empty);
            var typeDefinition = new TypeDefinition()
            {
                Description = registrationOptions.RootApiClassDescription,
                ObjectProperties = classEntities.Select(classEntity =>
                {
                    var description = string.Join(" ", classEntity.NamespaceEntity.NamespaceDefinitions
                        .Select(namespaceDefinition => namespaceDefinition.Description)
                        .Where(namespaceDescription => !string.IsNullOrEmpty(namespaceDescription)));
                    var permissions = string.Join(", ", classEntity.NamespaceEntity.NamespaceDefinitions
                        .SelectMany(namespaceDefinition => namespaceDefinition.Permissions ?? Enumerable.Empty<string>())
                        .Where(permission => !string.IsNullOrEmpty(permission)));
                    if (!string.IsNullOrEmpty(permissions))
                    {
                        description += $"<br>Requires manifest permission {permissions}.";
                    }

                    var propertyDefinition = new PropertyDefinition()
                    {
                        Description = description,
                        Type = ObjectType.Object,
                        Ref = classEntity.NamespaceQualifiedId
                    };

                    return KeyValuePair.Create(classEntity.NamespaceEntity.Name, propertyDefinition);
                }).ToDictionary(p => p.Key, p => p.Value)
            };
            var typeEntity = new TypeEntity(registrationOptions.RootApiClassName, registrationOptions.RootApiClassName, namespaceEntity, typeDefinition);
            rootApiClassEntityRegistrar.RegisterClass(typeEntity);
        }

        public void RegisterTypeEntity(TypeEntity typeEntity)
        {
            var registrar = classEntityRegistrarFactory.GetClassEntityRegistrar(typeEntity.Definition);
            if (registrar is null)
            {
                return;
            }

            registrar.RegisterClass(typeEntity);
        }
    }
}
