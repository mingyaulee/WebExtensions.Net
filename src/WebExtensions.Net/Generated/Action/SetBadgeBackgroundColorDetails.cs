using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Action
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class SetBadgeBackgroundColorDetails : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ColorValue Color { get; set; }
    }
}