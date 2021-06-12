using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction
{
    // Type Class
    /// <summary></summary>
    public partial class SetBadgeTextDetails : BaseObject
    {
        private Text _text;

        /// <summary>Any number of characters can be passed, but only about four can fit in the space.</summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Text Text
        {
            get
            {
                InitializeProperty("text", _text);
                return _text;
            }
            set
            {
                _text = value;
            }
        }
    }
}
