/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    /// Class Definition
    /// <summary></summary>
    public class Window
    {
        
        /// Property Definition
        /// <summary>The ID of the window. Window IDs are unique within a browser session. Under some circumstances a Window may not be assigned an ID, for example when querying windows using the $(ref:sessions) API, in which case a session ID may be present.</summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        /// Property Definition
        /// <summary>Whether the window is currently the focused window.</summary>
        [JsonPropertyName("focused")]
        public bool Focused { get; set; }
        
        /// Property Definition
        /// <summary>The offset of the window from the top edge of the screen in pixels. Under some circumstances a Window may not be assigned top property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("top")]
        public int? Top { get; set; }
        
        /// Property Definition
        /// <summary>The offset of the window from the left edge of the screen in pixels. Under some circumstances a Window may not be assigned left property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("left")]
        public int? Left { get; set; }
        
        /// Property Definition
        /// <summary>The width of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned width property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        
        /// Property Definition
        /// <summary>The height of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned height property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        
        /// Property Definition
        /// <summary>Array of $(ref:tabs.Tab) objects representing the current tabs in the window.</summary>
        [JsonPropertyName("tabs")]
        public IEnumerable<Tabs.Tab> Tabs { get; set; }
        
        /// Property Definition
        /// <summary>Whether the window is incognito.</summary>
        [JsonPropertyName("incognito")]
        public bool Incognito { get; set; }
        
        /// Property Definition
        /// <summary>The type of browser window this is.</summary>
        [JsonPropertyName("type")]
        public WindowType Type { get; set; }
        
        /// Property Definition
        /// <summary>The state of this browser window.</summary>
        [JsonPropertyName("state")]
        public WindowState State { get; set; }
        
        /// Property Definition
        /// <summary>Whether the window is set to be always on top.</summary>
        [JsonPropertyName("alwaysOnTop")]
        public bool AlwaysOnTop { get; set; }
        
        /// Property Definition
        /// <summary>The session ID used to uniquely identify a Window obtained from the $(ref:sessions) API.</summary>
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }
        
        /// Property Definition
        /// <summary>The title of the window. Read-only.</summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}

