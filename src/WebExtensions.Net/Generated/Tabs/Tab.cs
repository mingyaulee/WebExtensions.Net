using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Tab : BaseObject
    {
        /// <summary>Whether the tab is active in its window. (Does not necessarily mean the window is focused.)</summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>Whether the tab is drawing attention.</summary>
        [JsonPropertyName("attention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Attention { get; set; }

        /// <summary>Whether the tab has produced sound over the past couple of seconds (but it might not be heard if also muted). Equivalent to whether the speaker audio indicator is showing.</summary>
        [JsonPropertyName("audible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Audible { get; set; }

        /// <summary>Whether the tab can be discarded automatically by the browser when resources are low.</summary>
        [JsonPropertyName("autoDiscardable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoDiscardable { get; set; }

        /// <summary>The CookieStoreId used for the tab.</summary>
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CookieStoreId { get; set; }

        /// <summary>True while the tab is not loaded with content.</summary>
        [JsonPropertyName("discarded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Discarded { get; set; }

        /// <summary>The URL of the tab's favicon. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission. It may also be an empty string if the tab is loading.</summary>
        [JsonPropertyName("favIconUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FavIconUrl { get; set; }

        /// <summary>The height of the tab in pixels.</summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height { get; set; }

        /// <summary>True if the tab is hidden.</summary>
        [JsonPropertyName("hidden")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden { get; set; }

        /// <summary>Whether the tab is highlighted. Works as an alias of active</summary>
        [JsonPropertyName("highlighted")]
        public bool Highlighted { get; set; }

        /// <summary>The ID of the tab. Tab IDs are unique within a browser session. Under some circumstances a Tab may not be assigned an ID, for example when querying foreign tabs using the $(ref:sessions) API, in which case a session ID may be present. Tab ID can also be set to $(ref:tabs.TAB_ID_NONE) for apps and devtools windows.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Id { get; set; }

        /// <summary>Whether the tab is in an incognito window.</summary>
        [JsonPropertyName("incognito")]
        public bool Incognito { get; set; }

        /// <summary>The zero-based index of the tab within its window.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>Whether the document in the tab can be rendered in reader mode.</summary>
        [JsonPropertyName("isArticle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsArticle { get; set; }

        /// <summary>Whether the document in the tab is being rendered in reader mode.</summary>
        [JsonPropertyName("isInReaderMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsInReaderMode { get; set; }

        /// <summary>The last time the tab was accessed as the number of milliseconds since epoch.</summary>
        [JsonPropertyName("lastAccessed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EpochTime? LastAccessed { get; set; }

        /// <summary>Current tab muted state and the reason for the last state change.</summary>
        [JsonPropertyName("mutedInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MutedInfo MutedInfo { get; set; }

        /// <summary>The ID of the tab that opened this tab, if any. This property is only present if the opener tab still exists.</summary>
        [JsonPropertyName("openerTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OpenerTabId { get; set; }

        /// <summary>Whether the tab is pinned.</summary>
        [JsonPropertyName("pinned")]
        public bool Pinned { get; set; }

        /// <summary>The session ID used to uniquely identify a Tab obtained from the $(ref:sessions) API.</summary>
        [JsonPropertyName("sessionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SessionId { get; set; }

        /// <summary>Current tab sharing state for screen, microphone and camera.</summary>
        [JsonPropertyName("sharingState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SharingState SharingState { get; set; }

        /// <summary>Either <em>loading</em> or <em>complete</em>.</summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Status { get; set; }

        /// <summary>The ID of this tab's successor, if any; $(ref:tabs.TAB_ID_NONE) otherwise.</summary>
        [JsonPropertyName("successorTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SuccessorTabId { get; set; }

        /// <summary>The title of the tab. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>The URL the tab is displaying. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }

        /// <summary>The width of the tab in pixels.</summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }

        /// <summary>The ID of the window the tab is contained within.</summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
