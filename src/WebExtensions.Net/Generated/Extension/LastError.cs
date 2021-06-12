using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Extension
{
    // Type Class
    /// <summary>Set for the lifetime of a callback if an ansychronous extension api has resulted in an error. If no error has occured lastError will be <c>undefined</c>.</summary>
    [Obsolete("Please use $(ref:runtime.lastError).")]
    public partial class LastError : BaseObject
    {
        private string _message;

        /// <summary>Description of the error that has taken place.</summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message
        {
            get
            {
                InitializeProperty("message", _message);
                return _message;
            }
            set
            {
                _message = value;
            }
        }
    }
}
