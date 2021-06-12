using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management
{
    /// <summary>The type of this extension, 'extension' or 'theme'.</summary>
    [JsonConverter(typeof(EnumStringConverter<ExtensionType>))]
    public enum ExtensionType
    {
        /// <summary>extension</summary>
        [EnumValue("extension")]
        Extension,

        /// <summary>theme</summary>
        [EnumValue("theme")]
        Theme,
    }
}
