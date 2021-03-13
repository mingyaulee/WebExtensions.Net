namespace WebExtension.Net.Generator.Models
{
    public class EnumValueDefinition : ICommonDefinition
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Unsupported { get; set; }
        public bool Deprecated { get; set; }
        public string? DeprecatedMessage { get; set; }
    }
}
