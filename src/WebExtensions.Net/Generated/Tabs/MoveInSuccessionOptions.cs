using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class MoveInSuccessionOptions : BaseObject
{
    /// <summary>Whether to move the tabs before (false) or after (true) tabId in the succession. Defaults to false.</summary>
    [JsAccessPath("append")]
    [JsonPropertyName("append")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Append { get; set; }

    /// <summary>Whether to link up the current predecessors or successor (depending on options.append) of tabId to the other side of the chain after it is prepended or appended. If true, one of the following happens: if options.append is false, the first tab in the array is set as the successor of any current predecessors of tabId; if options.append is true, the current successor of tabId is set as the successor of the last tab in the array. Defaults to false.</summary>
    [JsAccessPath("insert")]
    [JsonPropertyName("insert")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Insert { get; set; }
}
