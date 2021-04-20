using System.Text.Json.Serialization;

namespace WebExtension.Net.Storage
{
    // Type Class
    /// <summary></summary>
    public class StorageChange : BaseObject
    {
        private object _newValue;
        private object _oldValue;

        /// <summary>The new value of the item, if there is a new value.</summary>
        [JsonPropertyName("newValue")]
        public object NewValue
        {
            get
            {
                InitializeProperty("newValue", _newValue);
                return _newValue;
            }
            set
            {
                _newValue = value;
            }
        }

        /// <summary>The old value of the item, if there was an old value.</summary>
        [JsonPropertyName("oldValue")]
        public object OldValue
        {
            get
            {
                InitializeProperty("oldValue", _oldValue);
                return _oldValue;
            }
            set
            {
                _oldValue = value;
            }
        }
    }
}
