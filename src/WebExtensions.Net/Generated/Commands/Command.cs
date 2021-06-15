using System.Text.Json.Serialization;

namespace WebExtensions.Net.Commands
{
    // Type Class
    /// <summary></summary>
    public partial class Command : BaseObject
    {
        private string _description;
        private string _name;
        private string _shortcut;

        /// <summary>The Extension Command description</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description
        {
            get
            {
                InitializeProperty("description", _description);
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>The name of the Extension Command</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>The shortcut active for this command, or blank if not active.</summary>
        [JsonPropertyName("shortcut")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Shortcut
        {
            get
            {
                InitializeProperty("shortcut", _shortcut);
                return _shortcut;
            }
            set
            {
                _shortcut = value;
            }
        }
    }
}
