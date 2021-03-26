namespace WebExtension.Net.Generator.Models
{
    public class PropertyDefinition : ICommonDefinition
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Unsupported { get; set; }
        public bool Deprecated { get; set; }
        public string? DeprecatedMessage { get; set; }
        public TypeReference? Type { get; set; }
        public bool Optional { get; set; }
        public bool Constant { get; set; }
        public string? ConstantValue { get; set; }
    }
}
