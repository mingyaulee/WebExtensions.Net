using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    public partial class HeadersArrayItem : BaseObject
    {
        private string _name;
        private string _value;

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

        /// <summary>Value of the HTTP header.</summary>
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
