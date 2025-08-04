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
        [JsAccessPath("active")]
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get; set; }

        /// <summary>Whether the tabs are drawing attention.</summary>
        [JsAccessPath("attention")]
        [JsonPropertyName("attention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Attention { get; set; }

        /// <summary>Whether the tabs are audible.</summary>
        [JsAccessPath("audible")]
        [JsonPropertyName("audible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Audible { get; set; }

        /// <summary>Whether the tab can be discarded automatically by the browser when resources are low.</summary>
        [JsAccessPath("autoDiscardable")]
        [JsonPropertyName("autoDiscardable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoDiscardable { get; set; }

        /// <summary>True if the tab is using the camera.</summary>
        [JsAccessPath("camera")]
        [JsonPropertyName("camera")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Camera { get; set; }

        /// <summary>The CookieStoreId used for the tab.</summary>
        [JsAccessPath("cookieStoreId")]
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CookieStoreId CookieStoreId { get; set; }

        /// <summary>Whether the tabs are in the $(topic:current-window)[current window].</summary>
        [JsAccessPath("currentWindow")]
        [JsonPropertyName("currentWindow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CurrentWindow { get; set; }

        /// <summary>True while the tabs are not loaded with content.</summary>
        [JsAccessPath("discarded")]
        [JsonPropertyName("discarded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Discarded { get; set; }

        /// <summary>The ID of the group that the tabs are in, or $(ref:tabGroups.TAB_GROUP_ID_NONE) (-1) for ungrouped tabs.</summary>
        [JsAccessPath("groupId")]
        [JsonPropertyName("groupId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? GroupId { get; set; }

        /// <summary>True while the tabs are hidden.</summary>
        [JsAccessPath("hidden")]
        [JsonPropertyName("hidden")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden { get; set; }

        /// <summary>Whether the tabs are highlighted.  Works as an alias of active.</summary>
        [JsAccessPath("highlighted")]
        [JsonPropertyName("highlighted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Highlighted { get; set; }

        /// <summary>The position of the tabs within their windows.</summary>
        [JsAccessPath("index")]
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }

        /// <summary>Whether the tabs are in the last focused window.</summary>
        [JsAccessPath("lastFocusedWindow")]
        [JsonPropertyName("lastFocusedWindow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LastFocusedWindow { get; set; }

        /// <summary>True if the tab is using the microphone.</summary>
        [JsAccessPath("microphone")]
        [JsonPropertyName("microphone")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Microphone { get; set; }

        /// <summary>Whether the tabs are muted.</summary>
        [JsAccessPath("muted")]
        [JsonPropertyName("muted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Muted { get; set; }

        /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as this tab.</summary>
        [JsAccessPath("openerTabId")]
        [JsonPropertyName("openerTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OpenerTabId { get; set; }

        /// <summary>Whether the tabs are pinned.</summary>
        [JsAccessPath("pinned")]
        [JsonPropertyName("pinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned { get; set; }

        /// <summary>True for any screen sharing, or a string to specify type of screen sharing.</summary>
        [JsAccessPath("screen")]
        [JsonPropertyName("screen")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Screen Screen { get; set; }

        /// <summary>Whether the tabs have completed loading.</summary>
        [JsAccessPath("status")]
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TabStatus? Status { get; set; }

        /// <summary>Match page titles against a pattern.</summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>Match tabs against one or more $(topic:match_patterns)[URL patterns]. Note that fragment identifiers are not matched.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Url Url { get; set; }

        /// <summary>The ID of the parent window, or $(ref:windows.WINDOW_ID_CURRENT) for the $(topic:current-window)[current window].</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }

        /// <summary>The type of window the tabs are in.</summary>
        [JsAccessPath("windowType")]
        [JsonPropertyName("windowType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowType? WindowType { get; set; }
    }
}
