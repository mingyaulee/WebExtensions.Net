using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    [JsonConverter(typeof(StringFormatJsonConverter<HttpUrl>))]
    public partial class HttpUrl(string value) : BaseStringFormat(value, FORMAT, PATTERN)
    {
        private const string FORMAT = "url";
        private const string PATTERN = "^https?://.*$";

        /// <summary>Converts from <see cref="HttpUrl" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(HttpUrl value) => value.Value;

        /// <summary>Converts from <see cref="string" /> to <see cref="HttpUrl" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator HttpUrl(string value) => new(value);
    }
}
