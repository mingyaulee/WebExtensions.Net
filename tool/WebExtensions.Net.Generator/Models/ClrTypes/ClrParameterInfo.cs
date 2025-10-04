using System.Diagnostics;

namespace WebExtensions.Net.Generator.Models.ClrTypes
{
    [DebuggerDisplay("{Name}")]
    public class ClrParameterInfo
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public string Name { get; set; }
        public string? Description { get; set; }
        public ClrTypeInfo ParameterType { get; set; }
        public bool IsOptional { get; set; }
        public bool IsObsolete { get; set; }
        public string? ObsoleteMessage { get; set; }
#pragma warning restore CS8618
    }
}
