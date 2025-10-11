﻿using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<OnBeforeRequestOptions>))]
public enum OnBeforeRequestOptions
{
    /// <summary>blocking</summary>
    [EnumValue("blocking")]
    Blocking,

    /// <summary>requestBody</summary>
    [EnumValue("requestBody")]
    RequestBody,
}
