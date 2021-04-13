using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    /// <summary></summary>
    public interface INotificationsApi
    {
        /// <summary>Creates and displays a notification.</summary>
        /// <param name="notificationId">Identifier of the notification. If it is empty, this method generates an id. If it matches an existing notification, this method first clears that notification before proceeding with the create operation.</param>
        /// <param name="options">Contents of the notification.</param>
        /// <returns>The notification id (either supplied or generated) that represents the created notification.</returns>
        ValueTask<string> Create(string notificationId, CreateNotificationOptions options);

        /// <summary>Clears an existing notification.</summary>
        /// <param name="notificationId">The id of the notification to be updated.</param>
        /// <returns>Indicates whether a matching notification existed.</returns>
        ValueTask<bool> Clear(string notificationId);

        /// <summary>Retrieves all the notifications.</summary>
        /// <returns>The set of notifications currently in the system.</returns>
        ValueTask<JsonElement> GetAll();
    }
}
