using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    public partial class AddListenerCallbackRemoved : BaseObject
    {
        private bool _allHistory;
        private IEnumerable<string> _urls;

        /// <summary>True if all history was removed.  If true, then urls will be empty.</summary>
        [JsonPropertyName("allHistory")]
        public bool AllHistory
        {
            get
            {
                InitializeProperty("allHistory", _allHistory);
                return _allHistory;
            }
            set
            {
                _allHistory = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("urls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Urls
        {
            get
            {
                InitializeProperty("urls", _urls);
                return _urls;
            }
            set
            {
                _urls = value;
            }
        }
    }
}
