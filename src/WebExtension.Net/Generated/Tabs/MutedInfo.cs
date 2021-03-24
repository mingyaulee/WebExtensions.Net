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
    /// Tab muted state and the reason for the last state change.
    /// </summary>
    public class MutedInfo
    {
        
        // Property Definition
        /// <summary>
        /// Whether the tab is prevented from playing sound (but hasn't necessarily recently produced sound). Equivalent to whether the muted audio indicator is showing.
        /// </summary>
        [JsonPropertyName("muted")]
        public bool Muted { get; set; }
        
        // Property Definition
        /// <summary>
        /// The reason the tab was muted or unmuted. Not set if the tab's mute state has never been changed.
        /// </summary>
        [JsonPropertyName("reason")]
        public MutedInfoReason Reason { get; set; }
        
        // Property Definition
        /// <summary>
        /// The ID of the extension that changed the muted state. Not set if an extension was not the reason the muted state last changed.
        /// </summary>
        [JsonPropertyName("extensionId")]
        public string ExtensionId { get; set; }
    }
}

