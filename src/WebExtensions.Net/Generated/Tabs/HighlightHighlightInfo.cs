using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class HighlightHighlightInfo : BaseObject
    {
        private bool? _populate;
        private HighlightInfoTabs _tabs;
        private int? _windowId;

        /// <summary>If true, the $(ref:windows.Window) returned will have a <c>tabs</c> property that contains a list of the $(ref:tabs.Tab) objects. The <c>Tab</c> objects only contain the <c>url</c>, <c>title</c> and <c>favIconUrl</c> properties if the extension's manifest file includes the <c>"tabs"</c> permission. If false, the $(ref:windows.Window) won't have the <c>tabs</c> property.</summary>
        [JsonPropertyName("populate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Populate
        {
            get
            {
                InitializeProperty("populate", _populate);
                return _populate;
            }
            set
            {
                _populate = value;
            }
        }

        /// <summary>One or more tab indices to highlight.</summary>
        [JsonPropertyName("tabs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HighlightInfoTabs Tabs
        {
            get
            {
                InitializeProperty("tabs", _tabs);
                return _tabs;
            }
            set
            {
                _tabs = value;
            }
        }

        /// <summary>The window that contains the tabs.</summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId
        {
            get
            {
                InitializeProperty("windowId", _windowId);
                return _windowId;
            }
            set
            {
                _windowId = value;
            }
        }
    }
}
