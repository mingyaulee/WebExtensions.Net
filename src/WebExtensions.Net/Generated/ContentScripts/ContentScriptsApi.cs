using JsBind.Net;

namespace WebExtensions.Net.ContentScripts
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class ContentScriptsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "contentScripts")), IContentScriptsApi
    {
        /// <inheritdoc />
        public virtual void Register(RegisteredContentScriptOptions contentScriptOptions)
            => InvokeVoid("register", contentScriptOptions);
    }
}
