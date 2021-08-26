using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.ContentScripts
{
    /// <inheritdoc />
    public partial class ContentScriptsApi : BaseApi, IContentScriptsApi
    {
        /// <summary>Creates a new instance of <see cref="ContentScriptsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ContentScriptsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "contentScripts"))
        {
        }

        /// <inheritdoc />
        public virtual ValueTask Register(RegisteredContentScriptOptions contentScriptOptions)
        {
            return InvokeVoidAsync("register", contentScriptOptions);
        }
    }
}
