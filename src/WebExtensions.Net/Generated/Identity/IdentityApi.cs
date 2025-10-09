using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Identity
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class IdentityApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "identity")), IIdentityApi
    {
        /// <inheritdoc />
        public virtual string GetRedirectURL(string path = null)
            => Invoke<string>("getRedirectURL", path);

        /// <inheritdoc />
        public virtual ValueTask<string> LaunchWebAuthFlow(LaunchWebAuthFlowDetails details)
            => InvokeAsync<string>("launchWebAuthFlow", details);
    }
}
