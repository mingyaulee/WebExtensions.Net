using System.Collections.Generic;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities
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
