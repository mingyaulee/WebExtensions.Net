using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.Repositories;

public class NamespaceRepository : BaseRepository<NamespaceEntity>
{
    public NamespaceEntity RegisterNamespace(NamespaceEntity? parentEntity, string @namespace)
    {
        var fullName = parentEntity is null ? @namespace : parentEntity.GetNamespaceQualifiedId(@namespace);
        var entity = Entities.SingleOrDefault(e => e.FullName.Equals(fullName));
        if (entity is null)
        {
            entity = new NamespaceEntity(parentEntity, @namespace, fullName);
            Entities.Add(entity);
        }
        return entity;
    }

    public IEnumerable<NamespaceEntity> GetAllNamespaceEntities() => Entities;
}
