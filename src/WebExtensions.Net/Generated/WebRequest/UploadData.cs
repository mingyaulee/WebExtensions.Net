using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>Contains data uploaded in a URL request.</summary>
    public partial class UploadData : BaseObject
    {
        private object _bytes;
        private string _file;

        /// <summary>An ArrayBuffer with a copy of the data.</summary>
        [JsonPropertyName("bytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Bytes
        {
            get
            {
                InitializeProperty("bytes", _bytes);
                return _bytes;
            }
            set
            {
                _bytes = value;
            }
        }

        /// <summary>A string with the file's path and name.</summary>
        [JsonPropertyName("file")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string File
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
