using System.Collections.Generic;
using System.Diagnostics;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Models.Entities
{
    [DebuggerDisplay("{NamespaceQualifiedId}")]
    public class ClassEntity
    {
        public ClassEntity(ClassType type, string className, string namespaceQualifiedId, NamespaceEntity namespaceEntity)
        {
            Type = type;
            Name = className;
            NamespaceQualifiedId = namespaceQualifiedId;
            FormattedName = className.ToCapitalCase();
            NamespaceEntity = namespaceEntity;
            Properties = new Dictionary<string, PropertyDefinition>();
            Functions = new List<FunctionDefinition>();
        }

        public ClassType Type { get; }
        public string Name { get; }
        public string NamespaceQualifiedId { get; }
        public string FormattedName { get; }
        public TypeDefinition? TypeDefinition { get; set; }
        public string? Description { get; set; }
        public string? BaseClassName { get; set; }
        public bool ImplementInterface { get; set; }
        public NamespaceEntity NamespaceEntity { get; }
        public IDictionary<string, PropertyDefinition> Properties { get; }
        public IList<FunctionDefinition> Functions { get; }
    }
}
