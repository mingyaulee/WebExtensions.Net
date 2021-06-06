using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary>Lists the changes to the state of the tab that was updated.</summary>
    public class HasListenerCallbackChangeInfo : BaseObject
    {
        private bool? _attention;
        private bool? _audible;
        private bool? _discarded;
        private string _favIconUrl;
        private bool? _hidden;
        private bool? _isArticle;
        private MutedInfo _mutedInfo;
        private bool? _pinned;
        private SharingState _sharingState;
        private string _status;
        private string _title;
        private string _url;

        /// <summary>The tab's new attention state.</summary>
        [JsonPropertyName("attention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Attention
        {
            get
            {
                InitializeProperty("attention", _attention);
                return _attention;
            }
            set
            {
                _attention = value;
            }
        }

        /// <summary>The tab's new audible state.</summary>
        [JsonPropertyName("audible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Audible
        {
            get
            {
                InitializeProperty("audible", _audible);
                return _audible;
            }
            set
            {
                _audible = value;
            }
        }

        /// <summary>True while the tab is not loaded with content.</summary>
        [JsonPropertyName("discarded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Discarded
        {
            get
            {
                InitializeProperty("discarded", _discarded);
                return _discarded;
            }
            set
            {
                _discarded = value;
            }
        }

        /// <summary>The tab's new favicon URL. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("favIconUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FavIconUrl
        {
            get
            {
                InitializeProperty("favIconUrl", _favIconUrl);
                return _favIconUrl;
            }
            set
            {
                _favIconUrl = value;
            }
        }

        /// <summary>The tab's new hidden state.</summary>
        [JsonPropertyName("hidden")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden
        {
            get
            {
                InitializeProperty("hidden", _hidden);
                return _hidden;
            }
            set
            {
                _hidden = value;
            }
        }

        /// <summary>Whether the document in the tab can be rendered in reader mode.</summary>
        [JsonPropertyName("isArticle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsArticle
        {
            get
            {
                InitializeProperty("isArticle", _isArticle);
                return _isArticle;
            }
            set
            {
                _isArticle = value;
            }
        }

        /// <summary>The tab's new muted state and the reason for the change.</summary>
        [JsonPropertyName("mutedInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MutedInfo MutedInfo
        {
            get
            {
                InitializeProperty("mutedInfo", _mutedInfo);
                return _mutedInfo;
            }
            set
            {
                _mutedInfo = value;
            }
        }

        /// <summary>The tab's new pinned state.</summary>
        [JsonPropertyName("pinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned
        {
            get
            {
                InitializeProperty("pinned", _pinned);
                return _pinned;
            }
            set
            {
                _pinned = value;
            }
        }

        /// <summary>The tab's new sharing state for screen, microphone and camera.</summary>
        [JsonPropertyName("sharingState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SharingState SharingState
        {
            get
            {
                InitializeProperty("sharingState", _sharingState);
                return _sharingState;
            }
            set
            {
                _sharingState = value;
            }
        }

        /// <summary>The status of the tab. Can be either <em>loading</em> or <em>complete</em>.</summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Status
        {
            get
            {
                InitializeProperty("status", _status);
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        /// <summary>The title of the tab if it has changed. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>The tab's URL if it has changed. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
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
