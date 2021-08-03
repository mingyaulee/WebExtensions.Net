using System.Threading.Tasks;

namespace WebExtensions.Net.Search
{
    public partial class SearchApi
    {
        public ValueTask Query(QueryInfo queryInfo)
        {
            return InvokeVoidAsync("query", queryInfo);
        }
    }
}
