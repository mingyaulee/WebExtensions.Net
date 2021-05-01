using System.Collections.Generic;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Models.Entities
{
    public class EntityRegistrationResult
    {
        public EntityRegistrationResult(IDictionary<string, IList<NamespaceDefinition>> namespaces, IEnumerable<ClassEntity> classEntities)
        {
            Namespaces = namespaces;
            ClassEntities = classEntities;
        }

        public IDictionary<string, IList<NamespaceDefinition>> Namespaces { get; }
        public IEnumerable<ClassEntity> ClassEntities { get; }
    }
}
