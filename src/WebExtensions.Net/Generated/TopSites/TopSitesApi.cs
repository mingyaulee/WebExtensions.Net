using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.TopSites
{
    /// <inheritdoc />
    public partial class TopSitesApi : BaseApi, ITopSitesApi
    {
        /// <summary>Creates a new instance of <see cref="TopSitesApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public TopSitesApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "topSites"))
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<MostVisitedUrl>> Get(Options options)
        {
            return InvokeAsync<IEnumerable<MostVisitedUrl>>("get", options);
        }
    }
}
