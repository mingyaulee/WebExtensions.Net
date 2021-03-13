using System.Collections.Generic;

namespace WebExtension.Net.Generator.Models
{
    public class TypeReference : ICommonDefinition
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Unsupported { get; set; }
        public bool Deprecated { get; set; }
        public string? DeprecatedMessage { get; set; }
        public string? Reference { get; set; }
        public string? Type { get; set; }
        public TypeReference? ArrayItemType { get; set; }
        public IEnumerable<TypeReference>? ChoicesType { get; set; }
    }
}
