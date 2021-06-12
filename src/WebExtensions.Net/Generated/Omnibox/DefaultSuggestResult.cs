using System.Text.Json.Serialization;

namespace WebExtensions.Net.Omnibox
{
    // Type Class
    /// <summary>A suggest result.</summary>
    public partial class DefaultSuggestResult : BaseObject
    {
        private string _description;

        /// <summary>The text that is displayed in the URL dropdown.</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description
        {
            get
            {
                InitializeProperty("description", _description);
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }
}
