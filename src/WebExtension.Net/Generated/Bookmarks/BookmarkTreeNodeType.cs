using System.Text.Json.Serialization;

namespace WebExtension.Net.Bookmarks
{
    /// <summary>Indicates the type of a BookmarkTreeNode, which can be one of bookmark, folder or separator.</summary>
    [JsonConverter(typeof(EnumStringConverter<BookmarkTreeNodeType>))]
    public enum BookmarkTreeNodeType
    {
        /// <summary>bookmark</summary>
        [EnumValue("bookmark")]
        Bookmark,

        /// <summary>folder</summary>
        [EnumValue("folder")]
        Folder,

        /// <summary>separator</summary>
        [EnumValue("separator")]
        Separator,
    }
}
