using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Tab sharing state for screen, microphone and camera.</summary>
    public partial class SharingState : BaseObject
    {
        private bool _camera;
        private bool _microphone;
        private string _screen;

        /// <summary>True if the tab is using the camera.</summary>
        [JsonPropertyName("camera")]
        public bool Camera
        {
            get
            {
                InitializeProperty("camera", _camera);
                return _camera;
            }
            set
            {
                _camera = value;
            }
        }

        /// <summary>True if the tab is using the microphone.</summary>
        [JsonPropertyName("microphone")]
        public bool Microphone
        {
            get
            {
                InitializeProperty("microphone", _microphone);
                return _microphone;
            }
            set
            {
                _microphone = value;
            }
        }

        /// <summary>If the tab is sharing the screen the value will be one of "Screen", "Window", or "Application", or undefined if not screen sharing.</summary>
        [JsonPropertyName("screen")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Screen
        {
            get
            {
                InitializeProperty("screen", _screen);
                return _screen;
            }
            set
            {
                _screen = value;
            }
        }
    }
}
