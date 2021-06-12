using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary></summary>
    public partial class DownloadItem : BaseObject
    {
        private string _byExtensionId;
        private string _byExtensionName;
        private double _bytesReceived;
        private bool _canResume;
        private DangerType _danger;
        private string _endTime;
        private InterruptReason? _error;
        private string _estimatedEndTime;
        private bool _exists;
        private string _filename;
        private double _fileSize;
        private int _id;
        private bool _incognito;
        private string _mime;
        private bool _paused;
        private string _referrer;
        private string _startTime;
        private State _state;
        private double _totalBytes;
        private string _url;

        /// <summary></summary>
        [JsonPropertyName("byExtensionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ByExtensionId
        {
            get
            {
                InitializeProperty("byExtensionId", _byExtensionId);
                return _byExtensionId;
            }
            set
            {
                _byExtensionId = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("byExtensionName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ByExtensionName
        {
            get
            {
                InitializeProperty("byExtensionName", _byExtensionName);
                return _byExtensionName;
            }
            set
            {
                _byExtensionName = value;
            }
        }

        /// <summary>Number of bytes received so far from the host, without considering file compression.</summary>
        [JsonPropertyName("bytesReceived")]
        public double BytesReceived
        {
            get
            {
                InitializeProperty("bytesReceived", _bytesReceived);
                return _bytesReceived;
            }
            set
            {
                _bytesReceived = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("canResume")]
        public bool CanResume
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

        /// <summary>Indication of whether this download is thought to be safe or known to be suspicious.</summary>
        [JsonPropertyName("danger")]
        public DangerType Danger
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

        /// <summary>Number of milliseconds between the unix epoch and when this download ended.</summary>
        [JsonPropertyName("endTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EndTime
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

        /// <summary>Number indicating why a download was interrupted.</summary>
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public InterruptReason? Error
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
        [JsonPropertyName("estimatedEndTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EstimatedEndTime
        {
            get
            {
                InitializeProperty("estimatedEndTime", _estimatedEndTime);
                return _estimatedEndTime;
            }
            set
            {
                _estimatedEndTime = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("exists")]
        public bool Exists
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

        /// <summary>Absolute local path.</summary>
        [JsonPropertyName("filename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Filename
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

        /// <summary>Number of bytes in the whole file post-decompression, or -1 if unknown.</summary>
        [JsonPropertyName("fileSize")]
        public double FileSize
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

        /// <summary>An identifier that is persistent across browser sessions.</summary>
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

        /// <summary>False if this download is recorded in the history, true if it is not recorded.</summary>
        [JsonPropertyName("incognito")]
        public bool Incognito
        {
            get
            {
                InitializeProperty("incognito", _incognito);
                return _incognito;
            }
            set
            {
                _incognito = value;
            }
        }

        /// <summary>The file's MIME type.</summary>
        [JsonPropertyName("mime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Mime
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

        /// <summary>True if the download has stopped reading data from the host, but kept the connection open.</summary>
        [JsonPropertyName("paused")]
        public bool Paused
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

        /// <summary></summary>
        [JsonPropertyName("referrer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Referrer
        {
            get
            {
                InitializeProperty("referrer", _referrer);
                return _referrer;
            }
            set
            {
                _referrer = value;
            }
        }

        /// <summary>Number of milliseconds between the unix epoch and when this download began.</summary>
        [JsonPropertyName("startTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StartTime
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

        /// <summary>Indicates whether the download is progressing, interrupted, or complete.</summary>
        [JsonPropertyName("state")]
        public State State
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

        /// <summary>Number of bytes in the whole file, without considering file compression, or -1 if unknown.</summary>
        [JsonPropertyName("totalBytes")]
        public double TotalBytes
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

        /// <summary>Absolute URL.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url
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
