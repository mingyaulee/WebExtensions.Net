using System.Threading.Tasks;
using WebExtension.Net.Notifications;

namespace WebExtension.Net.Chrome
{
    /// <summary>
    /// Extensions for the Notifications Api
    /// </summary>
    public static class INotificationsApiExtensions
    {
        /// <summary>
        /// Updates a notification.
        /// </summary>
        /// <param name="notificationsApi">The notifications Api.</param>
        /// <param name="notificationId">Identifier of the notification.</param>
        /// <param name="options">Contents of the notification.</param>
        /// <returns>The notification id.</returns>
        public static ValueTask<bool> Update(this INotificationsApi notificationsApi, string notificationId, CreateNotificationOptions options)
        {
            return (notificationsApi as BaseApi).InvokeAsync<bool>("update", notificationId, options);
        }
    }
}
