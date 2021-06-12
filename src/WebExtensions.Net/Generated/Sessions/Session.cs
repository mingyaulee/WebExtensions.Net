using System.Text.Json.Serialization;
using WebExtensions.Net.Tabs;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net.Sessions
{
    // Type Class
    /// <summary></summary>
    public partial class Session : BaseObject
    {
        private int _lastModified;
        private Tab _tab;
        private Window _window;

        /// <summary>The time when the window or tab was closed or modified, represented in milliseconds since the epoch.</summary>
        [JsonPropertyName("lastModified")]
        public int LastModified
        {
            get
            {
                InitializeProperty("lastModified", _lastModified);
                return _lastModified;
            }
            set
            {
                _lastModified = value;
            }
        }

        /// <summary>The $(ref:tabs.Tab), if this entry describes a tab. Either this or $(ref:sessions.Session.window) will be set.</summary>
        [JsonPropertyName("tab")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Tab Tab
        {
            get
            {
                InitializeProperty("tab", _tab);
                return _tab;
            }
            set
            {
                _tab = value;
            }
        }

        /// <summary>The $(ref:windows.Window), if this entry describes a window. Either this or $(ref:sessions.Session.tab) will be set.</summary>
        [JsonPropertyName("window")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Window Window
        {
            get
            {
                InitializeProperty("window", _window);
                return _window;
            }
            set
            {
                _window = value;
            }
        }
    }
}
