using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    public partial class GetFileIconOptions : BaseObject
    {
        private int? _size;

        /// <summary>The size of the icon.  The returned icon will be square with dimensions size * size pixels.  The default size for the icon is 32x32 pixels.</summary>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Size
        {
            get
            {
                InitializeProperty("size", _size);
                return _size;
            }
            set
            {
                _size = value;
            }
        }
    }
}
