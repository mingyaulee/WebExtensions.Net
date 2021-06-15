using System.Text.Json.Serialization;

namespace WebExtensions.Net.Devtools.InspectedWindow
{
    // Type Class
    /// <summary></summary>
    public partial class ReloadOptions : BaseObject
    {
        private bool? _ignoreCache;
        private string _injectedScript;
        private string _userAgent;

        /// <summary>When true, the loader will bypass the cache for all inspected page resources loaded before the <c>load</c> event is fired. The effect is similar to pressing Ctrl+Shift+R in the inspected window or within the Developer Tools window.</summary>
        [JsonPropertyName("ignoreCache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreCache
        {
            get
            {
                InitializeProperty("ignoreCache", _ignoreCache);
                return _ignoreCache;
            }
            set
            {
                _ignoreCache = value;
            }
        }

        /// <summary>If specified, the script will be injected into every frame of the inspected page immediately upon load, before any of the frame's scripts. The script will not be injected after subsequent reloads-for example, if the user presses Ctrl+R.</summary>
        [JsonPropertyName("injectedScript")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string InjectedScript
        {
            get
            {
                InitializeProperty("injectedScript", _injectedScript);
                return _injectedScript;
            }
            set
            {
                _injectedScript = value;
            }
        }

        /// <summary>If specified, the string will override the value of the <c>User-Agent</c> HTTP header that's sent while loading the resources of the inspected page. The string will also override the value of the <c>navigator.userAgent</c> property that's returned to any scripts that are running within the inspected page.</summary>
        [JsonPropertyName("userAgent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UserAgent
        {
            get
            {
                InitializeProperty("userAgent", _userAgent);
                return _userAgent;
            }
            set
            {
                _userAgent = value;
            }
        }
    }
}
