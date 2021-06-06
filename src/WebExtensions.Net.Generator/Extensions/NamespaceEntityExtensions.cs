using WebExtensions.Net.Generator.Models.Entities;

namespace WebExtensions.Net.Generator.Extensions
{
    public static class NamespaceEntityExtensions
    {
        public static string GetNamespaceQualifiedId(this NamespaceEntity namespaceEntity, string id)
        {
            if (string.IsNullOrEmpty(namespaceEntity.Name) || id.Contains("."))
            {
                return id;
            }
            return $"{namespaceEntity.Name}.{id}";
        }
    }
}
