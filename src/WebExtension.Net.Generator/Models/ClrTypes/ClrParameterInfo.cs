namespace WebExtension.Net.Generator.Models.ClrTypes
{
    public class ClrParameterInfo
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public string Name { get; set; }
        public string? Description { get; set; }
        public ClrTypeInfo ParameterType { get; set; }
        public bool IsObsolete { get; set; }
        public string? ObsoleteMessage { get; set; }
#pragma warning restore CS8618
    }
}
