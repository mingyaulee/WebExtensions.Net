using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction
{
    // Type Class
    /// <summary></summary>
    public partial class SetPopupDetails : BaseObject
    {
        private Popup _popup;

        /// <summary>The html file to show in a popup.  If set to the empty string (''), no popup is shown.</summary>
        [JsonPropertyName("popup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Popup Popup
        {
            get
            {
                InitializeProperty("popup", _popup);
                return _popup;
            }
            set
            {
                _popup = value;
            }
        }
    }
}
