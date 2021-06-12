using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Only used as a response to the onAuthRequired event. If set, the request is made using the supplied credentials.</summary>
    public partial class AuthCredentials : BaseObject
    {
        private string _password;
        private string _username;

        /// <summary></summary>
        [JsonPropertyName("password")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Password
        {
            get
            {
                InitializeProperty("password", _password);
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("username")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Username
        {
            get
            {
                InitializeProperty("username", _username);
                return _username;
            }
            set
            {
                _username = value;
            }
        }
    }
}
