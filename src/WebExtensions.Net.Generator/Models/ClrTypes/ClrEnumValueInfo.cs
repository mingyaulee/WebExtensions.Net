using System.Diagnostics;

namespace WebExtensions.Net.Generator.Models.ClrTypes
{
    [DebuggerDisplay("{CSharpName}")]
    public class ClrEnumValueInfo
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public string Name { get; set; }
        public string CSharpName { get; set; }
        public string? Description { get; set; }
#pragma warning restore CS8618
    }
}
