using JsBind.Net;
using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Extension
{
    // Type Class
    /// <summary>Set for the lifetime of a callback if an ansychronous extension api has resulted in an error. If no error has occured lastError will be <c>undefined</c>.</summary>
    [BindAllProperties]
    [Obsolete("Please use $(ref:runtime.lastError).")]
    public partial class LastError : BaseObject
    {
        /// <summary>Description of the error that has taken place.</summary>
        [JsAccessPath("message")]
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }
    }
}
