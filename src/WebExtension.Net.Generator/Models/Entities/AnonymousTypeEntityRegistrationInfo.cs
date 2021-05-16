using System.Collections.Generic;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Models.Entities
{
    public class AnonymousTypeEntityRegistrationInfo
    {
        public AnonymousTypeEntityRegistrationInfo(IEnumerable<string> nameHierarchy, TypeReference typeReference, NamespaceEntity namespaceEntity)
        {
            NameHierarchy = nameHierarchy;
            TypeReference = typeReference;
            NamespaceEntity = namespaceEntity;
        }

        public IEnumerable<string> NameHierarchy { get; set; }
        public TypeReference TypeReference { get; }
        public NamespaceEntity NamespaceEntity { get; }
    }
}
