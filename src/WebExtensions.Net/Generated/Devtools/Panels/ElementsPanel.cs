using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.Panels
{
    // Type Class
    /// <summary>Represents the Elements panel.</summary>
    [BindAllProperties]
    public partial class ElementsPanel : BaseObject
    {
        /// <summary>Creates a pane within panel's sidebar.</summary>
        /// <param name="title">Text that is displayed in sidebar caption.</param>
        /// <returns>An ExtensionSidebarPane object for created sidebar pane.</returns>
        [JsAccessPath("createSidebarPane")]
        public virtual ValueTask<ExtensionSidebarPane> CreateSidebarPane(string title)
        {
            return InvokeAsync<ExtensionSidebarPane>("createSidebarPane", title);
        }
    }
}
