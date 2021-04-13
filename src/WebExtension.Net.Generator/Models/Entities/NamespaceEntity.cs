using System.Collections.Generic;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Models.Entities
{
    public class NamespaceEntity
    {
        public NamespaceEntity(string name)
        {
            Name = name;
            FormattedName = name.ToCapitalCase();
            NamespaceDefinitions = new List<NamespaceDefinition>();
        }

        public string Name { get; }
        public string FormattedName { get; }
        public IList<NamespaceDefinition> NamespaceDefinitions { get; }
    }
}
