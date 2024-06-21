using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Windows
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Window : BaseObject
    {
        /// <summary>Whether the window is set to be always on top.</summary>
        [JsAccessPath("alwaysOnTop")]
        [JsonPropertyName("alwaysOnTop")]
        public bool AlwaysOnTop { get; set; }

        /// <summary>Whether the window is currently the focused window.</summary>
        [JsAccessPath("focused")]
        [JsonPropertyName("focused")]
        public bool Focused { get; set; }

        /// <summary>The height of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned height property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsAccessPath("height")]
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height { get; set; }

        /// <summary>The ID of the window. Window IDs are unique within a browser session. Under some circumstances a Window may not be assigned an ID, for example when querying windows using the $(ref:sessions) API, in which case a session ID may be present.</summary>
        [JsAccessPath("id")]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Id { get; set; }

        /// <summary>Whether the window is incognito.</summary>
        [JsAccessPath("incognito")]
        [JsonPropertyName("incognito")]
        public bool Incognito { get; set; }

        /// <summary>The offset of the window from the left edge of the screen in pixels. Under some circumstances a Window may not be assigned left property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsAccessPath("left")]
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Left { get; set; }

        /// <summary>The session ID used to uniquely identify a Window obtained from the $(ref:sessions) API.</summary>
        [JsAccessPath("sessionId")]
        [JsonPropertyName("sessionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SessionId { get; set; }

        /// <summary>The state of this browser window.</summary>
        [JsAccessPath("state")]
        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowState? State { get; set; }

        /// <summary>Array of $(ref:tabs.Tab) objects representing the current tabs in the window.</summary>
        [JsAccessPath("tabs")]
        [JsonPropertyName("tabs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Tab> Tabs { get; set; }

        /// <summary>The title of the window. Read-only.</summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>The offset of the window from the top edge of the screen in pixels. Under some circumstances a Window may not be assigned top property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsAccessPath("top")]
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Top { get; set; }

        /// <summary>The type of browser window this is.</summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowType? Type { get; set; }

        /// <summary>The width of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned width property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsAccessPath("width")]
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }
    }
}
