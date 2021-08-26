using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowsingData
{
    // Type Class
    /// <summary>A set of data types. Missing data types are interpreted as <c>false</c>.</summary>
    [BindAllProperties]
    public partial class DataTypeSet : BaseObject
    {
        /// <summary>The browser's cache. Note: when removing data, this clears the <em>entire</em> cache: it is not limited to the range you specify.</summary>
        [JsonPropertyName("cache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Cache { get; set; }

        /// <summary>The browser's cookies.</summary>
        [JsonPropertyName("cookies")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Cookies { get; set; }

        /// <summary>The browser's download list.</summary>
        [JsonPropertyName("downloads")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Downloads { get; set; }

        /// <summary>The browser's stored form data.</summary>
        [JsonPropertyName("formData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FormData { get; set; }

        /// <summary>The browser's history.</summary>
        [JsonPropertyName("history")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? History { get; set; }

        /// <summary>Websites' IndexedDB data.</summary>
        [JsonPropertyName("indexedDB")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IndexedDB { get; set; }

        /// <summary>Websites' local storage data.</summary>
        [JsonPropertyName("localStorage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LocalStorage { get; set; }

        /// <summary>Stored passwords.</summary>
        [JsonPropertyName("passwords")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Passwords { get; set; }

        /// <summary>Plugins' data.</summary>
        [JsonPropertyName("pluginData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PluginData { get; set; }

        /// <summary>Server-bound certificates.</summary>
        [JsonPropertyName("serverBoundCertificates")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ServerBoundCertificates { get; set; }

        /// <summary>Service Workers.</summary>
        [JsonPropertyName("serviceWorkers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ServiceWorkers { get; set; }
    }
}
