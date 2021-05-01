using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtension.Net.Bookmarks
{
    /// <inheritdoc />
    public class BookmarksApi : BaseApi, IBookmarksApi
    {
        /// <summary>Creates a new instance of <see cref="BookmarksApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public BookmarksApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "bookmarks")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<BookmarkTreeNode> Create(CreateDetails bookmark)
        {
            return InvokeAsync<BookmarkTreeNode>("create", bookmark);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Get(string idOrIdList)
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("get", idOrIdList);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Get(IEnumerable<string> idOrIdList)
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("get", idOrIdList);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetChildren(string id)
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("getChildren", id);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetRecent(int numberOfItems)
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("getRecent", numberOfItems);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetSubTree(string id)
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("getSubTree", id);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetTree()
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("getTree");
        }

        /// <inheritdoc />
        public virtual ValueTask<BookmarkTreeNode> Move(string id, object destination)
        {
            return InvokeAsync<BookmarkTreeNode>("move", id, destination);
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(string id)
        {
            return InvokeVoidAsync("remove", id);
        }

        /// <inheritdoc />
        public virtual ValueTask RemoveTree(string id)
        {
            return InvokeVoidAsync("removeTree", id);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Search(string query)
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("search", query);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Search(object query)
        {
            return InvokeAsync<IEnumerable<BookmarkTreeNode>>("search", query);
        }

        /// <inheritdoc />
        public virtual ValueTask<BookmarkTreeNode> Update(string id, object changes)
        {
            return InvokeAsync<BookmarkTreeNode>("update", id, changes);
        }
    }
}
