using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.PageAction
{
    // Type Class
    /// <summary>Information sent when a page action is clicked.</summary>
    [BindAllProperties]
    public partial class OnClickData : BaseObject
    {
        /// <summary>An integer value of button by which menu item was clicked.</summary>
        [JsonPropertyName("button")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Button { get; set; }

        /// <summary>An array of keyboard modifiers that were held while the menu item was clicked.</summary>
        [JsonPropertyName("modifiers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Modifiers { get; set; }
    }
}
