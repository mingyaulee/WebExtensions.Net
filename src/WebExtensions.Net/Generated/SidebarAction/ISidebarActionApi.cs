using JsBind.Net;

namespace WebExtensions.Net.SidebarAction
{
    /// <summary>Use sidebar actions to add a sidebar to Firefox.</summary>
    [JsAccessPath("sidebarAction")]
    public partial interface ISidebarActionApi
    {
        /// <summary>Closes the extension sidebar in the active window if the sidebar belongs to the extension.</summary>
        [JsAccessPath("close")]
        void Close();

        /// <summary>Gets the url to the html document set as the panel for this sidebar action.</summary>
        /// <param name="details"></param>
        [JsAccessPath("getPanel")]
        void GetPanel(GetPanelDetails details);

        /// <summary>Gets the title of the sidebar action.</summary>
        /// <param name="details"></param>
        [JsAccessPath("getTitle")]
        void GetTitle(GetTitleDetails details);

        /// <summary>Checks whether the sidebar action is open.</summary>
        /// <param name="details"></param>
        [JsAccessPath("isOpen")]
        void IsOpen(IsOpenDetails details);

        /// <summary>Opens the extension sidebar in the active window.</summary>
        [JsAccessPath("open")]
        void Open();

        /// <summary>Sets the icon for the sidebar action. The icon can be specified either as the path to an image file or as the pixel data from a canvas element, or as dictionary of either one of those. Either the 'strong'path'/strong' or the 'strong'imageData'/strong' property must be specified.</summary>
        /// <param name="details"></param>
        [JsAccessPath("setIcon")]
        void SetIcon(SetIconDetails details);

        /// <summary>Sets the url to the html document to be opened in the sidebar when the user clicks on the sidebar action's icon.</summary>
        /// <param name="details"></param>
        [JsAccessPath("setPanel")]
        void SetPanel(SetPanelDetails details);

        /// <summary>Sets the title of the sidebar action. This shows up in the tooltip.</summary>
        /// <param name="details"></param>
        [JsAccessPath("setTitle")]
        void SetTitle(SetTitleDetails details);

        /// <summary>Toggles the extension sidebar in the active window.</summary>
        [JsAccessPath("toggle")]
        void Toggle();
    }
}
