using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    public partial class DoubleDelta : BaseObject
    {
        private double? _current;
        private double? _previous;

        /// <summary></summary>
        [JsonPropertyName("current")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Current
        {
            get
            {
                InitializeProperty("current", _current);
                return _current;
            }
            set
            {
                _current = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("previous")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Previous
        {
            get
            {
                InitializeProperty("previous", _previous);
                return _previous;
            }
            set
            {
                _previous = value;
            }
        }
    }
}
