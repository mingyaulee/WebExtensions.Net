using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class GroupOptions : BaseObject
{
    /// <summary>Configurations for creating a group. Cannot be used if groupId is already specified.</summary>
    [JsAccessPath("createProperties")]
    [JsonPropertyName("createProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OptionsCreateProperties CreateProperties { get; set; }

    /// <summary>The ID of the group to add the tabs to. If not specified, a new group will be created.</summary>
    [JsAccessPath("groupId")]
    [JsonPropertyName("groupId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? GroupId { get; set; }

    /// <summary>The tab ID or list of tab IDs to add to the specified group.</summary>
    [JsAccessPath("tabIds")]
    [JsonPropertyName("tabIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OptionsTabIds TabIds { get; set; }
}
