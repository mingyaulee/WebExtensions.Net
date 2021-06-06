using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OnBeforeRedirectOptions>))]
    public enum OnBeforeRedirectOptions
    {
        /// <summary>responseHeaders</summary>
        [EnumValue("responseHeaders")]
        ResponseHeaders,
    }
}
