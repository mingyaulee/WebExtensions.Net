using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Models.Entities
{
    public class EntityRegistrationResult
    {
        public EntityRegistrationResult(IEnumerable<NamespaceEntity> namespaceEntities, IEnumerable<ClassEntity> classEntities)
        {
            Namespaces = namespaceEntities.ToDictionary(namespaceEntity => namespaceEntity.FormattedName, namespaceEntity => namespaceEntity.NamespaceDefinitions);
            ClassEntities = classEntities;
        }

        public IDictionary<string, IList<NamespaceDefinition>> Namespaces { get; }
        public IEnumerable<ClassEntity> ClassEntities { get; }
    }
}
