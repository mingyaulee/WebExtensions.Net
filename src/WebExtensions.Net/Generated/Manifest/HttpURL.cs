using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // String Format Class
    /// <summary></summary>
    [JsonConverter(typeof(StringFormatJsonConverter<HttpURL>))]
    public partial class HttpURL : BaseStringFormat
    {
        private const string FORMAT = "url";
        private const string PATTERN = "^https?://.*$";

        /// <summary>Creates a new instance of <see cref="HttpURL" />.</summary>
        public HttpURL(string value) : base(value, FORMAT, PATTERN)
        {
        }

        /// <summary>Converts from <see cref="HttpURL" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(HttpURL value) => value.Value;

        /// <summary>Converts from <see cref="string" /> to <see cref="HttpURL" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator HttpURL(string value) => new(value);
    }
}
