using System;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Runtime
{
    // Type Class
    /// <summary>An object which allows two way communication with other pages.</summary>
    public class Port : BaseObject
    {
        private string _name;
        private Action _disconnect;
        private Events.Event _onDisconnect;
        private Events.Event _onMessage;
        private Action _postMessage;
        private MessageSender _sender;

        /// <summary></summary>
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

        /// <summary></summary>
        [JsonPropertyName("disconnect")]
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
        [JsonPropertyName("onDisconnect")]
        public Events.Event OnDisconnect
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
        public Events.Event OnMessage
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
