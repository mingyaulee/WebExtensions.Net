using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction
{
    // Type Class
    /// <summary></summary>
    public partial class SetTitleDetails : BaseObject
    {
        private int _tabId;
        private Title _title;

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

        /// <summary>The tooltip string.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Title Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }
    }
}
