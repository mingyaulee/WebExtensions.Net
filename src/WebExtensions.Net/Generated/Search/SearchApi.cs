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
        public virtual ValueTask Get()
        {
            return InvokeVoidAsync("get");
        }

        /// <inheritdoc />
        public virtual ValueTask Search(SearchProperties searchProperties)
        {
            return InvokeVoidAsync("search", searchProperties);
        }
    }
}
