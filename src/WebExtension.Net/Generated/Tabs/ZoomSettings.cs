using System.Text.Json.Serialization;

namespace WebExtension.Net.Tabs
{
    // Type Class
    /// <summary>Defines how zoom changes in a tab are handled and at what scope.</summary>
    public class ZoomSettings : BaseObject
    {
        private ZoomSettingsMode _mode;
        private ZoomSettingsScope _scope;
        private double? _defaultZoomFactor;

        /// <summary>Defines how zoom changes are handled, i.e. which entity is responsible for the actual scaling of the page; defaults to <c>automatic</c>.</summary>
        [JsonPropertyName("mode")]
        public ZoomSettingsMode Mode
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
        public ZoomSettingsScope Scope
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

        /// <summary>Used to return the default zoom level for the current tab in calls to tabs.getZoomSettings.</summary>
        [JsonPropertyName("defaultZoomFactor")]
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
    }
}
