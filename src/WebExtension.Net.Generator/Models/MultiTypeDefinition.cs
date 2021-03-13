using System.Collections.Generic;
using System.Linq;

namespace WebExtension.Net.Generator.Models
{
    public class MultiTypeDefinition : TypeDefinition
    {
        public MultiTypeDefinition()
        {
            TypeReferences = Enumerable.Empty<TypeReference>();
        }

        public IEnumerable<TypeReference> TypeReferences { get; set; }
    }
}
