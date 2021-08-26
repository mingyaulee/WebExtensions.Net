using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    public partial class SearchApi
    {
        /// <inheritdoc />
        public ValueTask Query(QueryInfo queryInfo)
        {
            return InvokeVoidAsync("query", queryInfo);
        }
    }
}
