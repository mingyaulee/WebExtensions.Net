using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class ContextOptions : BaseObject
    {
        /// <summary>Required when context is 'bookmark'. Requires 'bookmark' permission.</summary>
        [JsonPropertyName("bookmarkId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BookmarkId { get; set; }

        /// <summary>ContextType to override, to allow menu items from other extensions in the menu. Currently only 'bookmark' and 'tab' are supported. showDefaults cannot be used with this option.</summary>
        [JsonPropertyName("context")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Context { get; set; }

        /// <summary>Whether to also include default menu items in the menu.</summary>
        [JsonPropertyName("showDefaults")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowDefaults { get; set; }

        /// <summary>Required when context is 'tab'. Requires 'tabs' permission.</summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
    }
}
