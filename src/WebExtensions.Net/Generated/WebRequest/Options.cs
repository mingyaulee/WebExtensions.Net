using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    public class Options : BaseObject
    {
        private bool? _certificateChain;
        private bool? _rawDER;

        /// <summary>Include the entire certificate chain.</summary>
        [JsonPropertyName("certificateChain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CertificateChain
        {
            get
            {
                InitializeProperty("certificateChain", _certificateChain);
                return _certificateChain;
            }
            set
            {
                _certificateChain = value;
            }
        }

        /// <summary>Include raw certificate data for processing by the extension.</summary>
        [JsonPropertyName("rawDER")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RawDER
        {
            get
            {
                InitializeProperty("rawDER", _rawDER);
                return _rawDER;
            }
            set
            {
                _rawDER = value;
            }
        }
    }
}
