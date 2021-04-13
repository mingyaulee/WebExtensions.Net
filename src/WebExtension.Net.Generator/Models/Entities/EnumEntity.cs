using System.Collections.Generic;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Models.Entities
{
    public class EnumEntity
    {
        public EnumEntity(string className, string namespaceQualifiedId, NamespaceEntity namespaceEntity)
        {
            Name = className;
            NamespaceQualifiedId = namespaceQualifiedId;
            FormattedName = className.ToCapitalCase();
            NamespaceEntity = namespaceEntity;
            EnumValues = new List<EnumValueDefinition>();
        }

        public string Name { get; }
        public string NamespaceQualifiedId { get; }
        public string FormattedName { get; }
        public string? Description { get; set; }
        public string? Deprecated { get; set; }
        public bool IsDeprecated { get; set; }
        public NamespaceEntity NamespaceEntity { get; }
        public IList<EnumValueDefinition> EnumValues { get; }
    }
}
