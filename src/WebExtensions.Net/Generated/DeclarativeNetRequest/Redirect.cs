using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary>Describes how the redirect should be performed. Only valid when type is 'redirect'.</summary>
    [BindAllProperties]
    public partial class Redirect : BaseObject
    {
        /// <summary>Path relative to the extension directory. Should start with '/'.</summary>
        [JsonPropertyName("extensionPath")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExtensionPath { get; set; }

        /// <summary>Substitution pattern for rules which specify a 'regexFilter'. The first match of regexFilter within the url will be replaced with this pattern. Within regexSubstitution, backslash-escaped digits (\1 to \9) can be used to insert the corresponding capture groups. \0 refers to the entire matching text.</summary>
        [JsonPropertyName("regexSubstitution")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RegexSubstitution { get; set; }

        /// <summary>Url transformations to perform.</summary>
        [JsonPropertyName("transform")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlTransform Transform { get; set; }

        /// <summary>The redirect url. Redirects to JavaScript urls are not allowed.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
