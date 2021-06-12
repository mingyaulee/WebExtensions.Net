using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowsingData
{
    // Type Class
    /// <summary>An object whose properties specify which origin types ought to be cleared. If this object isn't specified, it defaults to clearing only "unprotected" origins. Please ensure that you <em>really</em> want to remove application data before adding 'protectedWeb' or 'extensions'.</summary>
    public partial class OriginTypes : BaseObject
    {
        private bool? _extension;
        private bool? _protectedWeb;
        private bool? _unprotectedWeb;

        /// <summary>Extensions and packaged applications a user has installed (be _really_ careful!).</summary>
        [JsonPropertyName("extension")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Extension
        {
            get
            {
                InitializeProperty("extension", _extension);
                return _extension;
            }
            set
            {
                _extension = value;
            }
        }

        /// <summary>Websites that have been installed as hosted applications (be careful!).</summary>
        [JsonPropertyName("protectedWeb")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ProtectedWeb
        {
            get
            {
                InitializeProperty("protectedWeb", _protectedWeb);
                return _protectedWeb;
            }
            set
            {
                _protectedWeb = value;
            }
        }

        /// <summary>Normal websites.</summary>
        [JsonPropertyName("unprotectedWeb")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UnprotectedWeb
        {
            get
            {
                InitializeProperty("unprotectedWeb", _unprotectedWeb);
                return _unprotectedWeb;
            }
            set
            {
                _unprotectedWeb = value;
            }
        }
    }
}
