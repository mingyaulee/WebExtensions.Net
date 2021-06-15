using System.Text.Json.Serialization;

namespace WebExtensions.Net.Commands
{
    // Type Class
    /// <summary>The new description for the command.</summary>
    public partial class Detail : BaseObject
    {
        private string _description;
        private string _name;
        private string _shortcut;

        /// <summary>The new description for the command.</summary>
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

        /// <summary>The name of the command.</summary>
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

        /// <summary></summary>
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
