using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    /// <summary>The style origin for the injection. Defaults to <c>'AUTHOR'</c>.</summary>
    [JsonConverter(typeof(EnumStringConverter<Origin>))]
    public enum Origin
    {
        /// <summary>USER</summary>
        [EnumValue("USER")]
        USER,

        /// <summary>AUTHOR</summary>
        [EnumValue("AUTHOR")]
        AUTHOR,
    }
}
