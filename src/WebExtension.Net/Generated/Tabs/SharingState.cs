using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Class Definition
    /// <summary>
    /// Tab sharing state for screen, microphone and camera.
    /// </summary>
    public class SharingState : BaseObject
    {
        
        // Property Definition
        private string _screen;
        /// <summary>
        /// If the tab is sharing the screen the value will be one of "Screen", "Window", or "Application", or undefined if not screen sharing.
        /// </summary>
        [JsonPropertyName("screen")]
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
        
        // Property Definition
        private bool _camera;
        /// <summary>
        /// True if the tab is using the camera.
        /// </summary>
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
        
        // Property Definition
        private bool _microphone;
        /// <summary>
        /// True if the tab is using the microphone.
        /// </summary>
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
    }
}

