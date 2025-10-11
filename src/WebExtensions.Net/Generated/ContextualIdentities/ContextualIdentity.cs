using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ContextualIdentities;

// Type Class
/// <summary>Represents information about a contextual identity.</summary>
[BindAllProperties]
public partial class ContextualIdentity : BaseObject
{
    /// <summary>The color name of the contextual identity.</summary>
    [JsAccessPath("color")]
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Color { get; set; }

    /// <summary>The color hash of the contextual identity.</summary>
    [JsAccessPath("colorCode")]
    [JsonPropertyName("colorCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ColorCode { get; set; }

    /// <summary>The cookie store ID of the contextual identity.</summary>
    [JsAccessPath("cookieStoreId")]
    [JsonPropertyName("cookieStoreId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string CookieStoreId { get; set; }

    /// <summary>The icon name of the contextual identity.</summary>
    [JsAccessPath("icon")]
    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Icon { get; set; }

    /// <summary>The icon url of the contextual identity.</summary>
    [JsAccessPath("iconUrl")]
    [JsonPropertyName("iconUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string IconUrl { get; set; }

    /// <summary>The name of the contextual identity.</summary>
    [JsAccessPath("name")]
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }
}
