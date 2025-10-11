using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.Extensions;

public static class NamespaceEntityExtensions
{
    public static string GetNamespaceQualifiedId(this NamespaceEntity namespaceEntity, string id)
        => string.IsNullOrEmpty(namespaceEntity.FullName) || id.Contains('.') ? id : $"{namespaceEntity.FullName}.{id}";
}
