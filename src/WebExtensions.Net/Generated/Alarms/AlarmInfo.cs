using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Alarms
{
    // Type Class
    /// <summary>Details about the alarm. The alarm first fires either at 'when' milliseconds past the epoch (if 'when' is provided), after 'delayInMinutes' minutes from the current time (if 'delayInMinutes' is provided instead), or after 'periodInMinutes' minutes from the current time (if only 'periodInMinutes' is provided). Users should never provide both 'when' and 'delayInMinutes'. If 'periodInMinutes' is provided, then the alarm recurs repeatedly after that many minutes.</summary>
    [BindAllProperties]
    public partial class AlarmInfo : BaseObject
    {
        /// <summary>Number of minutes from the current time after which the alarm should first fire.</summary>
        [JsonPropertyName("delayInMinutes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? DelayInMinutes { get; set; }

        /// <summary>Number of minutes after which the alarm should recur repeatedly.</summary>
        [JsonPropertyName("periodInMinutes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PeriodInMinutes { get; set; }

        /// <summary>Time when the alarm is scheduled to first fire, in milliseconds past the epoch.</summary>
        [JsonPropertyName("when")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EpochTime? When { get; set; }
    }
}
