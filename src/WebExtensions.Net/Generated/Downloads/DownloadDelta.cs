using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class DownloadDelta : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("canResume")]
        [JsonPropertyName("canResume")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta CanResume { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>danger</c>.</summary>
        [JsAccessPath("danger")]
        [JsonPropertyName("danger")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Danger { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>endTime</c>.</summary>
        [JsAccessPath("endTime")]
        [JsonPropertyName("endTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta EndTime { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>error</c>.</summary>
        [JsAccessPath("error")]
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Error { get; set; }

        /// <summary></summary>
        [JsAccessPath("exists")]
        [JsonPropertyName("exists")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta Exists { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>filename</c>.</summary>
        [JsAccessPath("filename")]
        [JsonPropertyName("filename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Filename { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>fileSize</c>.</summary>
        [JsAccessPath("fileSize")]
        [JsonPropertyName("fileSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleDelta FileSize { get; set; }

        /// <summary>The <c>id</c> of the <see href='#type-DownloadItem'>DownloadItem</see> that changed.</summary>
        [JsAccessPath("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>mime</c>.</summary>
        [JsAccessPath("mime")]
        [JsonPropertyName("mime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Mime { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>paused</c>.</summary>
        [JsAccessPath("paused")]
        [JsonPropertyName("paused")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta Paused { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>startTime</c>.</summary>
        [JsAccessPath("startTime")]
        [JsonPropertyName("startTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta StartTime { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>state</c>.</summary>
        [JsAccessPath("state")]
        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta State { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>totalBytes</c>.</summary>
        [JsAccessPath("totalBytes")]
        [JsonPropertyName("totalBytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleDelta TotalBytes { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>url</c>.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Url { get; set; }
    }
}
