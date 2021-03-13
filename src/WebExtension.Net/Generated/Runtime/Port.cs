/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    /// Class Definition
    /// <summary>An object which allows two way communication with other pages.</summary>
    public class Port
    {
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("disconnect")]
        public Action Disconnect { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("onDisconnect")]
        public Events.Event OnDisconnect { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("onMessage")]
        public Events.Event OnMessage { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("postMessage")]
        public Action PostMessage { get; set; }
        
        /// Property Definition
        /// <summary>This property will <b>only</b> be present on ports passed to onConnect/onConnectExternal listeners.</summary>
        [JsonPropertyName("sender")]
        public MessageSender Sender { get; set; }
    }
}

