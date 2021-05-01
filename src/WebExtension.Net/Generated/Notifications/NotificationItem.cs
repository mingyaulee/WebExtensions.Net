using System.Text.Json.Serialization;

namespace WebExtension.Net.Notifications
{
    // Type Class
    /// <summary></summary>
    public class NotificationItem : BaseObject
    {
        private string _message;
        private string _title;

        /// <summary>Additional details about this item.</summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

        /// <summary>Title of one item of a list notification.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
    }
}
