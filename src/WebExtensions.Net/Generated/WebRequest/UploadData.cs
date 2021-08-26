using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Contains data uploaded in a URL request.</summary>
    [BindAllProperties]
    public partial class UploadData : BaseObject
    {
        /// <summary>An ArrayBuffer with a copy of the data.</summary>
        [JsonPropertyName("bytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Bytes { get; set; }

        /// <summary>A string with the file's path and name.</summary>
        [JsonPropertyName("file")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string File { get; set; }
    }
}
