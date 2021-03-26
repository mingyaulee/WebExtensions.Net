using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WebExtension.Net.Generator.Models
{
    public class ApiDefinition : ICommonDefinition, IDirectoryNode
    {
        public ApiDefinition(JsonElement json)
        {
            URL = string.Empty;
            Json = new [] { json };
            Permissions = Enumerable.Empty<string>();
            Types = Enumerable.Empty<TypeDefinition>();
            Properties = Enumerable.Empty<PropertyDefinition>();
            Functions = Enumerable.Empty<FunctionDefinition>();
            Directory = string.Empty;
        }

        public string URL { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Unsupported { get; set; }
        public bool Deprecated { get; set; }
        public string? DeprecatedMessage { get; set; }
        public IEnumerable<JsonElement> Json { get; set; }
        public IEnumerable<string> Permissions { get;set; }
        public IEnumerable<TypeDefinition> Types { get;set; }
        public IEnumerable<PropertyDefinition> Properties { get; set; }
        public IEnumerable<FunctionDefinition> Functions { get;set; }
        public string? Directory { get; set; }
        public string? RootNamespace { get; set; }
    }
}
