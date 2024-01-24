using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    /// <summary>Use browser.search to interact with search engines.</summary>
    public partial interface ISearchApi
    {
        /// <summary>Gets a list of search engines.</summary>
        ValueTask Get();

        /// <summary>Use the chrome.search API to search via the default provider.</summary>
        /// <param name="queryInfo"></param>
        ValueTask Query(QueryInfo queryInfo);

        /// <summary>Perform a search.</summary>
        /// <param name="searchProperties"></param>
        ValueTask Search(SearchProperties searchProperties);
    }
}
