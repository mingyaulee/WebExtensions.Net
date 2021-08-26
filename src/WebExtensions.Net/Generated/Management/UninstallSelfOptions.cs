using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class UninstallSelfOptions : BaseObject
    {
        /// <summary>The message to display to a user when being asked to confirm removal of the extension.</summary>
        [JsonPropertyName("dialogMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DialogMessage { get; set; }

        /// <summary>Whether or not a confirm-uninstall dialog should prompt the user. Defaults to false.</summary>
        [JsonPropertyName("showConfirmDialog")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowConfirmDialog { get; set; }
    }
}
