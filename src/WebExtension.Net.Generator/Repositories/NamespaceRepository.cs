using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Repositories
{
    public class NamespaceRepository : BaseRepository<NamespaceEntity>
    {
        public NamespaceEntity RegisterNamespace(string @namespace, NamespaceDefinition namespaceDefinition)
        {
            var entity = Entities.SingleOrDefault(e => e.Name.Equals(@namespace));
            if (entity is null)
            {
                entity = new NamespaceEntity(@namespace);
                Entities.Add(entity);
            }
            entity.NamespaceDefinitions.Add(namespaceDefinition);
            return entity;
        }

        public IEnumerable<NamespaceEntity> GetAllNamespaceEntities()
        {
            return Entities;
        }
    }
}
