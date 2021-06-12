using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads
{
    // Type Class
    /// <summary>What to download and how.</summary>
    public partial class DownloadOptions : BaseObject
    {
        private bool? _allowHttpErrors;
        private string _body;
        private FilenameConflictAction? _conflictAction;
        private string _filename;
        private IEnumerable<HeadersArrayItem> _headers;
        private bool? _incognito;
        private string _method;
        private bool? _saveAs;
        private string _url;

        /// <summary>When this flag is set to <c>true</c>, then the browser will allow downloads to proceed after encountering HTTP errors such as <c>404 Not Found</c>.</summary>
        [JsonPropertyName("allowHttpErrors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowHttpErrors
        {
            get
            {
                InitializeProperty("allowHttpErrors", _allowHttpErrors);
                return _allowHttpErrors;
            }
            set
            {
                _allowHttpErrors = value;
            }
        }

        /// <summary>Post body.</summary>
        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Body
        {
            get
            {
                InitializeProperty("body", _body);
                return _body;
            }
            set
            {
                _body = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("conflictAction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FilenameConflictAction? ConflictAction
        {
            get
            {
                InitializeProperty("conflictAction", _conflictAction);
                return _conflictAction;
            }
            set
            {
                _conflictAction = value;
            }
        }

        /// <summary>A file path relative to the Downloads directory to contain the downloaded file.</summary>
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

        /// <summary>Extra HTTP headers to send with the request if the URL uses the HTTP[s] protocol. Each header is represented as a dictionary containing the keys <c>name</c> and either <c>value</c> or <c>binaryValue</c>, restricted to those allowed by XMLHttpRequest.</summary>
        [JsonPropertyName("headers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<HeadersArrayItem> Headers
        {
            get
            {
                InitializeProperty("headers", _headers);
                return _headers;
            }
            set
            {
                _headers = value;
            }
        }

        /// <summary>Whether to associate the download with a private browsing session.</summary>
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Incognito
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

        /// <summary>The HTTP method to use if the URL uses the HTTP[S] protocol.</summary>
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Method
        {
            get
            {
                InitializeProperty("method", _method);
                return _method;
            }
            set
            {
                _method = value;
            }
        }

        /// <summary>Use a file-chooser to allow the user to select a filename. If the option is not specified, the file chooser will be shown only if the Firefox "Always ask you where to save files" option is enabled (i.e. the pref <c>browser.download.useDownloadDir</c> is set to <c>false</c>).</summary>
        [JsonPropertyName("saveAs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? SaveAs
        {
            get
            {
                InitializeProperty("saveAs", _saveAs);
                return _saveAs;
            }
            set
            {
                _saveAs = value;
            }
        }

        /// <summary>The URL to download.</summary>
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
