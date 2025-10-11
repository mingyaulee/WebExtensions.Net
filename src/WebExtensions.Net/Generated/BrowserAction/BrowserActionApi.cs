using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.BrowserAction;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class BrowserActionApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "browserAction")), IBrowserActionApi
{
    private OnClickedEvent _onClicked;

    /// <inheritdoc />
    public OnClickedEvent OnClicked
    {
        get
        {
            if (_onClicked is null)
            {
                _onClicked = new OnClickedEvent();
                _onClicked.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onClicked"));
            }
            return _onClicked;
        }
    }

    /// <inheritdoc />
    public virtual ValueTask Disable(int? tabId = null)
        => InvokeVoidAsync("disable", tabId);

    /// <inheritdoc />
    public virtual ValueTask Enable(int? tabId = null)
        => InvokeVoidAsync("enable", tabId);

    /// <inheritdoc />
    public virtual ValueTask<ColorArray> GetBadgeBackgroundColor(Details details)
        => InvokeAsync<ColorArray>("getBadgeBackgroundColor", details);

    /// <inheritdoc />
    public virtual ValueTask<string> GetBadgeText(Details details)
        => InvokeAsync<string>("getBadgeText", details);

    /// <inheritdoc />
    public virtual void GetBadgeTextColor(Details details)
        => InvokeVoid("getBadgeTextColor", details);

    /// <inheritdoc />
    public virtual ValueTask<string> GetPopup(Details details)
        => InvokeAsync<string>("getPopup", details);

    /// <inheritdoc />
    public virtual ValueTask<string> GetTitle(Details details)
        => InvokeAsync<string>("getTitle", details);

    /// <inheritdoc />
    public virtual void IsEnabled(Details details)
        => InvokeVoid("isEnabled", details);

    /// <inheritdoc />
    public virtual void OpenPopup()
        => InvokeVoid("openPopup");

    /// <inheritdoc />
    public virtual ValueTask SetBadgeBackgroundColor(SetBadgeBackgroundColorDetails details)
        => InvokeVoidAsync("setBadgeBackgroundColor", details);

    /// <inheritdoc />
    public virtual ValueTask SetBadgeText(SetBadgeTextDetails details)
        => InvokeVoidAsync("setBadgeText", details);

    /// <inheritdoc />
    public virtual void SetBadgeTextColor(SetBadgeTextColorDetails details)
        => InvokeVoid("setBadgeTextColor", details);

    /// <inheritdoc />
    public virtual ValueTask SetIcon(SetIconDetails details)
        => InvokeVoidAsync("setIcon", details);

    /// <inheritdoc />
    public virtual ValueTask SetPopup(SetPopupDetails details)
        => InvokeVoidAsync("setPopup", details);

    /// <inheritdoc />
    public virtual ValueTask SetTitle(SetTitleDetails details)
        => InvokeVoidAsync("setTitle", details);
}
