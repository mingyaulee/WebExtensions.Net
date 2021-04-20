using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.Notifications
{
    // Type Class
    /// <summary></summary>
    public class CreateNotificationOptions : BaseObject
    {
        private string _appIconMaskUrl;
        private string _contextMessage;
        private double? _eventTime;
        private string _iconUrl;
        private string _imageUrl;
        private bool? _isClickable;
        private IEnumerable<NotificationItem> _items;
        private string _message;
        private int? _priority;
        private int? _progress;
        private string _title;
        private TemplateType _type;

        /// <summary>A URL to the app icon mask.</summary>
        [JsonPropertyName("appIconMaskUrl")]
        public string AppIconMaskUrl
        {
            get
            {
                InitializeProperty("appIconMaskUrl", _appIconMaskUrl);
                return _appIconMaskUrl;
            }
            set
            {
                _appIconMaskUrl = value;
            }
        }

        /// <summary>Alternate notification content with a lower-weight font.</summary>
        [JsonPropertyName("contextMessage")]
        public string ContextMessage
        {
            get
            {
                InitializeProperty("contextMessage", _contextMessage);
                return _contextMessage;
            }
            set
            {
                _contextMessage = value;
            }
        }

        /// <summary>A timestamp associated with the notification, in milliseconds past the epoch.</summary>
        [JsonPropertyName("eventTime")]
        public double? EventTime
        {
            get
            {
                InitializeProperty("eventTime", _eventTime);
                return _eventTime;
            }
            set
            {
                _eventTime = value;
            }
        }

        /// <summary>A URL to the sender's avatar, app icon, or a thumbnail for image notifications.</summary>
        [JsonPropertyName("iconUrl")]
        public string IconUrl
        {
            get
            {
                InitializeProperty("iconUrl", _iconUrl);
                return _iconUrl;
            }
            set
            {
                _iconUrl = value;
            }
        }

        /// <summary>A URL to the image thumbnail for image-type notifications.</summary>
        [JsonPropertyName("imageUrl")]
        public string ImageUrl
        {
            get
            {
                InitializeProperty("imageUrl", _imageUrl);
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
            }
        }

        /// <summary>Whether to show UI indicating that the app will visibly respond to clicks on the body of a notification.</summary>
        [JsonPropertyName("isClickable")]
        public bool? IsClickable
        {
            get
            {
                InitializeProperty("isClickable", _isClickable);
                return _isClickable;
            }
            set
            {
                _isClickable = value;
            }
        }

        /// <summary>Items for multi-item notifications.</summary>
        [JsonPropertyName("items")]
        public IEnumerable<NotificationItem> Items
        {
            get
            {
                InitializeProperty("items", _items);
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        /// <summary>Main notification content.</summary>
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

        /// <summary>Priority ranges from -2 to 2. -2 is lowest priority. 2 is highest. Zero is default.</summary>
        [JsonPropertyName("priority")]
        public int? Priority
        {
            get
            {
                InitializeProperty("priority", _priority);
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        /// <summary>Current progress ranges from 0 to 100.</summary>
        [JsonPropertyName("progress")]
        public int? Progress
        {
            get
            {
                InitializeProperty("progress", _progress);
                return _progress;
            }
            set
            {
                _progress = value;
            }
        }

        /// <summary>Title of the notification (e.g. sender name for email).</summary>
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

        /// <summary>Which type of notification to display.</summary>
        [JsonPropertyName("type")]
        public TemplateType Type
        {
            get
            {
                InitializeProperty("type", _type);
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
}
