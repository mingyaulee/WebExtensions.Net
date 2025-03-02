using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ContextualIdentities
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnCreatedEventCallbackChangeInfo : BaseObject
    {
        /// <summary>Contextual identity that has been created</summary>
        [JsAccessPath("contextualIdentity")]
        [JsonPropertyName("contextualIdentity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContextualIdentity ContextualIdentity { get; set; }
    }
}
