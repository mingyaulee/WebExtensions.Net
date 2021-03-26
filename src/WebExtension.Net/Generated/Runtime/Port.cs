using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Class Definition
    /// <summary>
    /// An object which allows two way communication with other pages.
    /// </summary>
    public class Port : BaseObject
    {
        
        // Property Definition
        private string _name;
        /// <summary>
        /// 
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
        private Action _disconnect;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private Events.Event _onDisconnect;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private Events.Event _onMessage;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private Action _postMessage;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private MessageSender _sender;
        /// <summary>
        /// This property will <b>only</b> be present on ports passed to onConnect/onConnectExternal listeners.
        /// </summary>
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

