using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary>Represents a protocol handler definition.</summary>
    public class ProtocolHandler : BaseObject
    {
        private string _name;
        private object _protocol;
        private object _uriTemplate;

        /// <summary>A user-readable title string for the protocol handler. This will be displayed to the user in interface objects as needed.</summary>
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

        /// <summary>The protocol the site wishes to handle, specified as a string. For example, you can register to handle SMS text message links by registering to handle the "sms" scheme.</summary>
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

        /// <summary>The URL of the handler, as a string. This string should include "%s" as a placeholder which will be replaced with the escaped URL of the document to be handled. This URL might be a true URL, or it could be a phone number, email address, or so forth.</summary>
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
