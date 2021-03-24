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
    public class NotificationItem
    {
        
        // Property Definition
        /// <summary>
        /// Title of one item of a list notification.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        // Property Definition
        /// <summary>
        /// Additional details about this item.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}

