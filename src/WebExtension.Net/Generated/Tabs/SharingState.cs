// This file is auto generated at 2021-03-24T04:51:22

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
    public class SharingState
    {
        
        // Property Definition
        /// <summary>
        /// If the tab is sharing the screen the value will be one of "Screen", "Window", or "Application", or undefined if not screen sharing.
        /// </summary>
        [JsonPropertyName("screen")]
        public string Screen { get; set; }
        
        // Property Definition
        /// <summary>
        /// True if the tab is using the camera.
        /// </summary>
        [JsonPropertyName("camera")]
        public bool Camera { get; set; }
        
        // Property Definition
        /// <summary>
        /// True if the tab is using the microphone.
        /// </summary>
        [JsonPropertyName("microphone")]
        public bool Microphone { get; set; }
    }
}

