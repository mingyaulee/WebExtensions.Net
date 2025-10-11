using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActionNs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class SetBadgeTextColorDetails : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("color")]
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ColorValue Color { get; set; }
}
