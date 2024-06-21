using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class HttpHeader : BaseObject
    {
        /// <summary>Value of the HTTP header if it cannot be represented by UTF-8, stored as individual byte values (0..255).</summary>
        [JsAccessPath("binaryValue")]
        [JsonPropertyName("binaryValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> BinaryValue { get; set; }

        /// <summary>Name of the HTTP header.</summary>
        [JsAccessPath("name")]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>Value of the HTTP header if it can be represented by UTF-8.</summary>
        [JsAccessPath("value")]
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value { get; set; }
    }
}
