﻿using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Alarms;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class Alarm : BaseObject
{
    /// <summary>Name of this alarm.</summary>
    [JsAccessPath("name")]
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }

    /// <summary>When present, signals that the alarm triggers periodically after so many minutes.</summary>
    [JsAccessPath("periodInMinutes")]
    [JsonPropertyName("periodInMinutes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? PeriodInMinutes { get; set; }

    /// <summary>Time when the alarm is scheduled to fire, in milliseconds past the epoch.</summary>
    [JsAccessPath("scheduledTime")]
    [JsonPropertyName("scheduledTime")]
    public EpochTime ScheduledTime { get; set; }
}
