using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    /// <summary>The HTTP method to use if the URL uses the HTTP[S] protocol.</summary>
    [JsonConverter(typeof(EnumStringConverter<Method>))]
    public enum Method
    {
        /// <summary>GET</summary>
        [EnumValue("GET")]
        GET,

        /// <summary>POST</summary>
        [EnumValue("POST")]
        POST,
    }
}
