using JsBind.Net;

namespace WebExtensions.Net.Dns
{
    /// <summary>Asynchronous DNS API</summary>
    [JsAccessPath("dns")]
    public partial interface IDnsApi
    {
        /// <summary>Resolves a hostname to a DNS record.</summary>
        /// <param name="hostname"></param>
        /// <param name="flags"></param>
        [JsAccessPath("resolve")]
        void Resolve(string hostname, ResolveFlags flags = null);
    }
}
