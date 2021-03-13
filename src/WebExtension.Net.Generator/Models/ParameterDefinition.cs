using System.Collections.Generic;
using System.Linq;

namespace WebExtension.Net.Generator.Models
{
    public class ParameterDefinition : ICommonDefinition
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Unsupported { get; set; }
        public bool Deprecated { get; set; }
        public string? DeprecatedMessage { get; set; }
        public TypeReference? TypeReference { get; set; }
        public bool Optional { get; set; }
    }
}
