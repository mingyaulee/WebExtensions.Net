using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.ExtensionTypes
{
    // Type Class
    /// <summary></summary>
    public class ExtensionFile : BaseObject
    {
        private ExtensionUrl _file;

        /// <summary></summary>
        [JsonPropertyName("file")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExtensionUrl File
        {
            get
            {
                InitializeProperty("file", _file);
                return _file;
            }
            set
            {
                _file = value;
            }
        }
    }
}
