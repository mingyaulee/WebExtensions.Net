using System.Collections.Generic;
using System.Diagnostics;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities
{
    [DebuggerDisplay("{Name}")]
    public class AnonymousTypeEntityRegistrationInfo
    {
        public AnonymousTypeEntityRegistrationInfo(IEnumerable<string> nameHierarchy, TypeReference typeReference, NamespaceEntity namespaceEntity)
        {
            Name = string.Join('.', nameHierarchy);
            NameHierarchy = nameHierarchy;
            TypeReference = typeReference;
            NamespaceEntity = namespaceEntity;
        }

        public string Name { get; }
        public IEnumerable<string> NameHierarchy { get; set; }
        public TypeReference TypeReference { get; }
        public NamespaceEntity NamespaceEntity { get; }
    }
}
