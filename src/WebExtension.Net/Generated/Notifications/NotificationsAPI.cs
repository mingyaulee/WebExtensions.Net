/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    /// <summary></summary>
    public class NotificationsAPI : INotificationsAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        public NotificationsAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        /// Function Definition
        /// <summary>
        /// Creates and displays a notification.
        /// </summary>
        /// <param name="notificationId">Identifier of the notification. If it is empty, this method generates an id. If it matches an existing notification, this method first clears that notification before proceeding with the create operation.</param>
        /// <param name="options">Contents of the notification.</param>
        public virtual ValueTask<string> Create(string notificationId, CreateNotificationOptions options)
        {
            return webExtensionJSRuntime.InvokeAsync<string>("notifications.create", notificationId, options);
        }
        
        /// Function Definition
        /// <summary>
        /// Clears an existing notification.
        /// </summary>
        /// <param name="notificationId">The id of the notification to be updated.</param>
        public virtual ValueTask<bool> Clear(string notificationId)
        {
            return webExtensionJSRuntime.InvokeAsync<bool>("notifications.clear", notificationId);
        }
        
        /// Function Definition
        /// <summary>
        /// Retrieves all the notifications.
        /// </summary>
        public virtual ValueTask<JsonElement> GetAll()
        {
            return webExtensionJSRuntime.InvokeAsync<JsonElement>("notifications.getAll");
        }
    }
}
