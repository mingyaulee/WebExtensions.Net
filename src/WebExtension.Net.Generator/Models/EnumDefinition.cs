using System.Collections.Generic;
using System.Linq;

namespace WebExtension.Net.Generator.Models
{
    public class EnumDefinition : TypeDefinition
    {
        public EnumDefinition()
        {
            Values = Enumerable.Empty<EnumValueDefinition>();
        }

        public IEnumerable<EnumValueDefinition> Values { get; set; }
    }
}
