using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class QueryInfo : BaseObject
    {
        /// <summary>Whether the tabs are active in their windows.</summary>
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get; set; }

        /// <summary>Whether the tabs are drawing attention.</summary>
        [JsonPropertyName("attention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Attention { get; set; }

        /// <summary>Whether the tabs are audible.</summary>
        [JsonPropertyName("audible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Audible { get; set; }

        /// <summary>True if the tab is using the camera.</summary>
        [JsonPropertyName("camera")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Camera { get; set; }

        /// <summary>The CookieStoreId used for the tab.</summary>
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CookieStoreId { get; set; }

        /// <summary>Whether the tabs are in the $(topic:current-window)[current window].</summary>
        [JsonPropertyName("currentWindow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CurrentWindow { get; set; }

        /// <summary>True while the tabs are not loaded with content.</summary>
        [JsonPropertyName("discarded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Discarded { get; set; }

        /// <summary>True while the tabs are hidden.</summary>
        [JsonPropertyName("hidden")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden { get; set; }

        /// <summary>Whether the tabs are highlighted.  Works as an alias of active.</summary>
        [JsonPropertyName("highlighted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Highlighted { get; set; }

        /// <summary>The position of the tabs within their windows.</summary>
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }

        /// <summary>Whether the tabs are in the last focused window.</summary>
        [JsonPropertyName("lastFocusedWindow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LastFocusedWindow { get; set; }

        /// <summary>True if the tab is using the microphone.</summary>
        [JsonPropertyName("microphone")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Microphone { get; set; }

        /// <summary>Whether the tabs are muted.</summary>
        [JsonPropertyName("muted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Muted { get; set; }

        /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as this tab.</summary>
        [JsonPropertyName("openerTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OpenerTabId { get; set; }

        /// <summary>Whether the tabs are pinned.</summary>
        [JsonPropertyName("pinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned { get; set; }

        /// <summary>True for any screen sharing, or a string to specify type of screen sharing.</summary>
        [JsonPropertyName("screen")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Screen Screen { get; set; }

        /// <summary>Whether the tabs have completed loading.</summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TabStatus? Status { get; set; }

        /// <summary>Match page titles against a pattern.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>Match tabs against one or more $(topic:match_patterns)[URL patterns]. Note that fragment identifiers are not matched.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Url Url { get; set; }

        /// <summary>The ID of the parent window, or $(ref:windows.WINDOW_ID_CURRENT) for the $(topic:current-window)[current window].</summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }

        /// <summary>The type of window the tabs are in.</summary>
        [JsonPropertyName("windowType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowType? WindowType { get; set; }
    }
}
