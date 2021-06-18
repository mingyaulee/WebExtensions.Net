using System.Text.Json.Serialization;

namespace WebExtensions.Net.Alarms
{
    // Type Class
    /// <summary></summary>
    public partial class Alarm : BaseObject
    {
        private string _name;
        private double? _periodInMinutes;
        private long _scheduledTime;

        /// <summary>Name of this alarm.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>When present, signals that the alarm triggers periodically after so many minutes.</summary>
        [JsonPropertyName("periodInMinutes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PeriodInMinutes
        {
            get
            {
                InitializeProperty("periodInMinutes", _periodInMinutes);
                return _periodInMinutes;
            }
            set
            {
                _periodInMinutes = value;
            }
        }

        /// <summary>Time when the alarm is scheduled to fire, in milliseconds past the epoch.</summary>
        [JsonPropertyName("scheduledTime")]
        public long ScheduledTime
        {
            get
            {
                InitializeProperty("scheduledTime", _scheduledTime);
                return _scheduledTime;
            }
            set
            {
                _scheduledTime = value;
            }
        }
    }
}
