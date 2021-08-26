using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Tab sharing state for screen, microphone and camera.</summary>
    [BindAllProperties]
    public partial class SharingState : BaseObject
    {
        /// <summary>True if the tab is using the camera.</summary>
        [JsonPropertyName("camera")]
        public bool Camera { get; set; }

        /// <summary>True if the tab is using the microphone.</summary>
        [JsonPropertyName("microphone")]
        public bool Microphone { get; set; }

        /// <summary>If the tab is sharing the screen the value will be one of "Screen", "Window", or "Application", or undefined if not screen sharing.</summary>
        [JsonPropertyName("screen")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Screen { get; set; }
    }
}
