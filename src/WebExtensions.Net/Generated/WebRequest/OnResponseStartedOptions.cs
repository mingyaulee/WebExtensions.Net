using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OnResponseStartedOptions>))]
    public enum OnResponseStartedOptions
    {
        /// <summary>responseHeaders</summary>
        [EnumValue("responseHeaders")]
        ResponseHeaders,
    }
}
