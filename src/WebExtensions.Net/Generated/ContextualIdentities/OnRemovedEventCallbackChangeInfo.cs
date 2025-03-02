using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ContextualIdentities
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnRemovedEventCallbackChangeInfo : BaseObject
    {
        /// <summary>Contextual identity that has been removed</summary>
        [JsAccessPath("contextualIdentity")]
        [JsonPropertyName("contextualIdentity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContextualIdentity ContextualIdentity { get; set; }
    }
}
