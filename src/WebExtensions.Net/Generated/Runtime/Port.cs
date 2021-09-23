using JsBind.Net;
using System;
using System.Text.Json.Serialization;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>An object which allows two way communication with other pages.</summary>
    [BindAllProperties]
    public partial class Port : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("disconnect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action<object> Disconnect { get; set; }

        /// <summary></summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary></summary>
        [JsonPropertyName("onDisconnect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Event OnDisconnect { get; set; }

        /// <summary></summary>
        [JsonPropertyName("onMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OnMessageEvent OnMessage { get; set; }

        /// <summary></summary>
        [JsonPropertyName("postMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action<object> PostMessage { get; set; }

        /// <summary>This property will 'b'only'/b' be present on ports passed to onConnect/onConnectExternal listeners.</summary>
        [JsonPropertyName("sender")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MessageSender Sender { get; set; }
    }
}
