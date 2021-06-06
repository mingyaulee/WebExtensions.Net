using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OnBeforeSendHeadersOptions>))]
    public enum OnBeforeSendHeadersOptions
    {
        /// <summary>requestHeaders</summary>
        [EnumValue("requestHeaders")]
        RequestHeaders,

        /// <summary>blocking</summary>
        [EnumValue("blocking")]
        Blocking,
    }
}
