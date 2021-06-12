using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types
{
    // Type Class
    /// <summary>Details of the currently effective value.</summary>
    public partial class CallbackDetails : BaseObject
    {
        private bool? _incognitoSpecific;
        private LevelOfControl _levelOfControl;
        private object _value;

        /// <summary>Whether the effective value is specific to the incognito session.<br/>This property will <em>only</em> be present if the <c>incognito</c> property in the <c>details</c> parameter of <c>get()</c> was true.</summary>
        [JsonPropertyName("incognitoSpecific")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncognitoSpecific
        {
            get
            {
                InitializeProperty("incognitoSpecific", _incognitoSpecific);
                return _incognitoSpecific;
            }
            set
            {
                _incognitoSpecific = value;
            }
        }

        /// <summary>The level of control of the setting.</summary>
        [JsonPropertyName("levelOfControl")]
        public LevelOfControl LevelOfControl
        {
            get
            {
                InitializeProperty("levelOfControl", _levelOfControl);
                return _levelOfControl;
            }
            set
            {
                _levelOfControl = value;
            }
        }

        /// <summary>The value of the setting.</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Value
        {
            get
            {
                InitializeProperty("value", _value);
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}
