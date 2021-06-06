using System.Text.Json.Serialization;

namespace WebExtension.Net.Bookmarks
{
    // Type Class
    /// <summary>Object passed to the create() function.</summary>
    public class CreateDetails : BaseObject
    {
        private int? _index;
        private string _parentId;
        private string _title;
        private BookmarkTreeNodeType? _type;
        private string _url;

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

        /// <summary>Defaults to the Other Bookmarks folder.</summary>
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

        /// <summary></summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>Indicates the type of BookmarkTreeNode to create, which can be one of bookmark, folder or separator.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BookmarkTreeNodeType? Type
        {
            get
            {
                InitializeProperty("type", _type);
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
