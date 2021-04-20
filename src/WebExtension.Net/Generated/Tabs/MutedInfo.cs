using System.Text.Json.Serialization;

namespace WebExtension.Net.Tabs
{
    // Type Class
    /// <summary>Tab muted state and the reason for the last state change.</summary>
    public class MutedInfo : BaseObject
    {
        private string _extensionId;
        private bool _muted;
        private MutedInfoReason _reason;

        /// <summary>The ID of the extension that changed the muted state. Not set if an extension was not the reason the muted state last changed.</summary>
        [JsonPropertyName("extensionId")]
        public string ExtensionId
        {
            get
            {
                InitializeProperty("extensionId", _extensionId);
                return _extensionId;
            }
            set
            {
                _extensionId = value;
            }
        }

        /// <summary>Whether the tab is prevented from playing sound (but hasn't necessarily recently produced sound). Equivalent to whether the muted audio indicator is showing.</summary>
        [JsonPropertyName("muted")]
        public bool Muted
        {
            get
            {
                InitializeProperty("muted", _muted);
                return _muted;
            }
            set
            {
                _muted = value;
            }
        }

        /// <summary>The reason the tab was muted or unmuted. Not set if the tab's mute state has never been changed.</summary>
        [JsonPropertyName("reason")]
        public MutedInfoReason Reason
        {
            get
            {
                InitializeProperty("reason", _reason);
                return _reason;
            }
            set
            {
                _reason = value;
            }
        }
    }
}
