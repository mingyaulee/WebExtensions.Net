using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks
{
    // Type Class
    /// <summary></summary>
    public class Destination : BaseObject
    {
        private int? _index;
        private string _parentId;

        /// <summary></summary>
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index
        {
            get
            {
                InitializeProperty("index", _index);
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ParentId
        {
            get
            {
                InitializeProperty("parentId", _parentId);
                return _parentId;
            }
            set
            {
                _parentId = value;
            }
        }
    }
}
