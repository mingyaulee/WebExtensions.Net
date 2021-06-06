using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    public class HttpHeadersArrayItem : BaseObject
    {
        private IEnumerable<int> _binaryValue;
        private string _name;
        private string _value;

        /// <summary>Value of the HTTP header if it cannot be represented by UTF-8, stored as individual byte values (0..255).</summary>
        [JsonPropertyName("binaryValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> BinaryValue
        {
            get
            {
                InitializeProperty("binaryValue", _binaryValue);
                return _binaryValue;
            }
            set
            {
                _binaryValue = value;
            }
        }

        /// <summary>Name of the HTTP header.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>Value of the HTTP header if it can be represented by UTF-8.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Value
        {
            get
            {
                InitializeProperty("value", _value);
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}
