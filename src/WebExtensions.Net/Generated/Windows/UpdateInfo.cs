using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows
{
    // Type Class
    /// <summary></summary>
    public partial class UpdateInfo : BaseObject
    {
        private bool? _drawAttention;
        private bool? _focused;
        private int? _height;
        private int? _left;
        private WindowState? _state;
        private string _titlePreface;
        private int? _top;
        private int? _width;

        /// <summary>If true, causes the window to be displayed in a manner that draws the user's attention to the window, without changing the focused window. The effect lasts until the user changes focus to the window. This option has no effect if the window already has focus. Set to false to cancel a previous draw attention request.</summary>
        [JsonPropertyName("drawAttention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DrawAttention
        {
            get
            {
                InitializeProperty("drawAttention", _drawAttention);
                return _drawAttention;
            }
            set
            {
                _drawAttention = value;
            }
        }

        /// <summary>If true, brings the window to the front. If false, brings the next window in the z-order to the front.</summary>
        [JsonPropertyName("focused")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Focused
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

        /// <summary>The height to resize the window to in pixels. This value is ignored for panels.</summary>
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

        /// <summary>The offset from the left edge of the screen to move the window to in pixels. This value is ignored for panels.</summary>
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

        /// <summary>The new state of the window. The 'minimized', 'maximized' and 'fullscreen' states cannot be combined with 'left', 'top', 'width' or 'height'.</summary>
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

        /// <summary>A string to add to the beginning of the window title.</summary>
        [JsonPropertyName("titlePreface")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TitlePreface
        {
            get
            {
                InitializeProperty("titlePreface", _titlePreface);
                return _titlePreface;
            }
            set
            {
                _titlePreface = value;
            }
        }

        /// <summary>The offset from the top edge of the screen to move the window to in pixels. This value is ignored for panels.</summary>
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

        /// <summary>The width to resize the window to in pixels. This value is ignored for panels.</summary>
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
