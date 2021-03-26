using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Windows
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class Window : BaseObject
    {
        
        // Property Definition
        private int? _id;
        /// <summary>
        /// The ID of the window. Window IDs are unique within a browser session. Under some circumstances a Window may not be assigned an ID, for example when querying windows using the $(ref:sessions) API, in which case a session ID may be present.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        
        // Property Definition
        private bool _focused;
        /// <summary>
        /// Whether the window is currently the focused window.
        /// </summary>
        [JsonPropertyName("focused")]
        public bool Focused
        {
            get
            {
                InitializeProperty("focused", _focused);
                return _focused;
            }
            set
            {
                _focused = value;
            }
        }
        
        // Property Definition
        private int? _top;
        /// <summary>
        /// The offset of the window from the top edge of the screen in pixels. Under some circumstances a Window may not be assigned top property, for example when querying closed windows from the $(ref:sessions) API.
        /// </summary>
        [JsonPropertyName("top")]
        public int? Top
        {
            get
            {
                InitializeProperty("top", _top);
                return _top;
            }
            set
            {
                _top = value;
            }
        }
        
        // Property Definition
        private int? _left;
        /// <summary>
        /// The offset of the window from the left edge of the screen in pixels. Under some circumstances a Window may not be assigned left property, for example when querying closed windows from the $(ref:sessions) API.
        /// </summary>
        [JsonPropertyName("left")]
        public int? Left
        {
            get
            {
                InitializeProperty("left", _left);
                return _left;
            }
            set
            {
                _left = value;
            }
        }
        
        // Property Definition
        private int? _width;
        /// <summary>
        /// The width of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned width property, for example when querying closed windows from the $(ref:sessions) API.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width
        {
            get
            {
                InitializeProperty("width", _width);
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        
        // Property Definition
        private int? _height;
        /// <summary>
        /// The height of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned height property, for example when querying closed windows from the $(ref:sessions) API.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height
        {
            get
            {
                InitializeProperty("height", _height);
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        
        // Property Definition
        private IEnumerable<Tabs.Tab> _tabs;
        /// <summary>
        /// Array of $(ref:tabs.Tab) objects representing the current tabs in the window.
        /// </summary>
        [JsonPropertyName("tabs")]
        public IEnumerable<Tabs.Tab> Tabs
        {
            get
            {
                InitializeProperty("tabs", _tabs);
                return _tabs;
            }
            set
            {
                _tabs = value;
            }
        }
        
        // Property Definition
        private bool _incognito;
        /// <summary>
        /// Whether the window is incognito.
        /// </summary>
        [JsonPropertyName("incognito")]
        public bool Incognito
        {
            get
            {
                InitializeProperty("incognito", _incognito);
                return _incognito;
            }
            set
            {
                _incognito = value;
            }
        }
        
        // Property Definition
        private WindowType _type;
        /// <summary>
        /// The type of browser window this is.
        /// </summary>
        [JsonPropertyName("type")]
        public WindowType Type
        {
            get
            {
                InitializeProperty("type", _type);
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        
        // Property Definition
        private WindowState _state;
        /// <summary>
        /// The state of this browser window.
        /// </summary>
        [JsonPropertyName("state")]
        public WindowState State
        {
            get
            {
                InitializeProperty("state", _state);
                return _state;
            }
            set
            {
                _state = value;
            }
        }
        
        // Property Definition
        private bool _alwaysOnTop;
        /// <summary>
        /// Whether the window is set to be always on top.
        /// </summary>
        [JsonPropertyName("alwaysOnTop")]
        public bool AlwaysOnTop
        {
            get
            {
                InitializeProperty("alwaysOnTop", _alwaysOnTop);
                return _alwaysOnTop;
            }
            set
            {
                _alwaysOnTop = value;
            }
        }
        
        // Property Definition
        private string _sessionId;
        /// <summary>
        /// The session ID used to uniquely identify a Window obtained from the $(ref:sessions) API.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public string SessionId
        {
            get
            {
                InitializeProperty("sessionId", _sessionId);
                return _sessionId;
            }
            set
            {
                _sessionId = value;
            }
        }
        
        // Property Definition
        private string _title;
        /// <summary>
        /// The title of the window. Read-only.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }
    }
}

