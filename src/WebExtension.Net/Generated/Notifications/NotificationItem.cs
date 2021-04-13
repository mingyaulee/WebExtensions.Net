using System.Text.Json.Serialization;

namespace WebExtension.Net.Notifications
{
    // Type Class
    /// <summary></summary>
    public class NotificationItem : BaseObject
    {
        private string _title;
        private string _message;

        /// <summary>Title of one item of a list notification.</summary>
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

        /// <summary>Additional details about this item.</summary>
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
