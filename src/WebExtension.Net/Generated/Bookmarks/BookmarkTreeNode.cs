using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Bookmarks
{
    // Type Class
    /// <summary>A node (either a bookmark or a folder) in the bookmark tree.  Child nodes are ordered within their parent folder.</summary>
    public class BookmarkTreeNode : BaseObject
    {
        private IEnumerable<BookmarkTreeNode> _children;
        private double? _dateAdded;
        private double? _dateGroupModified;
        private string _id;
        private int? _index;
        private string _parentId;
        private string _title;
        private BookmarkTreeNodeType _type;
        private BookmarkTreeNodeUnmodifiable _unmodifiable;
        private string _url;

        /// <summary>An ordered list of children of this node.</summary>
        [JsonPropertyName("children")]
        public IEnumerable<BookmarkTreeNode> Children
        {
            get
            {
                InitializeProperty("children", _children);
                return _children;
            }
            set
            {
                _children = value;
            }
        }

        /// <summary>When this node was created, in milliseconds since the epoch (<c>new Date(dateAdded)</c>).</summary>
        [JsonPropertyName("dateAdded")]
        public double? DateAdded
        {
            get
            {
                InitializeProperty("dateAdded", _dateAdded);
                return _dateAdded;
            }
            set
            {
                _dateAdded = value;
            }
        }

        /// <summary>When the contents of this folder last changed, in milliseconds since the epoch.</summary>
        [JsonPropertyName("dateGroupModified")]
        public double? DateGroupModified
        {
            get
            {
                InitializeProperty("dateGroupModified", _dateGroupModified);
                return _dateGroupModified;
            }
            set
            {
                _dateGroupModified = value;
            }
        }

        /// <summary>The unique identifier for the node. IDs are unique within the current profile, and they remain valid even after the browser is restarted.</summary>
        [JsonPropertyName("id")]
        public string Id
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

        /// <summary>The 0-based position of this node within its parent folder.</summary>
        [JsonPropertyName("index")]
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

        /// <summary>The <c>id</c> of the parent folder.  Omitted for the root node.</summary>
        [JsonPropertyName("parentId")]
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

        /// <summary>The text displayed for the node.</summary>
        [JsonPropertyName("title")]
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

        /// <summary>Indicates the type of the BookmarkTreeNode, which can be one of bookmark, folder or separator.</summary>
        [JsonPropertyName("type")]
        public BookmarkTreeNodeType Type
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

        /// <summary>Indicates the reason why this node is unmodifiable. The <c>managed</c> value indicates that this node was configured by the system administrator or by the custodian of a supervised user. Omitted if the node can be modified by the user and the extension (default).</summary>
        [JsonPropertyName("unmodifiable")]
        public BookmarkTreeNodeUnmodifiable Unmodifiable
        {
            get
            {
                InitializeProperty("unmodifiable", _unmodifiable);
                return _unmodifiable;
            }
            set
            {
                _unmodifiable = value;
            }
        }

        /// <summary>The URL navigated to when a user clicks the bookmark. Omitted for folders.</summary>
        [JsonPropertyName("url")]
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
