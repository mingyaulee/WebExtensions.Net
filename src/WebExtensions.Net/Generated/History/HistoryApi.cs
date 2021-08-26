using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.History
{
    /// <inheritdoc />
    public partial class HistoryApi : BaseApi, IHistoryApi
    {
        private OnTitleChangedEvent _onTitleChanged;
        private OnVisitedEvent _onVisited;
        private OnVisitRemovedEvent _onVisitRemoved;

        /// <summary>Creates a new instance of <see cref="HistoryApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public HistoryApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "history"))
        {
        }

        /// <inheritdoc />
        public OnTitleChangedEvent OnTitleChanged
        {
            get
            {
                if (_onTitleChanged is null)
                {
                    _onTitleChanged = new OnTitleChangedEvent();
                    _onTitleChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onTitleChanged"));
                }
                return _onTitleChanged;
            }
        }

        /// <inheritdoc />
        public OnVisitedEvent OnVisited
        {
            get
            {
                if (_onVisited is null)
                {
                    _onVisited = new OnVisitedEvent();
                    _onVisited.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onVisited"));
                }
                return _onVisited;
            }
        }

        /// <inheritdoc />
        public OnVisitRemovedEvent OnVisitRemoved
        {
            get
            {
                if (_onVisitRemoved is null)
                {
                    _onVisitRemoved = new OnVisitRemovedEvent();
                    _onVisitRemoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onVisitRemoved"));
                }
                return _onVisitRemoved;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask AddUrl(AddUrlDetails details)
        {
            return InvokeVoidAsync("addUrl", details);
        }

        /// <inheritdoc />
        public virtual ValueTask DeleteAll()
        {
            return InvokeVoidAsync("deleteAll");
        }

        /// <inheritdoc />
        public virtual ValueTask DeleteRange(Range range)
        {
            return InvokeVoidAsync("deleteRange", range);
        }

        /// <inheritdoc />
        public virtual ValueTask DeleteUrl(DeleteUrlDetails details)
        {
            return InvokeVoidAsync("deleteUrl", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<VisitItem>> GetVisits(GetVisitsDetails details)
        {
            return InvokeAsync<IEnumerable<VisitItem>>("getVisits", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<HistoryItem>> Search(Query query)
        {
            return InvokeAsync<IEnumerable<HistoryItem>>("search", query);
        }
    }
}
