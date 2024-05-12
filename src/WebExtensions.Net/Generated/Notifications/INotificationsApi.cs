using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Notifications
{
    /// <summary></summary>
    public partial interface INotificationsApi
    {
        /// <summary>Fired when the  user pressed a button in the notification.</summary>
        OnButtonClickedEvent OnButtonClicked { get; }

        /// <summary>Fired when the user clicked in a non-button area of the notification.</summary>
        OnClickedEvent OnClicked { get; }

        /// <summary>Fired when the notification closed, either by the system or by user action.</summary>
        OnClosedEvent OnClosed { get; }

        /// <summary>Fired when the notification is shown.</summary>
        OnShownEvent OnShown { get; }

        /// <summary>Clears an existing notification.</summary>
        /// <param name="notificationId">The id of the notification to be updated.</param>
        /// <returns>Indicates whether a matching notification existed.</returns>
        ValueTask<bool> Clear(string notificationId);

        /// <summary>Creates and displays a notification.</summary>
        /// <param name="options">Contents of the notification.</param>
        /// <returns>The notification id (either supplied or generated) that represents the created notification.</returns>
        ValueTask<string> Create(NotificationOptions options);

        /// <summary>Creates and displays a notification.</summary>
        /// <param name="notificationId">Identifier of the notification. If it is empty, this method generates an id. If it matches an existing notification, this method first clears that notification before proceeding with the create operation.</param>
        /// <param name="options">Contents of the notification.</param>
        /// <returns>The notification id (either supplied or generated) that represents the created notification.</returns>
        ValueTask<string> Create(string notificationId, NotificationOptions options);

        /// <summary>Retrieves all the notifications.</summary>
        /// <returns>The set of notifications currently in the system.</returns>
        ValueTask<JsonElement> GetAll();
    }
}
