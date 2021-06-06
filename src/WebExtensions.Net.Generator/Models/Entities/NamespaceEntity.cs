using System.Collections.Generic;
using System.Diagnostics;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities
{
    [DebuggerDisplay("{Name}")]
    public class NamespaceEntity
    {
        public NamespaceEntity(string name)
        {
            Name = name;
            FormattedName = name.ToCapitalCase();
            NamespaceDefinitions = new List<NamespaceDefinition>();
            OriginalNamepaceDefinitions = new List<NamespaceDefinition>();
        }

        public string Name { get; }
        public string FormattedName { get; }
        public IList<NamespaceDefinition> NamespaceDefinitions { get; }
        public IList<NamespaceDefinition> OriginalNamepaceDefinitions { get; }
    }
}
