using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TabGroups
{
    // Type Class
    /// <summary>State of a tab group inside of an open window.</summary>
    [BindAllProperties]
    public partial class TabGroup : BaseObject
    {
        /// <summary>Whether the tab group is collapsed or expanded in the tab strip.</summary>
        [JsAccessPath("collapsed")]
        [JsonPropertyName("collapsed")]
        public bool Collapsed { get; set; }

        /// <summary>User-selected color name for the tab group's label/icons.</summary>
        [JsAccessPath("color")]
        [JsonPropertyName("color")]
        public Color Color { get; set; }

        /// <summary>Unique ID of the tab group.</summary>
        [JsAccessPath("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>User-defined name of the tab group.</summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>Window that the tab group is in.</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        public int WindowId { get; set; }
    }
}
