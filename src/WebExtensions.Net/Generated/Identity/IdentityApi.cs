using System.Threading.Tasks;

namespace WebExtensions.Net.Identity
{
    /// <inheritdoc />
    public partial class IdentityApi : BaseApi, IIdentityApi
    {
        /// <summary>Creates a new instance of <see cref="IdentityApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public IdentityApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "identity")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetRedirectURL(string path)
        {
            return InvokeAsync<string>("getRedirectURL", path);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> LaunchWebAuthFlow(LaunchWebAuthFlowDetails details)
        {
            return InvokeAsync<string>("launchWebAuthFlow", details);
        }
    }
}
