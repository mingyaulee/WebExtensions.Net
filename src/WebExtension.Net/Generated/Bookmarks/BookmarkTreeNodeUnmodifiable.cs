using System.Text.Json.Serialization;

namespace WebExtension.Net.Bookmarks
{
    /// <summary>Indicates the reason why this node is unmodifiable. The <c>managed</c> value indicates that this node was configured by the system administrator or by the custodian of a supervised user. Omitted if the node can be modified by the user and the extension (default).</summary>
    [JsonConverter(typeof(EnumStringConverter<BookmarkTreeNodeUnmodifiable>))]
    public enum BookmarkTreeNodeUnmodifiable
    {
        /// <summary>managed</summary>
        [EnumValue("managed")]
        Managed,
    }
}
