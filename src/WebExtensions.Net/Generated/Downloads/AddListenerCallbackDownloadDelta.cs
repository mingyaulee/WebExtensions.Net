using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    public partial class AddListenerCallbackDownloadDelta : BaseObject
    {
        private BooleanDelta _canResume;
        private StringDelta _danger;
        private StringDelta _endTime;
        private StringDelta _error;
        private BooleanDelta _exists;
        private StringDelta _filename;
        private DoubleDelta _fileSize;
        private int _id;
        private StringDelta _mime;
        private BooleanDelta _paused;
        private StringDelta _startTime;
        private StringDelta _state;
        private DoubleDelta _totalBytes;
        private StringDelta _url;

        /// <summary></summary>
        [JsonPropertyName("canResume")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta CanResume
        {
            get
            {
                InitializeProperty("canResume", _canResume);
                return _canResume;
            }
            set
            {
                _canResume = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>danger</c>.</summary>
        [JsonPropertyName("danger")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Danger
        {
            get
            {
                InitializeProperty("danger", _danger);
                return _danger;
            }
            set
            {
                _danger = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>endTime</c>.</summary>
        [JsonPropertyName("endTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta EndTime
        {
            get
            {
                InitializeProperty("endTime", _endTime);
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>error</c>.</summary>
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Error
        {
            get
            {
                InitializeProperty("error", _error);
                return _error;
            }
            set
            {
                _error = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("exists")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta Exists
        {
            get
            {
                InitializeProperty("exists", _exists);
                return _exists;
            }
            set
            {
                _exists = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>filename</c>.</summary>
        [JsonPropertyName("filename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Filename
        {
            get
            {
                InitializeProperty("filename", _filename);
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>fileSize</c>.</summary>
        [JsonPropertyName("fileSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleDelta FileSize
        {
            get
            {
                InitializeProperty("fileSize", _fileSize);
                return _fileSize;
            }
            set
            {
                _fileSize = value;
            }
        }

        /// <summary>The <c>id</c> of the <see href='#type-DownloadItem'>DownloadItem</see> that changed.</summary>
        [JsonPropertyName("id")]
        public int Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>mime</c>.</summary>
        [JsonPropertyName("mime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Mime
        {
            get
            {
                InitializeProperty("mime", _mime);
                return _mime;
            }
            set
            {
                _mime = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>paused</c>.</summary>
        [JsonPropertyName("paused")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanDelta Paused
        {
            get
            {
                InitializeProperty("paused", _paused);
                return _paused;
            }
            set
            {
                _paused = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>startTime</c>.</summary>
        [JsonPropertyName("startTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta StartTime
        {
            get
            {
                InitializeProperty("startTime", _startTime);
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>state</c>.</summary>
        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta State
        {
            get
            {
                InitializeProperty("state", _state);
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>totalBytes</c>.</summary>
        [JsonPropertyName("totalBytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleDelta TotalBytes
        {
            get
            {
                InitializeProperty("totalBytes", _totalBytes);
                return _totalBytes;
            }
            set
            {
                _totalBytes = value;
            }
        }

        /// <summary>Describes a change in a <see href='#type-DownloadItem'>DownloadItem</see>'s <c>url</c>.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringDelta Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
