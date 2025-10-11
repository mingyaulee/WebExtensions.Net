using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActivityLog;

/// <summary>The type of log entry.  api_call is a function call made by the extension and api_event is an event callback to the extension.  content_script is logged when a content script is injected.</summary>
[JsonConverter(typeof(EnumStringConverter<DetailsType>))]
public enum DetailsType
{
    /// <summary>api_call</summary>
    [EnumValue("api_call")]
    ApiCall,

    /// <summary>api_event</summary>
    [EnumValue("api_event")]
    ApiEvent,

    /// <summary>content_script</summary>
    [EnumValue("content_script")]
    ContentScript,

    /// <summary>user_script</summary>
    [EnumValue("user_script")]
    UserScript,
}
