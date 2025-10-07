using JsBind.Net;

namespace WebExtensions.Net.Menus
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class ContextMenusApi(IJsRuntimeAdapter jsRuntime, string accessPath) : MenusApi(jsRuntime, accessPath, "contextMenus"), IContextMenusApi
    {
    }
}
