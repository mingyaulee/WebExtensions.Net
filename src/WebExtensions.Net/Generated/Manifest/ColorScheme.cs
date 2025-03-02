using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<ColorScheme>))]
    public enum ColorScheme
    {
        /// <summary>auto</summary>
        [EnumValue("auto")]
        Auto,

        /// <summary>light</summary>
        [EnumValue("light")]
        Light,

        /// <summary>dark</summary>
        [EnumValue("dark")]
        Dark,

        /// <summary>system</summary>
        [EnumValue("system")]
        System,
    }
}
