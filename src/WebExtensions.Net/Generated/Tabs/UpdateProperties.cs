using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class UpdateProperties : BaseObject
    {
        /// <summary>Whether the tab should be active. Does not affect whether the window is focused (see $(ref:windows.update)).</summary>
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get; set; }

        /// <summary>Adds or removes the tab from the current selection.</summary>
        [JsonPropertyName("highlighted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Highlighted { get; set; }

        /// <summary>Whether the load should replace the current history entry for the tab.</summary>
        [JsonPropertyName("loadReplace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LoadReplace { get; set; }

        /// <summary>Whether the tab should be muted.</summary>
        [JsonPropertyName("muted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Muted { get; set; }

        /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as this tab.</summary>
        [JsonPropertyName("openerTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OpenerTabId { get; set; }

        /// <summary>Whether the tab should be pinned.</summary>
        [JsonPropertyName("pinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned { get; set; }

        /// <summary>The ID of this tab's successor. If specified, the successor tab must be in the same window as this tab.</summary>
        [JsonPropertyName("successorTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SuccessorTabId { get; set; }

        /// <summary>A URL to navigate the tab to.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
