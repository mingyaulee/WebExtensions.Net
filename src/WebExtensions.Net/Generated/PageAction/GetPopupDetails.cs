using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction
{
    // Type Class
    /// <summary></summary>
    public partial class GetPopupDetails : BaseObject
    {
        private int _tabId;

        /// <summary>Specify the tab to get the popup from.</summary>
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
