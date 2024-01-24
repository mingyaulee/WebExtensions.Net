using WebExtensions.Net.Menus;

namespace WebExtensions.Net
{
    public partial class WebExtensionsApi
    {
        private IContextMenusApi _contextMenus;

        /// <inheritdoc />
        public IContextMenusApi ContextMenus => _contextMenus ??= new ContextMenusApi(JsRuntime, AccessPath);
    }
}
