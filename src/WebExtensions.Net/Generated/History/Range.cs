using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    public partial class Range : BaseObject
    {
        private Date _endTime;
        private Date _startTime;

        /// <summary>Items added to history before this date.</summary>
        [JsonPropertyName("endTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date EndTime
        {
            get
            {
                InitializeProperty("endTime", _endTime);
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /// <summary>Items added to history after this date.</summary>
        [JsonPropertyName("startTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date StartTime
        {
            get
            {
                InitializeProperty("startTime", _startTime);
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }
    }
}
