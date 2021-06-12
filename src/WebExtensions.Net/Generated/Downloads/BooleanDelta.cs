using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    public partial class BooleanDelta : BaseObject
    {
        private bool? _current;
        private bool? _previous;

        /// <summary></summary>
        [JsonPropertyName("current")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Current
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
        public bool? Previous
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
