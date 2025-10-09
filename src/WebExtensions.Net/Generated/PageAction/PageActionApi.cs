using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.PageAction
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class PageActionApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "pageAction")), IPageActionApi
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
        public virtual ValueTask<string> GetPopup(GetPopupDetails details)
            => InvokeAsync<string>("getPopup", details);

        /// <inheritdoc />
        public virtual ValueTask<string> GetTitle(GetTitleDetails details)
            => InvokeAsync<string>("getTitle", details);

        /// <inheritdoc />
        public virtual ValueTask Hide(int tabId)
            => InvokeVoidAsync("hide", tabId);

        /// <inheritdoc />
        public virtual void IsShown(IsShownDetails details)
            => InvokeVoid("isShown", details);

        /// <inheritdoc />
        public virtual void OpenPopup()
            => InvokeVoid("openPopup");

        /// <inheritdoc />
        public virtual ValueTask SetIcon(SetIconDetails details)
            => InvokeVoidAsync("setIcon", details);

        /// <inheritdoc />
        public virtual void SetPopup(SetPopupDetails details)
            => InvokeVoid("setPopup", details);

        /// <inheritdoc />
        public virtual void SetTitle(SetTitleDetails details)
            => InvokeVoid("setTitle", details);

        /// <inheritdoc />
        public virtual ValueTask Show(int tabId)
            => InvokeVoidAsync("show", tabId);
    }
}
