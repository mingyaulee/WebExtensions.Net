using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.TopSites;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class TopSitesApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "topSites")), ITopSitesApi
{
    /// <inheritdoc />
    public virtual ValueTask<IEnumerable<MostVisitedUrl>> Get(Options options = null)
        => InvokeAsync<IEnumerable<MostVisitedUrl>>("get", options);
}
