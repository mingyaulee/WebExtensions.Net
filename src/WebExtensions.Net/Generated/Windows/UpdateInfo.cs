using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class UpdateInfo : BaseObject
    {
        /// <summary>If true, causes the window to be displayed in a manner that draws the user's attention to the window, without changing the focused window. The effect lasts until the user changes focus to the window. This option has no effect if the window already has focus. Set to false to cancel a previous draw attention request.</summary>
        [JsonPropertyName("drawAttention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DrawAttention { get; set; }

        /// <summary>If true, brings the window to the front. If false, brings the next window in the z-order to the front.</summary>
        [JsonPropertyName("focused")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Focused { get; set; }

        /// <summary>The height to resize the window to in pixels. This value is ignored for panels.</summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height { get; set; }

        /// <summary>The offset from the left edge of the screen to move the window to in pixels. This value is ignored for panels.</summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Left { get; set; }

        /// <summary>The new state of the window. The 'minimized', 'maximized' and 'fullscreen' states cannot be combined with 'left', 'top', 'width' or 'height'.</summary>
        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowState? State { get; set; }

        /// <summary>A string to add to the beginning of the window title.</summary>
        [JsonPropertyName("titlePreface")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TitlePreface { get; set; }

        /// <summary>The offset from the top edge of the screen to move the window to in pixels. This value is ignored for panels.</summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Top { get; set; }

        /// <summary>The width to resize the window to in pixels. This value is ignored for panels.</summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }
    }
}
