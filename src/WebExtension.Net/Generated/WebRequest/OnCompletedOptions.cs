using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OnCompletedOptions>))]
    public enum OnCompletedOptions
    {
        /// <summary>responseHeaders</summary>
        [EnumValue("responseHeaders")]
        ResponseHeaders,
    }
}
