using System.Collections.Generic;

namespace WebExtension.Net.Generator.Models
{
    public class FunctionDefinition : ICommonDefinition
    {
        public FunctionDefinition()
        {
            Parameters = new List<ParameterDefinition>();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Unsupported { get; set; }
        public bool Deprecated { get; set; }
        public string? DeprecatedMessage { get; set; }
        public string? FunctionAccessor { get; set; }
        public TypeReference? ReturnType { get; set; }
        public List<ParameterDefinition> Parameters { get; set; }
    }
}
