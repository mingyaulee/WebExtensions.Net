using System.Collections.Generic;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.Models.Entities
{
    public class ClassEntity
    {
        public ClassEntity(ClassEntityType type, string className, string namespaceQualifiedId, NamespaceEntity namespaceEntity)
        {
            Type = type;
            Name = className;
            NamespaceQualifiedId = namespaceQualifiedId;
            FormattedName = className.ToCapitalCase();
            NamespaceEntity = namespaceEntity;
            UsingRelativeNamespaces = new List<string>();
            Properties = new Dictionary<string, PropertyDefinition>();
            Functions = new List<FunctionDefinition>();
            Events = new List<EventDefinition>();
        }

        public ClassEntityType Type { get; }
        public string Name { get; }
        public string NamespaceQualifiedId { get; }
        public string FormattedName { get; }
        public TypeDefinition? TypeDefinition { get; set; }
        public string? Description { get; set; }
        public string? BaseClassName { get; set; }
        public bool ImplementInterface { get; set; }
        public NamespaceEntity NamespaceEntity { get; }
        public List<string> UsingRelativeNamespaces { get; }
        public IDictionary<string, PropertyDefinition> Properties { get; }
        public List<FunctionDefinition> Functions { get; }
        public List<EventDefinition> Events { get; }
    }
}
