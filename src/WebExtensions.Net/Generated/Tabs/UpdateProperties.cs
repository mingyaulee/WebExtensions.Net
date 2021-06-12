using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public partial class UpdateProperties : BaseObject
    {
        private bool? _active;
        private bool? _highlighted;
        private bool? _loadReplace;
        private bool? _muted;
        private int? _openerTabId;
        private bool? _pinned;
        private int? _successorTabId;
        private string _url;

        /// <summary>Whether the tab should be active. Does not affect whether the window is focused (see $(ref:windows.update)).</summary>
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

        /// <summary>Adds or removes the tab from the current selection.</summary>
        [JsonPropertyName("highlighted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Highlighted
        {
            get
            {
                InitializeProperty("highlighted", _highlighted);
                return _highlighted;
            }
            set
            {
                _highlighted = value;
            }
        }

        /// <summary>Whether the load should replace the current history entry for the tab.</summary>
        [JsonPropertyName("loadReplace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LoadReplace
        {
            get
            {
                InitializeProperty("loadReplace", _loadReplace);
                return _loadReplace;
            }
            set
            {
                _loadReplace = value;
            }
        }

        /// <summary>Whether the tab should be muted.</summary>
        [JsonPropertyName("muted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Muted
        {
            get
            {
                InitializeProperty("muted", _muted);
                return _muted;
            }
            set
            {
                _muted = value;
            }
        }

        /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as this tab.</summary>
        [JsonPropertyName("openerTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OpenerTabId
        {
            get
            {
                InitializeProperty("openerTabId", _openerTabId);
                return _openerTabId;
            }
            set
            {
                _openerTabId = value;
            }
        }

        /// <summary>Whether the tab should be pinned.</summary>
        [JsonPropertyName("pinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned
        {
            get
            {
                InitializeProperty("pinned", _pinned);
                return _pinned;
            }
            set
            {
                _pinned = value;
            }
        }

        /// <summary>The ID of this tab's successor. If specified, the successor tab must be in the same window as this tab.</summary>
        [JsonPropertyName("successorTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SuccessorTabId
        {
            get
            {
                InitializeProperty("successorTabId", _successorTabId);
                return _successorTabId;
            }
            set
            {
                _successorTabId = value;
            }
        }

        /// <summary>A URL to navigate the tab to.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
