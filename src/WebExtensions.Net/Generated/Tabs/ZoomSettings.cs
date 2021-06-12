using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Defines how zoom changes in a tab are handled and at what scope.</summary>
    public partial class ZoomSettings : BaseObject
    {
        private double? _defaultZoomFactor;
        private ZoomSettingsMode? _mode;
        private ZoomSettingsScope? _scope;

        /// <summary>Used to return the default zoom level for the current tab in calls to tabs.getZoomSettings.</summary>
        [JsonPropertyName("defaultZoomFactor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? DefaultZoomFactor
        {
            get
            {
                InitializeProperty("defaultZoomFactor", _defaultZoomFactor);
                return _defaultZoomFactor;
            }
            set
            {
                _defaultZoomFactor = value;
            }
        }

        /// <summary>Defines how zoom changes are handled, i.e. which entity is responsible for the actual scaling of the page; defaults to <c>automatic</c>.</summary>
        [JsonPropertyName("mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ZoomSettingsMode? Mode
        {
            get
            {
                InitializeProperty("mode", _mode);
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        /// <summary>Defines whether zoom changes will persist for the page's origin, or only take effect in this tab; defaults to <c>per-origin</c> when in <c>automatic</c> mode, and <c>per-tab</c> otherwise.</summary>
        [JsonPropertyName("scope")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ZoomSettingsScope? Scope
        {
            get
            {
                InitializeProperty("scope", _scope);
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }
    }
}
