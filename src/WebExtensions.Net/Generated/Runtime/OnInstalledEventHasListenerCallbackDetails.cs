using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary></summary>
    public partial class OnInstalledEventHasListenerCallbackDetails : BaseObject
    {
        private string _previousVersion;
        private OnInstalledReason _reason;
        private bool _temporary;

        /// <summary>Indicates the previous version of the extension, which has just been updated. This is present only if 'reason' is 'update'.</summary>
        [JsonPropertyName("previousVersion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PreviousVersion
        {
            get
            {
                InitializeProperty("previousVersion", _previousVersion);
                return _previousVersion;
            }
            set
            {
                _previousVersion = value;
            }
        }

        /// <summary>The reason that this event is being dispatched.</summary>
        [JsonPropertyName("reason")]
        public OnInstalledReason Reason
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

        /// <summary>Indicates whether the addon is installed as a temporary extension.</summary>
        [JsonPropertyName("temporary")]
        public bool Temporary
        {
            get
            {
                InitializeProperty("temporary", _temporary);
                return _temporary;
            }
            set
            {
                _temporary = value;
            }
        }
    }
}
