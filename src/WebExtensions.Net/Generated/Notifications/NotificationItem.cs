using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Notifications;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class NotificationItem : BaseObject
{
    /// <summary>Additional details about this item.</summary>
    [JsAccessPath("message")]
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Message { get; set; }

    /// <summary>Title of one item of a list notification.</summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }
}
