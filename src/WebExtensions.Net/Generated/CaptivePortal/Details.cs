using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.CaptivePortal
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Details : BaseObject
    {
        /// <summary>The current captive portal state.</summary>
        [JsAccessPath("state")]
        [JsonPropertyName("state")]
        public State State { get; set; }
    }
}
