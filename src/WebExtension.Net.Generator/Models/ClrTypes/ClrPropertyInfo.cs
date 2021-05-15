using System.Diagnostics;
using System.Text.Json;

namespace WebExtension.Net.Generator.Models.ClrTypes
{
    [DebuggerDisplay("{Name}")]
    public class ClrPropertyInfo
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public string Name { get; set; }
        public string PrivateName { get; set; }
        public string PublicName { get; set; }
        public string? Description { get; set; }
        public ClrTypeInfo DeclaringType { get; set; }
        public ClrTypeInfo PropertyType { get; set; }
        public bool IsConstant { get; set; }
        public JsonElement? ConstantValue { get; set; }
        public bool IsObsolete { get; set; }
        public string? ObsoleteMessage { get; set; }
#pragma warning restore CS8618
    }
}
