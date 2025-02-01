using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Repositories
{
    public class TypeRepository : BaseRepository<TypeEntity>
    {
        private readonly Dictionary<string, List<TypeDefinition>> typeExtensions = [];

        public void RegisterType(string typeId, TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(typeId);
            if (Entities.Exists(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId)))
            {
                throw new InvalidOperationException($"Type entity with id '{namespaceQualifiedId}' already exists.");
            }

            var entity = new TypeEntity(typeId, namespaceQualifiedId, namespaceEntity, typeDefinition);

            if (typeExtensions.ContainsKey(namespaceQualifiedId) && typeExtensions.Remove(namespaceQualifiedId, out var extensions))
            {
                // register all the type extensions that was registered before this type
                foreach (var extension in extensions)
                {
                    entity.Extensions.Add(extension);
                }
            }

            Entities.Add(entity);
        }

        public void RegisterTypeExtension(string typeId, TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(typeId);
            var entity = Entities.SingleOrDefault(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId));
            if (entity is null)
            {
                // The type to be extended is not yet registered, store the definition in a dictionary first
                if (typeExtensions.TryGetValue(namespaceQualifiedId, out var namespaceTypeDefinitions))
                {
                    namespaceTypeDefinitions.Add(typeDefinition);
                }
                else
                {
                    typeExtensions.Add(namespaceQualifiedId, new List<TypeDefinition>() { typeDefinition });
                }
            }
            else
            {
                entity.Extensions.Add(typeDefinition);
            }
        }

        public bool HasTypeEntity(string typeId, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(typeId);
            var entity = Entities.Find(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId));
            return entity is not null;
        }

        public TypeEntity GetTypeEntity(string typeId, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(typeId);
            var entity = Entities.Find(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId));
            if (entity is null)
            {
                throw new InvalidOperationException($"Type entity with id '{namespaceQualifiedId}' does not exists.");
            }
            return entity;
        }

        public IEnumerable<TypeEntity> GetAllTypes()
        {
            return Entities;
        }
    }
}
