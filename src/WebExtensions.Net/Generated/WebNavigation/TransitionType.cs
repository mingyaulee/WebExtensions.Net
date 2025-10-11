﻿using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation;

/// <summary>Cause of the navigation. The same transition types as defined in the history API are used. These are the same transition types as defined in the $(topic:transition_types)[history API] except with <c>"start_page"</c> in place of <c>"auto_toplevel"</c> (for backwards compatibility).</summary>
[JsonConverter(typeof(EnumStringConverter<TransitionType>))]
public enum TransitionType
{
    /// <summary>link</summary>
    [EnumValue("link")]
    Link,

    /// <summary>typed</summary>
    [EnumValue("typed")]
    Typed,

    /// <summary>auto_bookmark</summary>
    [EnumValue("auto_bookmark")]
    AutoBookmark,

    /// <summary>auto_subframe</summary>
    [EnumValue("auto_subframe")]
    AutoSubframe,

    /// <summary>manual_subframe</summary>
    [EnumValue("manual_subframe")]
    ManualSubframe,

    /// <summary>generated</summary>
    [EnumValue("generated")]
    Generated,

    /// <summary>start_page</summary>
    [EnumValue("start_page")]
    StartPage,

    /// <summary>form_submit</summary>
    [EnumValue("form_submit")]
    FormSubmit,

    /// <summary>reload</summary>
    [EnumValue("reload")]
    Reload,

    /// <summary>keyword</summary>
    [EnumValue("keyword")]
    Keyword,

    /// <summary>keyword_generated</summary>
    [EnumValue("keyword_generated")]
    KeywordGenerated,
}
