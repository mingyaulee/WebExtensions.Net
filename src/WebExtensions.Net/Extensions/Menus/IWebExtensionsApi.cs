using JsBind.Net;
using WebExtensions.Net.Menus;

namespace WebExtensions.Net;

public partial interface IWebExtensionsApi
{
    /// <summary>The part of the menus API that is available in all extension contexts, including content scripts. Use the browser.contextMenus API to add items to the browser's menus. You can choose what types of objects your context menu additions apply to, such as images, hyperlinks, and pages.<br />Requires manifest permission menus, menus.</summary>
    [JsAccessPath("contextMenus")]
    IContextMenusApi ContextMenus { get; }
}
