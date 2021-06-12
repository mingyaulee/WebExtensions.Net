using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary></summary>
    public partial class UninstallSelfOptions : BaseObject
    {
        private string _dialogMessage;
        private bool? _showConfirmDialog;

        /// <summary>The message to display to a user when being asked to confirm removal of the extension.</summary>
        [JsonPropertyName("dialogMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DialogMessage
        {
            get
            {
                InitializeProperty("dialogMessage", _dialogMessage);
                return _dialogMessage;
            }
            set
            {
                _dialogMessage = value;
            }
        }

        /// <summary>Whether or not a confirm-uninstall dialog should prompt the user. Defaults to false.</summary>
        [JsonPropertyName("showConfirmDialog")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowConfirmDialog
        {
            get
            {
                InitializeProperty("showConfirmDialog", _showConfirmDialog);
                return _showConfirmDialog;
            }
            set
            {
                _showConfirmDialog = value;
            }
        }
    }
}
