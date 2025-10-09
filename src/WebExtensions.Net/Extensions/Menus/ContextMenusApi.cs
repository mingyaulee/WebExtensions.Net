using JsBind.Net;

namespace WebExtensions.Net.Menus
{
    /// <inheritdoc />
    public partial class ContextMenusApi : MenusApi, IContextMenusApi
    {
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ContextMenusApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, accessPath)
        {
            SetAccessPath(AccessPaths.Combine(accessPath, "contextMenus"));
        }
    }
}
