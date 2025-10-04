using System.Collections.Generic;
using System.Diagnostics;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models.Entities
{
    [DebuggerDisplay("{NamespaceQualifiedId}")]
    public class TypeEntity
    {
        public TypeEntity(string typeId, string namespaceQualifiedId, NamespaceEntity namespaceEntity, TypeDefinition typeDefinition)
        {
            Id = typeId;
            NamespaceQualifiedId = namespaceQualifiedId;
            FormattedName = Id.ToCapitalCase();
            NamespaceEntity = namespaceEntity;
            Definition = typeDefinition;
            Extensions = new List<TypeDefinition>();
        }

        public string Id { get; }
        public string NamespaceQualifiedId { get; }
        public string FormattedName { get; }
        public NamespaceEntity NamespaceEntity { get; }
        public TypeDefinition Definition { get; }
        public IList<TypeDefinition> Extensions { get; }
        public bool IsReferenced { get; set; }
    }
}
