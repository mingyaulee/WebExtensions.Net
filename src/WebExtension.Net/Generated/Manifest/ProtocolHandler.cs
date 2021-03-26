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
    public class ProtocolHandler : BaseObject
    {
        
        // Property Definition
        private string _name;
        /// <summary>
        /// A user-readable title string for the protocol handler. This will be displayed to the user in interface objects as needed.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        
        // Property Definition
        private object _protocol;
        /// <summary>
        /// The protocol the site wishes to handle, specified as a string. For example, you can register to handle SMS text message links by registering to handle the "sms" scheme.
        /// </summary>
        [JsonPropertyName("protocol")]
        public object Protocol
        {
            get
            {
                InitializeProperty("protocol", _protocol);
                return _protocol;
            }
            set
            {
                _protocol = value;
            }
        }
        
        // Property Definition
        private object _uriTemplate;
        /// <summary>
        /// The URL of the handler, as a string. This string should include "%s" as a placeholder which will be replaced with the escaped URL of the document to be handled. This URL might be a true URL, or it could be a phone number, email address, or so forth.
        /// </summary>
        [JsonPropertyName("uriTemplate")]
        public object UriTemplate
        {
            get
            {
                InitializeProperty("uriTemplate", _uriTemplate);
                return _uriTemplate;
            }
            set
            {
                _uriTemplate = value;
            }
        }
    }
}

