using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Repositories
{
    public class ClassRepository : BaseRepository<ClassEntity>
    {
        public ClassEntity RegisterClass(ClassType type, string className, TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(className);
            if (Entities.Any(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId)))
            {
                throw new InvalidOperationException($"Class entity with id '{namespaceQualifiedId}' already exists.");
            }

            var entity = new ClassEntity(type, className, namespaceQualifiedId, typeDefinition, namespaceEntity);
            Entities.Add(entity);

            return entity;
        }

        public ClassEntity GetClassEntity(string typeId, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(typeId);
            var entity = Entities.Find(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId));
            if (entity is null)
            {
                throw new InvalidOperationException($"Class entity with id '{namespaceQualifiedId}' does not exists.");
            }
            return entity;
        }

        public IEnumerable<ClassEntity> GetAllClassEntities()
        {
            return Entities;
        }
    }
}
