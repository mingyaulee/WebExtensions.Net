using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary>Information about an icon belonging to an extension.</summary>
    public partial class IconInfo : BaseObject
    {
        private int _size;
        private string _url;

        /// <summary>A number representing the width and height of the icon. Likely values include (but are not limited to) 128, 48, 24, and 16.</summary>
        [JsonPropertyName("size")]
        public int Size
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

        /// <summary>The URL for this icon image. To display a grayscale version of the icon (to indicate that an extension is disabled, for example), append <c>?grayscale=true</c> to the URL.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
