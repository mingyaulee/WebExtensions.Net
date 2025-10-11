using System.Text.Json.Serialization;

namespace WebExtensions.Net.History;

/// <summary>The $(topic:transition-types)[transition type] for this visit from its referrer.</summary>
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

    /// <summary>auto_toplevel</summary>
    [EnumValue("auto_toplevel")]
    AutoToplevel,

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
