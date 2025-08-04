using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Configurations for creating a group. Cannot be used if groupId is already specified.</summary>
    [BindAllProperties]
    public partial class OptionsCreateProperties : BaseObject
    {
        /// <summary>The window of the new group. Defaults to the current window.</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
