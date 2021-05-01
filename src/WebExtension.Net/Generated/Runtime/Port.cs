using System;
using System.Text.Json.Serialization;
using WebExtension.Net.Events;

namespace WebExtension.Net.Runtime
{
    // Type Class
    /// <summary>An object which allows two way communication with other pages.</summary>
    public class Port : BaseObject
    {
        private Action _disconnect;
        private string _name;
        private Event _onDisconnect;
        private Event _onMessage;
        private Action _postMessage;
        private MessageSender _sender;

        /// <summary></summary>
        [JsonPropertyName("disconnect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action Disconnect
        {
            get
            {
                InitializeProperty("disconnect", _disconnect);
                return _disconnect;
            }
            set
            {
                _disconnect = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary></summary>
        [JsonPropertyName("onDisconnect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Event OnDisconnect
        {
            get
            {
                InitializeProperty("onDisconnect", _onDisconnect);
                return _onDisconnect;
            }
            set
            {
                _onDisconnect = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("onMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Event OnMessage
        {
            get
            {
                InitializeProperty("onMessage", _onMessage);
                return _onMessage;
            }
            set
            {
                _onMessage = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("postMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action PostMessage
        {
            get
            {
                InitializeProperty("postMessage", _postMessage);
                return _postMessage;
            }
            set
            {
                _postMessage = value;
            }
        }

        /// <summary>This property will 'b'only'/b' be present on ports passed to onConnect/onConnectExternal listeners.</summary>
        [JsonPropertyName("sender")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MessageSender Sender
        {
            get
            {
                InitializeProperty("sender", _sender);
                return _sender;
            }
            set
            {
                _sender = value;
            }
        }
    }
}
