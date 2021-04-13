using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.Repositories
{
    public class EnumRepository : BaseRepository<EnumEntity>
    {
        public EnumEntity RegisterEnum(string enumName, NamespaceEntity namespaceEntity)
        {
            var namespaceQualifiedId = namespaceEntity.GetNamespaceQualifiedId(enumName);
            if (Entities.Any(e => e.NamespaceQualifiedId.Equals(namespaceQualifiedId)))
            {
                throw new InvalidOperationException($"Enum entity with id '{namespaceQualifiedId}' already exists.");
            }

            var entity = new EnumEntity(enumName, namespaceQualifiedId, namespaceEntity);
            Entities.Add(entity);

            return entity;
        }

        public IEnumerable<EnumEntity> GetAllEnumEntities()
        {
            return Entities;
        }
    }
}
