using System.Collections.Generic;
using System.Diagnostics;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities;

[DebuggerDisplay("{NamespaceQualifiedId}")]
public class ClassEntity(ClassType type, string className, string namespaceQualifiedId, TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
{
    public ClassType Type { get; } = type;
    public string Name { get; } = className;
    public string NamespaceQualifiedId { get; } = namespaceQualifiedId;
    public string FormattedName { get; } = className.ToCapitalCase();
    public TypeDefinition TypeDefinition { get; set; } = typeDefinition;
    public string? Description { get; set; } = typeDefinition.Description;
    public string? BaseClassName { get; set; }
    public bool ImplementInterface { get; set; }
    public NamespaceEntity NamespaceEntity { get; } = namespaceEntity;
    public IDictionary<string, PropertyDefinition> Properties { get; } = new Dictionary<string, PropertyDefinition>();
    public IList<FunctionDefinition> Functions { get; } = [];
}
