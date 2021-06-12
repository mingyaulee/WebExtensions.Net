using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public partial class DuplicateProperties : BaseObject
    {
        private bool? _active;
        private int? _index;

        /// <summary>Whether the tab should become the active tab in the window. Does not affect whether the window is focused (see $(ref:windows.update)). Defaults to <c>true</c>.</summary>
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active
        {
            get
            {
                InitializeProperty("active", _active);
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        /// <summary>The position the new tab should take in the window. The provided value will be clamped to between zero and the number of tabs in the window.</summary>
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index
        {
            get
            {
                InitializeProperty("index", _index);
                return _index;
            }
            set
            {
                _index = value;
            }
        }
    }
}
