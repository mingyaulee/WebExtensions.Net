using JsBind.Net;

namespace WebExtensions.Net.Dns;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class DnsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "dns")), IDnsApi
{
    /// <inheritdoc />
    public virtual void Resolve(string hostname, ResolveFlags flags = null)
        => InvokeVoid("resolve", hostname, flags);
}
