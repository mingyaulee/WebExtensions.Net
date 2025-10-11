﻿using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Notifications;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class NotificationOptions : BaseObject
{
    /// <summary>A URL to the app icon mask.</summary>
    [JsAccessPath("appIconMaskUrl")]
    [JsonPropertyName("appIconMaskUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AppIconMaskUrl { get; set; }

    /// <summary>Alternate notification content with a lower-weight font.</summary>
    [JsAccessPath("contextMessage")]
    [JsonPropertyName("contextMessage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ContextMessage { get; set; }

    /// <summary>A timestamp associated with the notification, in milliseconds past the epoch.</summary>
    [JsAccessPath("eventTime")]
    [JsonPropertyName("eventTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EpochTime? EventTime { get; set; }

    /// <summary>A URL to the sender's avatar, app icon, or a thumbnail for image notifications.</summary>
    [JsAccessPath("iconUrl")]
    [JsonPropertyName("iconUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string IconUrl { get; set; }

    /// <summary>A URL to the image thumbnail for image-type notifications.</summary>
    [JsAccessPath("imageUrl")]
    [JsonPropertyName("imageUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ImageUrl { get; set; }

    /// <summary>Whether to show UI indicating that the app will visibly respond to clicks on the body of a notification.</summary>
    [JsAccessPath("isClickable")]
    [JsonPropertyName("isClickable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsClickable { get; set; }

    /// <summary>Items for multi-item notifications.</summary>
    [JsAccessPath("items")]
    [JsonPropertyName("items")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<NotificationItem> Items { get; set; }

    /// <summary>Main notification content.</summary>
    [JsAccessPath("message")]
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Message { get; set; }

    /// <summary>Priority ranges from -2 to 2. -2 is lowest priority. 2 is highest. Zero is default.</summary>
    [JsAccessPath("priority")]
    [JsonPropertyName("priority")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Priority { get; set; }

    /// <summary>Current progress ranges from 0 to 100.</summary>
    [JsAccessPath("progress")]
    [JsonPropertyName("progress")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Progress { get; set; }

    /// <summary>Title of the notification (e.g. sender name for email).</summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }

    /// <summary>Which type of notification to display.</summary>
    [JsAccessPath("type")]
    [JsonPropertyName("type")]
    public TemplateType Type { get; set; }
}
