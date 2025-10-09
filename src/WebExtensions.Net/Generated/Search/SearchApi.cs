using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class SearchApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "search")), ISearchApi
    {
        /// <inheritdoc />
        public virtual void Get()
            => InvokeVoid("get");

        /// <inheritdoc />
        public virtual ValueTask Query(QueryInfo queryInfo)
            => InvokeVoidAsync("query", queryInfo);

        /// <inheritdoc />
        public virtual void Search(SearchProperties searchProperties)
            => InvokeVoid("search", searchProperties);
    }
}
