using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary>Parameters that combine to specify a predicate that can be used to select a set of downloads.  Used for example in search() and erase()</summary>
    public partial class DownloadQuery : BaseObject
    {
        private double? _bytesReceived;
        private DangerType? _danger;
        private DownloadTime _endedAfter;
        private DownloadTime _endedBefore;
        private string _endTime;
        private InterruptReason? _error;
        private bool? _exists;
        private string _filename;
        private string _filenameRegex;
        private double? _fileSize;
        private int? _id;
        private int? _limit;
        private string _mime;
        private IEnumerable<string> _orderBy;
        private bool? _paused;
        private IEnumerable<string> _query;
        private DownloadTime _startedAfter;
        private DownloadTime _startedBefore;
        private string _startTime;
        private State? _state;
        private double? _totalBytes;
        private double? _totalBytesGreater;
        private double? _totalBytesLess;
        private string _url;
        private string _urlRegex;

        /// <summary>Number of bytes received so far from the host, without considering file compression.</summary>
        [JsonPropertyName("bytesReceived")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? BytesReceived
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

        /// <summary>Indication of whether this download is thought to be safe or known to be suspicious.</summary>
        [JsonPropertyName("danger")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DangerType? Danger
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

        /// <summary>Limits results to downloads that ended after the given ms since the epoch.</summary>
        [JsonPropertyName("endedAfter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DownloadTime EndedAfter
        {
            get
            {
                InitializeProperty("endedAfter", _endedAfter);
                return _endedAfter;
            }
            set
            {
                _endedAfter = value;
            }
        }

        /// <summary>Limits results to downloads that ended before the given ms since the epoch.</summary>
        [JsonPropertyName("endedBefore")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DownloadTime EndedBefore
        {
            get
            {
                InitializeProperty("endedBefore", _endedBefore);
                return _endedBefore;
            }
            set
            {
                _endedBefore = value;
            }
        }

        /// <summary></summary>
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

        /// <summary>Why a download was interrupted.</summary>
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
        [JsonPropertyName("exists")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Exists
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

        /// <summary>Limits results to <see href='#type-DownloadItem'>DownloadItems</see> whose <c>filename</c> matches the given regular expression.</summary>
        [JsonPropertyName("filenameRegex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FilenameRegex
        {
            get
            {
                InitializeProperty("filenameRegex", _filenameRegex);
                return _filenameRegex;
            }
            set
            {
                _filenameRegex = value;
            }
        }

        /// <summary>Number of bytes in the whole file post-decompression, or -1 if unknown.</summary>
        [JsonPropertyName("fileSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FileSize
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

        /// <summary></summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Id
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

        /// <summary>Setting this integer limits the number of results. Otherwise, all matching <see href='#type-DownloadItem'>DownloadItems</see> will be returned.</summary>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Limit
        {
            get
            {
                InitializeProperty("limit", _limit);
                return _limit;
            }
            set
            {
                _limit = value;
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

        /// <summary>Setting elements of this array to <see href='#type-DownloadItem'>DownloadItem</see> properties in order to sort the search results. For example, setting <c>orderBy='startTime'</c> sorts the <see href='#type-DownloadItem'>DownloadItems</see> by their start time in ascending order. To specify descending order, prefix <c>orderBy</c> with a hyphen: '-startTime'.</summary>
        [JsonPropertyName("orderBy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> OrderBy
        {
            get
            {
                InitializeProperty("orderBy", _orderBy);
                return _orderBy;
            }
            set
            {
                _orderBy = value;
            }
        }

        /// <summary>True if the download has stopped reading data from the host, but kept the connection open.</summary>
        [JsonPropertyName("paused")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Paused
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

        /// <summary>This array of search terms limits results to <see href='#type-DownloadItem'>DownloadItems</see> whose <c>filename</c> or <c>url</c> contain all of the search terms that do not begin with a dash '-' and none of the search terms that do begin with a dash.</summary>
        [JsonPropertyName("query")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Query
        {
            get
            {
                InitializeProperty("query", _query);
                return _query;
            }
            set
            {
                _query = value;
            }
        }

        /// <summary>Limits results to downloads that started after the given ms since the epoch.</summary>
        [JsonPropertyName("startedAfter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DownloadTime StartedAfter
        {
            get
            {
                InitializeProperty("startedAfter", _startedAfter);
                return _startedAfter;
            }
            set
            {
                _startedAfter = value;
            }
        }

        /// <summary>Limits results to downloads that started before the given ms since the epoch.</summary>
        [JsonPropertyName("startedBefore")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DownloadTime StartedBefore
        {
            get
            {
                InitializeProperty("startedBefore", _startedBefore);
                return _startedBefore;
            }
            set
            {
                _startedBefore = value;
            }
        }

        /// <summary></summary>
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public State? State
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TotalBytes
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

        /// <summary>Limits results to downloads whose totalBytes is greater than the given integer.</summary>
        [JsonPropertyName("totalBytesGreater")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TotalBytesGreater
        {
            get
            {
                InitializeProperty("totalBytesGreater", _totalBytesGreater);
                return _totalBytesGreater;
            }
            set
            {
                _totalBytesGreater = value;
            }
        }

        /// <summary>Limits results to downloads whose totalBytes is less than the given integer.</summary>
        [JsonPropertyName("totalBytesLess")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TotalBytesLess
        {
            get
            {
                InitializeProperty("totalBytesLess", _totalBytesLess);
                return _totalBytesLess;
            }
            set
            {
                _totalBytesLess = value;
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

        /// <summary>Limits results to <see href='#type-DownloadItem'>DownloadItems</see> whose <c>url</c> matches the given regular expression.</summary>
        [JsonPropertyName("urlRegex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UrlRegex
        {
            get
            {
                InitializeProperty("urlRegex", _urlRegex);
                return _urlRegex;
            }
            set
            {
                _urlRegex = value;
            }
        }
    }
}
