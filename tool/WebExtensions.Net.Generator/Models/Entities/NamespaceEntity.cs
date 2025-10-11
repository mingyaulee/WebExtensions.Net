using System.Collections.Generic;
using System.Diagnostics;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities;

[DebuggerDisplay("{Name}")]
public class NamespaceEntity
{
    public NamespaceEntity(NamespaceEntity? parentEntity, string name, string fullName)
    {
        Parent = parentEntity;
        Name = name;
        FullName = fullName;
        FormattedName = name.ToCapitalCase();
        FullFormattedName = parentEntity is null ? FormattedName : $"{parentEntity.FullFormattedName}.{FormattedName}";
        NamespaceDefinitions = [];
        OriginalNamespaceDefinitions = [];
    }

    public NamespaceEntity? Parent { get; }
    public string Name { get; }
    public string FullName { get; }
    public string FormattedName { get; }
    public string FullFormattedName { get; }
    public IList<NamespaceDefinition> NamespaceDefinitions { get; }
    public IList<NamespaceDefinition> OriginalNamespaceDefinitions { get; }
}
