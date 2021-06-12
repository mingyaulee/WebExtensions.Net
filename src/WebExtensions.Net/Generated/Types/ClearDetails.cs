using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types
{
    // Type Class
    /// <summary>Which setting to clear.</summary>
    public partial class ClearDetails : BaseObject
    {
        private SettingScope? _scope;

        /// <summary>Where to clear the setting (default: regular).</summary>
        [JsonPropertyName("scope")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SettingScope? Scope
        {
            get
            {
                InitializeProperty("scope", _scope);
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }
    }
}
