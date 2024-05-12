using JsBind.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Notifications
{
    /// <inheritdoc />
    public partial class NotificationsApi : BaseApi, INotificationsApi
    {
        private OnButtonClickedEvent _onButtonClicked;
        private OnClickedEvent _onClicked;
        private OnClosedEvent _onClosed;
        private OnShownEvent _onShown;

        /// <summary>Creates a new instance of <see cref="NotificationsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public NotificationsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "notifications"))
        {
        }

        /// <inheritdoc />
        public OnButtonClickedEvent OnButtonClicked
        {
            get
            {
                if (_onButtonClicked is null)
                {
                    _onButtonClicked = new OnButtonClickedEvent();
                    _onButtonClicked.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onButtonClicked"));
                }
                return _onButtonClicked;
            }
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
        public OnClosedEvent OnClosed
        {
            get
            {
                if (_onClosed is null)
                {
                    _onClosed = new OnClosedEvent();
                    _onClosed.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onClosed"));
                }
                return _onClosed;
            }
        }

        /// <inheritdoc />
        public OnShownEvent OnShown
        {
            get
            {
                if (_onShown is null)
                {
                    _onShown = new OnShownEvent();
                    _onShown.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onShown"));
                }
                return _onShown;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> Clear(string notificationId)
        {
            return InvokeAsync<bool>("clear", notificationId);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> Create(NotificationOptions options)
        {
            return InvokeAsync<string>("create", options);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> Create(string notificationId, NotificationOptions options)
        {
            return InvokeAsync<string>("create", notificationId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetAll()
        {
            return InvokeAsync<JsonElement>("getAll");
        }
    }
}
