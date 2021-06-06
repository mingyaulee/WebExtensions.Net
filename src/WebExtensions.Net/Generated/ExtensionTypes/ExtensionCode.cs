using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes
{
    // Type Class
    /// <summary></summary>
    public class ExtensionCode : BaseObject
    {
        private string _code;

        /// <summary></summary>
        [JsonPropertyName("code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Code
        {
            get
            {
                InitializeProperty("code", _code);
                return _code;
            }
            set
            {
                _code = value;
            }
        }
    }
}
