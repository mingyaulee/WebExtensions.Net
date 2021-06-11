using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Repositories
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
            entity.OriginalNamespaceDefinitions.Add(SerializationHelper.DeserializeTo<NamespaceDefinition>(namespaceDefinition));
            return entity;
        }

        public IEnumerable<NamespaceEntity> GetAllNamespaceEntities()
        {
            return Entities;
        }
    }
}
