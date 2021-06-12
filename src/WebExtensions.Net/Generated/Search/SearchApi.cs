using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    /// <inheritdoc />
    public partial class SearchApi : BaseApi, ISearchApi
    {
        /// <summary>Creates a new instance of <see cref="SearchApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public SearchApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "search")
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
