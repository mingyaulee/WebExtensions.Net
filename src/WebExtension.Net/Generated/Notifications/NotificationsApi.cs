using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    /// <inheritdoc />
    public class NotificationsApi : BaseApi, INotificationsApi
    {
        /// <summary>Creates a new instance of NotificationsApi.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public NotificationsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "notifications")
        {
        }

        
        
        
        // Function Definition
        /// <summary>
        /// Creates and displays a notification.
        /// </summary>
        /// <param name="notificationId">Identifier of the notification. If it is empty, this method generates an id. If it matches an existing notification, this method first clears that notification before proceeding with the create operation.</param>
        /// <param name="options">Contents of the notification.</param>
        /// <returns></returns>
        public virtual ValueTask<string> Create(string notificationId, CreateNotificationOptions options)
        {
            return InvokeAsync<string>("create", notificationId, options);
        }
        
        // Function Definition
        /// <summary>
        /// Clears an existing notification.
        /// </summary>
        /// <param name="notificationId">The id of the notification to be updated.</param>
        /// <returns></returns>
        public virtual ValueTask<bool> Clear(string notificationId)
        {
            return InvokeAsync<bool>("clear", notificationId);
        }
        
        // Function Definition
        /// <summary>
        /// Retrieves all the notifications.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> GetAll()
        {
            return InvokeAsync<JsonElement>("getAll");
        }
    }
}
