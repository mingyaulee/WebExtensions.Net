using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary></summary>
    public partial class Result : BaseObject
    {
        private ExtensionID _id;

        /// <summary></summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExtensionID Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}
