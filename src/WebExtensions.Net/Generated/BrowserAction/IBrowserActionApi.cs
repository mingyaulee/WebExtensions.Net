using System.Threading.Tasks;

namespace WebExtensions.Net.BrowserAction
{
    /// <summary>Use browser actions to put icons in the main browser toolbar, to the right of the address bar. In addition to its icon, a browser action can also have a tooltip, a badge, and a popup.</summary>
    public partial interface IBrowserActionApi
    {
        /// <summary>Fired when a browser action icon is clicked.  This event will not fire if the browser action has a popup.</summary>
        OnClickedEvent OnClicked { get; }

        /// <summary>Disables the browser action for a tab.</summary>
        /// <param name="tabId">The id of the tab for which you want to modify the browser action.</param>
        ValueTask Disable(int? tabId = null);

        /// <summary>Enables the browser action for a tab. By default, browser actions are enabled.</summary>
        /// <param name="tabId">The id of the tab for which you want to modify the browser action.</param>
        ValueTask Enable(int? tabId = null);

        /// <summary>Gets the background color of the browser action badge.</summary>
        /// <param name="details"></param>
        /// <returns></returns>
        ValueTask<ColorArray> GetBadgeBackgroundColor(Details details);

        /// <summary>Gets the badge text of the browser action. If no tab nor window is specified is specified, the global badge text is returned.</summary>
        /// <param name="details"></param>
        /// <returns></returns>
        ValueTask<string> GetBadgeText(Details details);

        /// <summary>Gets the text color of the browser action badge.</summary>
        /// <param name="details"></param>
        ValueTask GetBadgeTextColor(Details details);

        /// <summary>Gets the html document set as the popup for this browser action.</summary>
        /// <param name="details"></param>
        /// <returns></returns>
        ValueTask<string> GetPopup(Details details);

        /// <summary>Gets the title of the browser action.</summary>
        /// <param name="details"></param>
        /// <returns></returns>
        ValueTask<string> GetTitle(Details details);

        /// <summary>Checks whether the browser action is enabled.</summary>
        /// <param name="details"></param>
        ValueTask IsEnabled(Details details);

        /// <summary>Opens the extension popup window in the active window.</summary>
        ValueTask OpenPopup();

        /// <summary>Sets the background color for the badge.</summary>
        /// <param name="details"></param>
        ValueTask SetBadgeBackgroundColor(SetBadgeBackgroundColorDetails details);

        /// <summary>Sets the badge text for the browser action. The badge is displayed on top of the icon.</summary>
        /// <param name="details"></param>
        ValueTask SetBadgeText(SetBadgeTextDetails details);

        /// <summary>Sets the text color for the badge.</summary>
        /// <param name="details"></param>
        ValueTask SetBadgeTextColor(SetBadgeTextColorDetails details);

        /// <summary>Sets the icon for the browser action. The icon can be specified either as the path to an image file or as the pixel data from a canvas element, or as dictionary of either one of those. Either the 'b'path'/b' or the 'b'imageData'/b' property must be specified.</summary>
        /// <param name="details"></param>
        ValueTask SetIcon(SetIconDetails details);

        /// <summary>Sets the html document to be opened as a popup when the user clicks on the browser action's icon.</summary>
        /// <param name="details"></param>
        ValueTask SetPopup(SetPopupDetails details);

        /// <summary>Sets the title of the browser action. This shows up in the tooltip.</summary>
        /// <param name="details"></param>
        ValueTask SetTitle(SetTitleDetails details);
    }
}
