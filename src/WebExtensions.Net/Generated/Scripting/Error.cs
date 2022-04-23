using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    // Type Class
    /// <summary>When the injection has failed, the error is exposed to the caller with this property.</summary>
    [BindAllProperties]
    public partial class Error : BaseObject
    {
        /// <summary>A message explaining why the injection has failed.</summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }
    }
}
