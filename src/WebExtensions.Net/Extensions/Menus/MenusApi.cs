using JsBind.Net;

namespace WebExtensions.Net.Menus
{
    public partial class MenusApi
    {
        /// <summary>Creates a new instance of <see cref="MenusApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        /// <param name="proxyNamespace">The proxy namespace.</param>
        protected MenusApi(IJsRuntimeAdapter jsRuntime, string accessPath, string proxyNamespace) : base(jsRuntime, AccessPaths.Combine(accessPath, proxyNamespace))
        {
        }
    }
}
