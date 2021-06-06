using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes
{
    /// <summary>The origin of the CSS to inject, this affects the cascading order (priority) of the stylesheet.</summary>
    [JsonConverter(typeof(EnumStringConverter<CSSOrigin>))]
    public enum CSSOrigin
    {
        /// <summary>user</summary>
        [EnumValue("user")]
        User,

        /// <summary>author</summary>
        [EnumValue("author")]
        Author,
    }
}
