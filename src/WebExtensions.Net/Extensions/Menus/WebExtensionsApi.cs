using WebExtensions.Net.Menus;

namespace WebExtensions.Net
{
    public partial class WebExtensionsApi
    {
        private IContextMenusApi _contextMenus;

        /// <inheritdoc />
        public IContextMenusApi ContextMenus
        {
            get
            {
                if (_contextMenus is null)
                {
                    _contextMenus = new ContextMenusApi(JsRuntime, AccessPath);
                }
                return _contextMenus;
            }
        }
    }
}
