using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ContextualIdentities;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class OnUpdatedEventCallbackChangeInfo : BaseObject
{
    /// <summary>Contextual identity that has been updated</summary>
    [JsAccessPath("contextualIdentity")]
    [JsonPropertyName("contextualIdentity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ContextualIdentity ContextualIdentity { get; set; }
}
