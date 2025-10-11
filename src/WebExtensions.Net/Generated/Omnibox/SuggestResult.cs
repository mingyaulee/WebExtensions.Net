﻿using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Omnibox;

// Type Class
/// <summary>A suggest result.</summary>
[BindAllProperties]
public partial class SuggestResult : BaseObject
{
    /// <summary>The text that is put into the URL bar, and that is sent to the extension when the user chooses this entry.</summary>
    [JsAccessPath("content")]
    [JsonPropertyName("content")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Content { get; set; }

    /// <summary>Whether the suggest result can be deleted by the user.</summary>
    [JsAccessPath("deletable")]
    [JsonPropertyName("deletable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Deletable { get; set; }

    /// <summary>The text that is displayed in the URL dropdown. Can contain XML-style markup for styling. The supported tags are 'url' (for a literal URL), 'match' (for highlighting text that matched what the user's query), and 'dim' (for dim helper text). The styles can be nested, eg. 'dim''match'dimmed match'/match''/dim'. You must escape the five predefined entities to display them as text: stackoverflow.com/a/1091953/89484 </summary>
    [JsAccessPath("description")]
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Description { get; set; }
}
