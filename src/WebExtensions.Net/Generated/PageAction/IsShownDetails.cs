using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction
{
    // Type Class
    /// <summary></summary>
    public partial class IsShownDetails : BaseObject
    {
        private int _tabId;

        /// <summary>Specify the tab to get the shownness from.</summary>
        [JsonPropertyName("tabId")]
        public int TabId
        {
            get
            {
                InitializeProperty("tabId", _tabId);
                return _tabId;
            }
            set
            {
                _tabId = value;
            }
        }
    }
}
