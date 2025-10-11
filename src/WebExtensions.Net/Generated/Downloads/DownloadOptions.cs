﻿using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads;

// Type Class
/// <summary>What to download and how.</summary>
[BindAllProperties]
public partial class DownloadOptions : BaseObject
{
    /// <summary>When this flag is set to <c>true</c>, then the browser will allow downloads to proceed after encountering HTTP errors such as <c>404 Not Found</c>.</summary>
    [JsAccessPath("allowHttpErrors")]
    [JsonPropertyName("allowHttpErrors")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllowHttpErrors { get; set; }

    /// <summary>Post body.</summary>
    [JsAccessPath("body")]
    [JsonPropertyName("body")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Body { get; set; }

    /// <summary></summary>
    [JsAccessPath("conflictAction")]
    [JsonPropertyName("conflictAction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FilenameConflictAction? ConflictAction { get; set; }

    /// <summary>The cookie store ID of the contextual identity; requires "cookies" permission.</summary>
    [JsAccessPath("cookieStoreId")]
    [JsonPropertyName("cookieStoreId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string CookieStoreId { get; set; }

    /// <summary>A file path relative to the Downloads directory to contain the downloaded file.</summary>
    [JsAccessPath("filename")]
    [JsonPropertyName("filename")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Filename { get; set; }

    /// <summary>Extra HTTP headers to send with the request if the URL uses the HTTP[s] protocol. Each header is represented as a dictionary containing the keys <c>name</c> and either <c>value</c> or <c>binaryValue</c>, restricted to those allowed by XMLHttpRequest.</summary>
    [JsAccessPath("headers")]
    [JsonPropertyName("headers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<Header> Headers { get; set; }

    /// <summary>Whether to associate the download with a private browsing session.</summary>
    [JsAccessPath("incognito")]
    [JsonPropertyName("incognito")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Incognito { get; set; }

    /// <summary>The HTTP method to use if the URL uses the HTTP[S] protocol.</summary>
    [JsAccessPath("method")]
    [JsonPropertyName("method")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Method? Method { get; set; }

    /// <summary>Use a file-chooser to allow the user to select a filename. If the option is not specified, the file chooser will be shown only if the Firefox "Always ask you where to save files" option is enabled (i.e. the pref <c>browser.download.useDownloadDir</c> is set to <c>false</c>).</summary>
    [JsAccessPath("saveAs")]
    [JsonPropertyName("saveAs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SaveAs { get; set; }

    /// <summary>The URL to download.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
