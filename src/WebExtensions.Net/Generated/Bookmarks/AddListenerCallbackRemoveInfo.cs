using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks
{
    // Type Class
    /// <summary></summary>
    public class AddListenerCallbackRemoveInfo : BaseObject
    {
        private int _index;
        private BookmarkTreeNode _node;
        private string _parentId;

        /// <summary></summary>
        [JsonPropertyName("index")]
        public int Index
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
        [JsonPropertyName("node")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BookmarkTreeNode Node
        {
            get
            {
                InitializeProperty("node", _node);
                return _node;
            }
            set
            {
                _node = value;
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
