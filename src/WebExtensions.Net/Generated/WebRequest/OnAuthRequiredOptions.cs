using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OnAuthRequiredOptions>))]
    public enum OnAuthRequiredOptions
    {
        /// <summary>responseHeaders</summary>
        [EnumValue("responseHeaders")]
        ResponseHeaders,

        /// <summary>blocking</summary>
        [EnumValue("blocking")]
        Blocking,

        /// <summary>asyncBlocking</summary>
        [EnumValue("asyncBlocking")]
        AsyncBlocking,
    }
}
