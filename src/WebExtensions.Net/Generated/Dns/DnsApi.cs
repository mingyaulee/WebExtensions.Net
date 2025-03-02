using JsBind.Net;

namespace WebExtensions.Net.Dns
{
    /// <inheritdoc />
    public partial class DnsApi : BaseApi, IDnsApi
    {
        /// <summary>Creates a new instance of <see cref="DnsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public DnsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "dns"))
        {
        }

        /// <inheritdoc />
        public virtual void Resolve(string hostname, ResolveFlags flags = null)
            => InvokeVoid("resolve", hostname, flags);
    }
}
