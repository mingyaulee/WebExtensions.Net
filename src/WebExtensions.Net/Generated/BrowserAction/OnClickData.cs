using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction
{
    // Type Class
    /// <summary>Information sent when a browser action is clicked.</summary>
    public partial class OnClickData : BaseObject
    {
        private int? _button;
        private IEnumerable<string> _modifiers;

        /// <summary>An integer value of button by which menu item was clicked.</summary>
        [JsonPropertyName("button")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Button
        {
            get
            {
                InitializeProperty("button", _button);
                return _button;
            }
            set
            {
                _button = value;
            }
        }

        /// <summary>An array of keyboard modifiers that were held while the menu item was clicked.</summary>
        [JsonPropertyName("modifiers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Modifiers
        {
            get
            {
                InitializeProperty("modifiers", _modifiers);
                return _modifiers;
            }
            set
            {
                _modifiers = value;
            }
        }
    }
}
