using System.Text.Json.Serialization;

namespace WebExtensions.Net.TopSites
{
    // Type Class
    /// <summary>An object encapsulating a most visited URL, such as the URLs on the new tab page.</summary>
    public partial class MostVisitedURL : BaseObject
    {
        private string _favicon;
        private string _title;
        private string _type;
        private string _url;

        /// <summary>Data URL for the favicon, if available.</summary>
        [JsonPropertyName("favicon")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Favicon
        {
            get
            {
                InitializeProperty("favicon", _favicon);
                return _favicon;
            }
            set
            {
                _favicon = value;
            }
        }

        /// <summary>The title of the page.</summary>
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

        /// <summary>The entry type, either <c>url</c> for a normal page link, or <c>search</c> for a search shortcut.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type
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

        /// <summary>The most visited URL.</summary>
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
