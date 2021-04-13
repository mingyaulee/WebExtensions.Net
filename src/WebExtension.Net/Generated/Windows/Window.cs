using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Windows
{
    // Type Class
    /// <summary></summary>
    public class Window : BaseObject
    {
        private int? _id;
        private bool _focused;
        private int? _top;
        private int? _left;
        private int? _width;
        private int? _height;
        private IEnumerable<Tabs.Tab> _tabs;
        private bool _incognito;
        private WindowType _type;
        private WindowState _state;
        private bool _alwaysOnTop;
        private string _sessionId;
        private string _title;

        /// <summary>The ID of the window. Window IDs are unique within a browser session. Under some circumstances a Window may not be assigned an ID, for example when querying windows using the $(ref:sessions) API, in which case a session ID may be present.</summary>
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

        /// <summary>Whether the window is currently the focused window.</summary>
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

        /// <summary>The offset of the window from the top edge of the screen in pixels. Under some circumstances a Window may not be assigned top property, for example when querying closed windows from the $(ref:sessions) API.</summary>
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

        /// <summary>The offset of the window from the left edge of the screen in pixels. Under some circumstances a Window may not be assigned left property, for example when querying closed windows from the $(ref:sessions) API.</summary>
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

        /// <summary>The width of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned width property, for example when querying closed windows from the $(ref:sessions) API.</summary>
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

        /// <summary>The height of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned height property, for example when querying closed windows from the $(ref:sessions) API.</summary>
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

        /// <summary>Array of $(ref:tabs.Tab) objects representing the current tabs in the window.</summary>
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

        /// <summary>Whether the window is incognito.</summary>
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

        /// <summary>The type of browser window this is.</summary>
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

        /// <summary>The state of this browser window.</summary>
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

        /// <summary>Whether the window is set to be always on top.</summary>
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

        /// <summary>The session ID used to uniquely identify a Window obtained from the $(ref:sessions) API.</summary>
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

        /// <summary>The title of the window. Read-only.</summary>
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
