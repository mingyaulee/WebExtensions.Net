// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// Represents a protocol handler definition.
    /// </summary>
    public class ProtocolHandler
    {
        
        // Property Definition
        /// <summary>
        /// A user-readable title string for the protocol handler. This will be displayed to the user in interface objects as needed.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        // Property Definition
        /// <summary>
        /// The protocol the site wishes to handle, specified as a string. For example, you can register to handle SMS text message links by registering to handle the "sms" scheme.
        /// </summary>
        [JsonPropertyName("protocol")]
        public object Protocol { get; set; }
        
        // Property Definition
        /// <summary>
        /// The URL of the handler, as a string. This string should include "%s" as a placeholder which will be replaced with the escaped URL of the document to be handled. This URL might be a true URL, or it could be a phone number, email address, or so forth.
        /// </summary>
        [JsonPropertyName("uriTemplate")]
        public object UriTemplate { get; set; }
    }
}

