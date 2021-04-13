using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.Repositories
{
    public class ClassRepository : BaseRepository<ClassEntity>
    {
        public ClassEntity RegisterClass(ClassEntityType type, string className, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(className);
            if (Entities.Any(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId)))
            {
                throw new InvalidOperationException($"Class entity with id '{namespaceQualifiedId}' already exists.");
            }

            var entity = new ClassEntity(type, className, namespaceQualifiedId, namespaceEntity);
            Entities.Add(entity);

            return entity;
        }

        public IEnumerable<ClassEntity> GetAllClassEntities()
        {
            return Entities;
        }
    }
}
