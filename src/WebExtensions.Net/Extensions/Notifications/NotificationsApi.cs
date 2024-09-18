using System.Threading.Tasks;

namespace WebExtensions.Net.Notifications
{
    public partial class NotificationsApi
    {
        /// <inheritdoc />
        public ValueTask<bool> Update(string notificationId, NotificationOptions options)
            => InvokeAsync<bool>("update", notificationId, options);
    }
}
