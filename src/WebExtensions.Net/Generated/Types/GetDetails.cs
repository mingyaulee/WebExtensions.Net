using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types
{
    // Type Class
    /// <summary>Which setting to consider.</summary>
    public partial class GetDetails : BaseObject
    {
        private bool? _incognito;

        /// <summary>Whether to return the value that applies to the incognito session (default false).</summary>
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
    }
}
