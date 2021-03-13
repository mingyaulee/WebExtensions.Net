using System.Collections.Generic;
using System.Linq;

namespace WebExtension.Net.Generator.Models
{
    public class ClassDefinition : TypeDefinition
    {
        public ClassDefinition()
        {
            Properties = Enumerable.Empty<PropertyDefinition>();
            Functions = Enumerable.Empty<FunctionDefinition>();
        }

        public string? ExtendsClass { get; set; }
        public IEnumerable<PropertyDefinition> Properties { get; set; }
        public IEnumerable<FunctionDefinition> Functions { get; set; }
    }
}
