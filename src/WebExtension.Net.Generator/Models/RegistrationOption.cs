using System.Collections.Generic;

namespace WebExtension.Net.Generator.Models
{
    public class RegistrationOption
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public string RootApiClassName { get; init; }
        public string RootApiClassDescription { get; init; }
        public string ApiClassBaseClassName { get; init; }
        public string ApiClassNamePostfix { get; init; }
        public string ObjectTypeClassBaseClassName { get; init; }
        public string StringFormatClassBaseClassName { get; init; }
        public string ArrayClassBaseClassName { get; init; }
        public IEnumerable<string> IncludeNamespaces { get; init; }
        public IEnumerable<string> ExcludeNamespaces { get; init; }
#pragma warning restore CS8618
    }
}
