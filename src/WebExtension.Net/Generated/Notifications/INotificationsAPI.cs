/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    /// <summary></summary>
    public interface INotificationsAPI
    {
        
        /// Function Definition Interface
        /// <summary>
        /// Creates and displays a notification.
        /// </summary>
        /// <param name="notificationId">Identifier of the notification. If it is empty, this method generates an id. If it matches an existing notification, this method first clears that notification before proceeding with the create operation.</param>
        /// <param name="options">Contents of the notification.</param>
        ValueTask<string> Create(string notificationId, CreateNotificationOptions options);
        
        /// Function Definition Interface
        /// <summary>
        /// Clears an existing notification.
        /// </summary>
        /// <param name="notificationId">The id of the notification to be updated.</param>
        ValueTask<bool> Clear(string notificationId);
        
        /// Function Definition Interface
        /// <summary>
        /// Retrieves all the notifications.
        /// </summary>
        ValueTask<JsonElement> GetAll();
    }
}
