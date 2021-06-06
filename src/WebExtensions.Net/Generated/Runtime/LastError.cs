using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>This will be defined during an API method callback if there was an error</summary>
    public class LastError : BaseObject
    {
        private string _message;

        /// <summary>Details about the error which occurred.</summary>
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
