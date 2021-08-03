using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    /// <summary></summary>
    public partial interface ISearchApi
    {
        /// <summary>
        /// Used to query the default search provider in Chromium browsers. In case of an error, runtime.lastError will be set.
        /// </summary>
        /// <param name="queryInfo">Parameters for the query</param>
        /// <returns></returns>
        public ValueTask Query(QueryInfo queryInfo);
    }
}
