using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    /// <inheritdoc />
    public class NotificationsApi : BaseApi, INotificationsApi
    {
        /// <summary>Creates a new instance of <see cref="NotificationsApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public NotificationsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "notifications")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<string> Create(string notificationId, CreateNotificationOptions options)
        {
            return InvokeAsync<string>("create", notificationId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> Clear(string notificationId)
        {
            return InvokeAsync<bool>("clear", notificationId);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetAll()
        {
            return InvokeAsync<JsonElement>("getAll");
        }
    }
}
