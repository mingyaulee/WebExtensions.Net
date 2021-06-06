using System.Text.Json.Serialization;

namespace WebExtension.Net.WebNavigation
{
    // Type Class
    /// <summary>Information about the tab to retrieve all frames from.</summary>
    public class GetAllFramesDetails : BaseObject
    {
        private int _tabId;

        /// <summary>The ID of the tab.</summary>
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
