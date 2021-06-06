using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OnSendHeadersOptions>))]
    public enum OnSendHeadersOptions
    {
        /// <summary>requestHeaders</summary>
        [EnumValue("requestHeaders")]
        RequestHeaders,
    }
}
