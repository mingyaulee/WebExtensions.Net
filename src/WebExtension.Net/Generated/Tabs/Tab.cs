/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// Class Definition
    /// <summary></summary>
    public class Tab
    {
        
        /// Property Definition
        /// <summary>The ID of the tab. Tab IDs are unique within a browser session. Under some circumstances a Tab may not be assigned an ID, for example when querying foreign tabs using the $(ref:sessions) API, in which case a session ID may be present. Tab ID can also be set to $(ref:tabs.TAB_ID_NONE) for apps and devtools windows.</summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        /// Property Definition
        /// <summary>The zero-based index of the tab within its window.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }
        
        /// Property Definition
        /// <summary>The ID of the window the tab is contained within.</summary>
        [JsonPropertyName("windowId")]
        public int? WindowId { get; set; }
        
        /// Property Definition
        /// <summary>The ID of the tab that opened this tab, if any. This property is only present if the opener tab still exists.</summary>
        [JsonPropertyName("openerTabId")]
        public int? OpenerTabId { get; set; }
        
        /// Property Definition
        /// <summary>Whether the tab is highlighted. Works as an alias of active</summary>
        [JsonPropertyName("highlighted")]
        public bool Highlighted { get; set; }
        
        /// Property Definition
        /// <summary>Whether the tab is active in its window. (Does not necessarily mean the window is focused.)</summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        
        /// Property Definition
        /// <summary>Whether the tab is pinned.</summary>
        [JsonPropertyName("pinned")]
        public bool Pinned { get; set; }
        
        /// Property Definition
        /// <summary>The last time the tab was accessed as the number of milliseconds since epoch.</summary>
        [JsonPropertyName("lastAccessed")]
        public int? LastAccessed { get; set; }
        
        /// Property Definition
        /// <summary>Whether the tab has produced sound over the past couple of seconds (but it might not be heard if also muted). Equivalent to whether the speaker audio indicator is showing.</summary>
        [JsonPropertyName("audible")]
        public bool? Audible { get; set; }
        
        /// Property Definition
        /// <summary>Current tab muted state and the reason for the last state change.</summary>
        [JsonPropertyName("mutedInfo")]
        public MutedInfo MutedInfo { get; set; }
        
        /// Property Definition
        /// <summary>The URL the tab is displaying. This property is only present if the extension's manifest includes the <code>"tabs"</code> permission.</summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        /// Property Definition
        /// <summary>The title of the tab. This property is only present if the extension's manifest includes the <code>"tabs"</code> permission.</summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        /// Property Definition
        /// <summary>The URL of the tab's favicon. This property is only present if the extension's manifest includes the <code>"tabs"</code> permission. It may also be an empty string if the tab is loading.</summary>
        [JsonPropertyName("favIconUrl")]
        public string FavIconUrl { get; set; }
        
        /// Property Definition
        /// <summary>Either <em>loading</em> or <em>complete</em>.</summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        /// Property Definition
        /// <summary>True while the tab is not loaded with content.</summary>
        [JsonPropertyName("discarded")]
        public bool? Discarded { get; set; }
        
        /// Property Definition
        /// <summary>Whether the tab is in an incognito window.</summary>
        [JsonPropertyName("incognito")]
        public bool Incognito { get; set; }
        
        /// Property Definition
        /// <summary>The width of the tab in pixels.</summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        
        /// Property Definition
        /// <summary>The height of the tab in pixels.</summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        
        /// Property Definition
        /// <summary>True if the tab is hidden.</summary>
        [JsonPropertyName("hidden")]
        public bool? Hidden { get; set; }
        
        /// Property Definition
        /// <summary>The session ID used to uniquely identify a Tab obtained from the $(ref:sessions) API.</summary>
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }
        
        /// Property Definition
        /// <summary>The CookieStoreId used for the tab.</summary>
        [JsonPropertyName("cookieStoreId")]
        public string CookieStoreId { get; set; }
        
        /// Property Definition
        /// <summary>Whether the document in the tab can be rendered in reader mode.</summary>
        [JsonPropertyName("isArticle")]
        public bool? IsArticle { get; set; }
        
        /// Property Definition
        /// <summary>Whether the document in the tab is being rendered in reader mode.</summary>
        [JsonPropertyName("isInReaderMode")]
        public bool? IsInReaderMode { get; set; }
        
        /// Property Definition
        /// <summary>Current tab sharing state for screen, microphone and camera.</summary>
        [JsonPropertyName("sharingState")]
        public SharingState SharingState { get; set; }
        
        /// Property Definition
        /// <summary>Whether the tab is drawing attention.</summary>
        [JsonPropertyName("attention")]
        public bool? Attention { get; set; }
        
        /// Property Definition
        /// <summary>The ID of this tab's successor, if any; $(ref:tabs.TAB_ID_NONE) otherwise.</summary>
        [JsonPropertyName("successorTabId")]
        public int? SuccessorTabId { get; set; }
    }
}

