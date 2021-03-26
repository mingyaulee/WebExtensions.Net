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
    public class NotificationItem : BaseObject
    {
        
        // Property Definition
        private string _title;
        /// <summary>
        /// Title of one item of a list notification.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        
        // Property Definition
        private string _message;
        /// <summary>
        /// Additional details about this item.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message
        {
            get
            {
                InitializeProperty("message", _message);
                return _message;
            }
            set
            {
                _message = value;
            }
        }
    }
}

