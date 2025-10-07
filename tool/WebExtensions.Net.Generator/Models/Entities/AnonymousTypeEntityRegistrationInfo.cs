using System.Collections.Generic;
using System.Diagnostics;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities
{
    [DebuggerDisplay("{Name}")]
    public class AnonymousTypeEntityRegistrationInfo(IEnumerable<string> nameHierarchy, TypeReference typeReference, NamespaceEntity namespaceEntity)
    {
        public string Name { get; } = string.Join('.', nameHierarchy);
        public IEnumerable<string> NameHierarchy { get; set; } = nameHierarchy;
        public TypeReference TypeReference { get; } = typeReference;
        public ICollection<TypeReference> OtherReferences { get; } = [];
        public NamespaceEntity NamespaceEntity { get; } = namespaceEntity;
    }
}
