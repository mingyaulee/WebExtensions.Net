using System.Collections.Generic;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.Models
{
    public class SourceOptions
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public bool RunInParallel { get; init; }
        public bool UseLocalSources { get; init; }
        public string LocalDirectory { get; set; }
        public IEnumerable<ApiDefinitionSource> Sources { get; init; }
        public IEnumerable<NamespaceSourceDefinition> AdditionalNamespaceSourceDefinitions { get; init; }
#pragma warning restore CS8618
    }
}
