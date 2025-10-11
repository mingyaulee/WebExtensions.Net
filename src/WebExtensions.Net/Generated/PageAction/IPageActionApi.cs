using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.PageAction;

/// <summary>Use the <c>browser.pageAction</c> API to put icons inside the address bar. Page actions represent actions that can be taken on the current page, but that aren't applicable to all pages.</summary>
[JsAccessPath("pageAction")]
public partial interface IPageActionApi
{
    /// <summary>Fired when a page action icon is clicked.  This event will not fire if the page action has a popup.</summary>
    [JsAccessPath("onClicked")]
    OnClickedEvent OnClicked { get; }

    /// <summary>Gets the html document set as the popup for this page action.</summary>
    /// <param name="details"></param>
    /// <returns></returns>
    [JsAccessPath("getPopup")]
    ValueTask<string> GetPopup(GetPopupDetails details);

    /// <summary>Gets the title of the page action.</summary>
    /// <param name="details"></param>
    /// <returns></returns>
    [JsAccessPath("getTitle")]
    ValueTask<string> GetTitle(GetTitleDetails details);

    /// <summary>Hides the page action.</summary>
    /// <param name="tabId">The id of the tab for which you want to modify the page action.</param>
    [JsAccessPath("hide")]
    ValueTask Hide(int tabId);

    /// <summary>Checks whether the page action is shown.</summary>
    /// <param name="details"></param>
    [JsAccessPath("isShown")]
    void IsShown(IsShownDetails details);

    /// <summary>Opens the extension page action in the active window.</summary>
    [JsAccessPath("openPopup")]
    void OpenPopup();

    /// <summary>Sets the icon for the page action. The icon can be specified either as the path to an image file or as the pixel data from a canvas element, or as dictionary of either one of those. Either the 'b'path'/b' or the 'b'imageData'/b' property must be specified.</summary>
    /// <param name="details"></param>
    [JsAccessPath("setIcon")]
    ValueTask SetIcon(SetIconDetails details);

    /// <summary>Sets the html document to be opened as a popup when the user clicks on the page action's icon.</summary>
    /// <param name="details"></param>
    [JsAccessPath("setPopup")]
    void SetPopup(SetPopupDetails details);

    /// <summary>Sets the title of the page action. This is displayed in a tooltip over the page action.</summary>
    /// <param name="details"></param>
    [JsAccessPath("setTitle")]
    void SetTitle(SetTitleDetails details);

    /// <summary>Shows the page action. The page action is shown whenever the tab is selected.</summary>
    /// <param name="tabId">The id of the tab for which you want to modify the page action.</param>
    [JsAccessPath("show")]
    ValueTask Show(int tabId);
}
