using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.BrowserAction
{
    /// <inheritdoc />
    public partial class BrowserActionApi : BaseApi, IBrowserActionApi
    {
        private OnClickedEvent _onClicked;

        /// <summary>Creates a new instance of <see cref="BrowserActionApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public BrowserActionApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "browserAction"))
        {
        }

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
        public virtual ValueTask Disable(int? tabId)
        {
            return InvokeVoidAsync("disable", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask Enable(int? tabId)
        {
            return InvokeVoidAsync("enable", tabId);
        }

        /// <inheritdoc />
        public virtual ValueTask<ColorArray> GetBadgeBackgroundColor(Details details)
        {
            return InvokeAsync<ColorArray>("getBadgeBackgroundColor", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetBadgeText(Details details)
        {
            return InvokeAsync<string>("getBadgeText", details);
        }

        /// <inheritdoc />
        public virtual ValueTask GetBadgeTextColor(Details details)
        {
            return InvokeVoidAsync("getBadgeTextColor", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetPopup(Details details)
        {
            return InvokeAsync<string>("getPopup", details);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetTitle(Details details)
        {
            return InvokeAsync<string>("getTitle", details);
        }

        /// <inheritdoc />
        public virtual ValueTask IsEnabled(Details details)
        {
            return InvokeVoidAsync("isEnabled", details);
        }

        /// <inheritdoc />
        public virtual ValueTask OpenPopup()
        {
            return InvokeVoidAsync("openPopup");
        }

        /// <inheritdoc />
        public virtual ValueTask SetBadgeBackgroundColor(SetBadgeBackgroundColorDetails details)
        {
            return InvokeVoidAsync("setBadgeBackgroundColor", details);
        }

        /// <inheritdoc />
        public virtual ValueTask SetBadgeText(SetBadgeTextDetails details)
        {
            return InvokeVoidAsync("setBadgeText", details);
        }

        /// <inheritdoc />
        public virtual ValueTask SetBadgeTextColor(SetBadgeTextColorDetails details)
        {
            return InvokeVoidAsync("setBadgeTextColor", details);
        }

        /// <inheritdoc />
        public virtual ValueTask SetIcon(SetIconDetails details)
        {
            return InvokeVoidAsync("setIcon", details);
        }

        /// <inheritdoc />
        public virtual ValueTask SetPopup(SetPopupDetails details)
        {
            return InvokeVoidAsync("setPopup", details);
        }

        /// <inheritdoc />
        public virtual ValueTask SetTitle(SetTitleDetails details)
        {
            return InvokeVoidAsync("setTitle", details);
        }
    }
}
