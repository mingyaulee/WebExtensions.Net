using System.Collections.Generic;

namespace WebExtension.Net.Generator.Models
{
    public class ApiDefinitionRoot : IDirectoryNode
    {
        public ApiDefinitionRoot()
        {
            DefinitionUrls = new List<string>();
            ApiDefinitions = new List<ApiDefinition>();
            RootNamespace = string.Empty;
        }

        public List<string> DefinitionUrls { get; set; }
        public List<ApiDefinition> ApiDefinitions { get; set; }
        public string RootNamespace { get; set; }
        public string? Directory { get; set; }
    }
}
