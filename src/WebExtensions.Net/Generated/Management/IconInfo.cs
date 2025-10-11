using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management;

// Type Class
/// <summary>Information about an icon belonging to an extension.</summary>
[BindAllProperties]
public partial class IconInfo : BaseObject
{
    /// <summary>A number representing the width and height of the icon. Likely values include (but are not limited to) 128, 48, 24, and 16.</summary>
    [JsAccessPath("size")]
    [JsonPropertyName("size")]
    public int Size { get; set; }

    /// <summary>The URL for this icon image. To display a grayscale version of the icon (to indicate that an extension is disabled, for example), append <c>?grayscale=true</c> to the URL.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
