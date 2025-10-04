using System.Collections.Generic;
using System.Diagnostics;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities
{
    [DebuggerDisplay("{NamespaceQualifiedId}")]
    public class ClassEntity
    {
        public ClassEntity(ClassType type, string className, string namespaceQualifiedId, TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
        {
            Type = type;
            Name = className;
            NamespaceQualifiedId = namespaceQualifiedId;
            FormattedName = className.ToCapitalCase();
            TypeDefinition = typeDefinition;
            Description = typeDefinition.Description;
            NamespaceEntity = namespaceEntity;
            Properties = new Dictionary<string, PropertyDefinition>();
            Functions = new List<FunctionDefinition>();
        }

        public ClassType Type { get; }
        public string Name { get; }
        public string NamespaceQualifiedId { get; }
        public string FormattedName { get; }
        public TypeDefinition TypeDefinition { get; set; }
        public string? Description { get; set; }
        public string? BaseClassName { get; set; }
        public bool ImplementInterface { get; set; }
        public NamespaceEntity NamespaceEntity { get; }
        public IDictionary<string, PropertyDefinition> Properties { get; }
        public IList<FunctionDefinition> Functions { get; }
    }
}
