using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class HasListenerCallbackDownloadDelta : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("canResume")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta CanResume { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>danger</c>.</summary>
        [JsonPropertyName("danger")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Danger { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>endTime</c>.</summary>
        [JsonPropertyName("endTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta EndTime { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>error</c>.</summary>
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Error { get; set; }

        /// <summary></summary>
        [JsonPropertyName("exists")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta Exists { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>filename</c>.</summary>
        [JsonPropertyName("filename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Filename { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>fileSize</c>.</summary>
        [JsonPropertyName("fileSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleDelta FileSize { get; set; }

        /// <summary>The <c>id</c> of the <see href='#type-DownloadItem'>DownloadItem</see> that changed.</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>mime</c>.</summary>
        [JsonPropertyName("mime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Mime { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>paused</c>.</summary>
        [JsonPropertyName("paused")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta Paused { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>startTime</c>.</summary>
        [JsonPropertyName("startTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta StartTime { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>state</c>.</summary>
        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta State { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>totalBytes</c>.</summary>
        [JsonPropertyName("totalBytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleDelta TotalBytes { get; set; }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>url</c>.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Url { get; set; }
    }
}
