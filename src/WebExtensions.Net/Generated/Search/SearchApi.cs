using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    /// <inheritdoc />
    public partial class SearchApi : BaseApi, ISearchApi
    {
        /// <summary>Creates a new instance of <see cref="SearchApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public SearchApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "search"))
        {
        }

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
