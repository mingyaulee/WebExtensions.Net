using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction
{
    // Type Class
    /// <summary></summary>
    public partial class SetPopupDetails : BaseObject
    {
        private Popup _popup;
        private int _tabId;

        /// <summary>The html file to show in a popup.  If set to the empty string (''), no popup is shown.</summary>
        [JsonPropertyName("popup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Popup Popup
        {
            get
            {
                InitializeProperty("popup", _popup);
                return _popup;
            }
            set
            {
                _popup = value;
            }
        }

        /// <summary>The id of the tab for which you want to modify the page action.</summary>
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
