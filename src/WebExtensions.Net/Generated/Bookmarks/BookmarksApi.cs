using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Bookmarks
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class BookmarksApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "bookmarks")), IBookmarksApi
    {
        private OnChangedEvent _onChanged;
        private OnCreatedEvent _onCreated;
        private OnMovedEvent _onMoved;
        private OnRemovedEvent _onRemoved;

        /// <inheritdoc />
        public OnChangedEvent OnChanged
        {
            get
            {
                if (_onChanged is null)
                {
                    _onChanged = new OnChangedEvent();
                    _onChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onChanged"));
                }
                return _onChanged;
            }
        }

        /// <inheritdoc />
        public OnCreatedEvent OnCreated
        {
            get
            {
                if (_onCreated is null)
                {
                    _onCreated = new OnCreatedEvent();
                    _onCreated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCreated"));
                }
                return _onCreated;
            }
        }

        /// <inheritdoc />
        public OnMovedEvent OnMoved
        {
            get
            {
                if (_onMoved is null)
                {
                    _onMoved = new OnMovedEvent();
                    _onMoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onMoved"));
                }
                return _onMoved;
            }
        }

        /// <inheritdoc />
        public OnRemovedEvent OnRemoved
        {
            get
            {
                if (_onRemoved is null)
                {
                    _onRemoved = new OnRemovedEvent();
                    _onRemoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRemoved"));
                }
                return _onRemoved;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<BookmarkTreeNode> Create(CreateDetails bookmark)
            => InvokeAsync<BookmarkTreeNode>("create", bookmark);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Get(string idOrIdList)
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("get", idOrIdList);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Get(IEnumerable<string> idOrIdList)
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("get", idOrIdList);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetChildren(string id)
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("getChildren", id);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetRecent(int numberOfItems)
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("getRecent", numberOfItems);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetSubTree(string id)
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("getSubTree", id);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> GetTree()
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("getTree");

        /// <inheritdoc />
        public virtual ValueTask<BookmarkTreeNode> Move(string id, Destination destination)
            => InvokeAsync<BookmarkTreeNode>("move", id, destination);

        /// <inheritdoc />
        public virtual ValueTask Remove(string id)
            => InvokeVoidAsync("remove", id);

        /// <inheritdoc />
        public virtual ValueTask RemoveTree(string id)
            => InvokeVoidAsync("removeTree", id);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Search(string query)
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("search", query);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<BookmarkTreeNode>> Search(object query)
            => InvokeAsync<IEnumerable<BookmarkTreeNode>>("search", query);

        /// <inheritdoc />
        public virtual ValueTask<BookmarkTreeNode> Update(string id, Changes changes)
            => InvokeAsync<BookmarkTreeNode>("update", id, changes);
    }
}
