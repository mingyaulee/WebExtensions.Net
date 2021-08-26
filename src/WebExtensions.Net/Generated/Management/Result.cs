using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Result : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExtensionID Id { get; set; }
    }
}
