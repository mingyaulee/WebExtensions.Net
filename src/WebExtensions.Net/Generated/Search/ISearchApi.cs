using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    /// <summary>Use browser.search to interact with search engines.</summary>
    public partial interface ISearchApi
    {
        /// <summary>Gets a list of search engines.</summary>
        ValueTask Get();

        /// <summary>Perform a search.</summary>
        /// <param name="searchProperties"></param>
        ValueTask Search(SearchProperties searchProperties);
    }
}
