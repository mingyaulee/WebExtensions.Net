using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction
{
    // Type Class
    /// <summary></summary>
    public partial class SetBadgeTextColorDetails : BaseObject
    {
        private ColorValue _color;

        /// <summary></summary>
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ColorValue Color
        {
            get
            {
                InitializeProperty("color", _color);
                return _color;
            }
            set
            {
                _color = value;
            }
        }
    }
}
