using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.Windows
{
    // Type Class
    /// <summary></summary>
    public class Window : BaseObject
    {
        private bool _alwaysOnTop;
        private bool _focused;
        private int? _height;
        private int? _id;
        private bool _incognito;
        private int? _left;
        private string _sessionId;
        private WindowState? _state;
        private IEnumerable<Tab> _tabs;
        private string _title;
        private int? _top;
        private WindowType? _type;
        private int? _width;

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

        /// <summary>The height of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned height property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>The ID of the window. Window IDs are unique within a browser session. Under some circumstances a Window may not be assigned an ID, for example when querying windows using the $(ref:sessions) API, in which case a session ID may be present.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>The offset of the window from the left edge of the screen in pixels. Under some circumstances a Window may not be assigned left property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>The session ID used to uniquely identify a Window obtained from the $(ref:sessions) API.</summary>
        [JsonPropertyName("sessionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>The state of this browser window.</summary>
        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowState? State
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

        /// <summary>Array of $(ref:tabs.Tab) objects representing the current tabs in the window.</summary>
        [JsonPropertyName("tabs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Tab> Tabs
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

        /// <summary>The title of the window. Read-only.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>The offset of the window from the top edge of the screen in pixels. Under some circumstances a Window may not be assigned top property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>The type of browser window this is.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowType? Type
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

        /// <summary>The width of the window, including the frame, in pixels. Under some circumstances a Window may not be assigned width property, for example when querying closed windows from the $(ref:sessions) API.</summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
    }
}
