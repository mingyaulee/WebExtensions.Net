using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class DownloadItem : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("byExtensionId")]
    [JsonPropertyName("byExtensionId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ByExtensionId { get; set; }

    /// <summary></summary>
    [JsAccessPath("byExtensionName")]
    [JsonPropertyName("byExtensionName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ByExtensionName { get; set; }

    /// <summary>Number of bytes received so far from the host, without considering file compression.</summary>
    [JsAccessPath("bytesReceived")]
    [JsonPropertyName("bytesReceived")]
    public double BytesReceived { get; set; }

    /// <summary></summary>
    [JsAccessPath("canResume")]
    [JsonPropertyName("canResume")]
    public bool CanResume { get; set; }

    /// <summary>The cookie store ID of the contextual identity.</summary>
    [JsAccessPath("cookieStoreId")]
    [JsonPropertyName("cookieStoreId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string CookieStoreId { get; set; }

    /// <summary>Indication of whether this download is thought to be safe or known to be suspicious.</summary>
    [JsAccessPath("danger")]
    [JsonPropertyName("danger")]
    public DangerType Danger { get; set; }

    /// <summary>Number of milliseconds between the unix epoch and when this download ended.</summary>
    [JsAccessPath("endTime")]
    [JsonPropertyName("endTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string EndTime { get; set; }

    /// <summary>Number indicating why a download was interrupted.</summary>
    [JsAccessPath("error")]
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InterruptReason? Error { get; set; }

    /// <summary></summary>
    [JsAccessPath("estimatedEndTime")]
    [JsonPropertyName("estimatedEndTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string EstimatedEndTime { get; set; }

    /// <summary></summary>
    [JsAccessPath("exists")]
    [JsonPropertyName("exists")]
    public bool Exists { get; set; }

    /// <summary>Absolute local path.</summary>
    [JsAccessPath("filename")]
    [JsonPropertyName("filename")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Filename { get; set; }

    /// <summary>Number of bytes in the whole file post-decompression, or -1 if unknown.</summary>
    [JsAccessPath("fileSize")]
    [JsonPropertyName("fileSize")]
    public double FileSize { get; set; }

    /// <summary>An identifier that is persistent across browser sessions.</summary>
    [JsAccessPath("id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>False if this download is recorded in the history, true if it is not recorded.</summary>
    [JsAccessPath("incognito")]
    [JsonPropertyName("incognito")]
    public bool Incognito { get; set; }

    /// <summary>The file's MIME type.</summary>
    [JsAccessPath("mime")]
    [JsonPropertyName("mime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Mime { get; set; }

    /// <summary>True if the download has stopped reading data from the host, but kept the connection open.</summary>
    [JsAccessPath("paused")]
    [JsonPropertyName("paused")]
    public bool Paused { get; set; }

    /// <summary></summary>
    [JsAccessPath("referrer")]
    [JsonPropertyName("referrer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Referrer { get; set; }

    /// <summary>Number of milliseconds between the unix epoch and when this download began.</summary>
    [JsAccessPath("startTime")]
    [JsonPropertyName("startTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string StartTime { get; set; }

    /// <summary>Indicates whether the download is progressing, interrupted, or complete.</summary>
    [JsAccessPath("state")]
    [JsonPropertyName("state")]
    public State State { get; set; }

    /// <summary>Number of bytes in the whole file, without considering file compression, or -1 if unknown.</summary>
    [JsAccessPath("totalBytes")]
    [JsonPropertyName("totalBytes")]
    public double TotalBytes { get; set; }

    /// <summary>Absolute URL.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
