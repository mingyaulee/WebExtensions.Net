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
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public NotificationsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "notifications")
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
                    InitializeProperty("onButtonClicked", _onButtonClicked);
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
                    InitializeProperty("onClicked", _onClicked);
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
                    InitializeProperty("onClosed", _onClosed);
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
                    InitializeProperty("onShown", _onShown);
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
        public virtual ValueTask<string> Create(string notificationId, CreateNotificationOptions options)
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
