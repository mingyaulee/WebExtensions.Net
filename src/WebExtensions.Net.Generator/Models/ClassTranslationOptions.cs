using System.Collections.Generic;

namespace WebExtensions.Net.Generator.Models
{
    public class ClassTranslationOptions
    {
#pragma warning disable CS8618 // Properties are initialized when created
        public IDictionary<string, string> NamespaceAliases { get; set; }
        public IDictionary<string, string> Aliases { get; set; }
        public IDictionary<string, string> ReplaceNames { get; set; }
#pragma warning restore CS8618
    }
}
