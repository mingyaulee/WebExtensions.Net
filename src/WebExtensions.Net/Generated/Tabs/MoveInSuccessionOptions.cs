using System.Text.Json.Serialization;

namespace WebExtension.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class MoveInSuccessionOptions : BaseObject
    {
        private bool? _append;
        private bool? _insert;

        /// <summary>Whether to move the tabs before (false) or after (true) tabId in the succession. Defaults to false.</summary>
        [JsonPropertyName("append")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Append
        {
            get
            {
                InitializeProperty("append", _append);
                return _append;
            }
            set
            {
                _append = value;
            }
        }

        /// <summary>Whether to link up the current predecessors or successor (depending on options.append) of tabId to the other side of the chain after it is prepended or appended. If true, one of the following happens: if options.append is false, the first tab in the array is set as the successor of any current predecessors of tabId; if options.append is true, the current successor of tabId is set as the successor of the last tab in the array. Defaults to false.</summary>
        [JsonPropertyName("insert")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Insert
        {
            get
            {
                InitializeProperty("insert", _insert);
                return _insert;
            }
            set
            {
                _insert = value;
            }
        }
    }
}
