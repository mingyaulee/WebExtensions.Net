using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.TopSites
{
    /// <inheritdoc />
    public partial class TopSitesApi : BaseApi, ITopSitesApi
    {
        /// <summary>Creates a new instance of <see cref="TopSitesApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public TopSitesApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "topSites")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<MostVisitedURL>> Get(Options options)
        {
            return InvokeAsync<IEnumerable<MostVisitedURL>>("get", options);
        }
    }
}
