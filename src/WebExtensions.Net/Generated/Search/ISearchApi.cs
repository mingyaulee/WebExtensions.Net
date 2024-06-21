using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    /// <summary>Use browser.search to interact with search engines.</summary>
    [JsAccessPath("search")]
    public partial interface ISearchApi
    {
        /// <summary>Gets a list of search engines.</summary>
        [JsAccessPath("get")]
        ValueTask Get();

        /// <summary>Use the chrome.search API to search via the default provider.</summary>
        /// <param name="queryInfo"></param>
        [JsAccessPath("query")]
        ValueTask Query(QueryInfo queryInfo);

        /// <summary>Perform a search.</summary>
        /// <param name="searchProperties"></param>
        [JsAccessPath("search")]
        ValueTask Search(SearchProperties searchProperties);
    }
}
