// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class CreateNotificationOptions
    {
        
        // Property Definition
        /// <summary>
        /// Which type of notification to display.
        /// </summary>
        [JsonPropertyName("type")]
        public TemplateType Type { get; set; }
        
        // Property Definition
        /// <summary>
        /// A URL to the sender's avatar, app icon, or a thumbnail for image notifications.
        /// </summary>
        [JsonPropertyName("iconUrl")]
        public string IconUrl { get; set; }
        
        // Property Definition
        /// <summary>
        /// A URL to the app icon mask.
        /// </summary>
        [JsonPropertyName("appIconMaskUrl")]
        public string AppIconMaskUrl { get; set; }
        
        // Property Definition
        /// <summary>
        /// Title of the notification (e.g. sender name for email).
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        // Property Definition
        /// <summary>
        /// Main notification content.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        // Property Definition
        /// <summary>
        /// Alternate notification content with a lower-weight font.
        /// </summary>
        [JsonPropertyName("contextMessage")]
        public string ContextMessage { get; set; }
        
        // Property Definition
        /// <summary>
        /// Priority ranges from -2 to 2. -2 is lowest priority. 2 is highest. Zero is default.
        /// </summary>
        [JsonPropertyName("priority")]
        public int? Priority { get; set; }
        
        // Property Definition
        /// <summary>
        /// A timestamp associated with the notification, in milliseconds past the epoch.
        /// </summary>
        [JsonPropertyName("eventTime")]
        public double? EventTime { get; set; }
        
        // Property Definition
        /// <summary>
        /// A URL to the image thumbnail for image-type notifications.
        /// </summary>
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
        
        // Property Definition
        /// <summary>
        /// Items for multi-item notifications.
        /// </summary>
        [JsonPropertyName("items")]
        public IEnumerable<NotificationItem> Items { get; set; }
        
        // Property Definition
        /// <summary>
        /// Current progress ranges from 0 to 100.
        /// </summary>
        [JsonPropertyName("progress")]
        public int? Progress { get; set; }
        
        // Property Definition
        /// <summary>
        /// Whether to show UI indicating that the app will visibly respond to clicks on the body of a notification.
        /// </summary>
        [JsonPropertyName("isClickable")]
        public bool? IsClickable { get; set; }
    }
}

