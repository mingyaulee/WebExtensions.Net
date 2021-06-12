using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowsingData
{
    // Type Class
    /// <summary></summary>
    public partial class Result : BaseObject
    {
        private DataTypeSet _dataRemovalPermitted;
        private DataTypeSet _dataToRemove;
        private RemovalOptions _options;

        /// <summary>All of the types will be present in the result, with values of <c>true</c> if they are permitted to be removed (e.g., by enterprise policy) and <c>false</c> if not.</summary>
        [JsonPropertyName("dataRemovalPermitted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataTypeSet DataRemovalPermitted
        {
            get
            {
                InitializeProperty("dataRemovalPermitted", _dataRemovalPermitted);
                return _dataRemovalPermitted;
            }
            set
            {
                _dataRemovalPermitted = value;
            }
        }

        /// <summary>All of the types will be present in the result, with values of <c>true</c> if they are both selected to be removed and permitted to be removed, otherwise <c>false</c>.</summary>
        [JsonPropertyName("dataToRemove")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataTypeSet DataToRemove
        {
            get
            {
                InitializeProperty("dataToRemove", _dataToRemove);
                return _dataToRemove;
            }
            set
            {
                _dataToRemove = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("options")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RemovalOptions Options
        {
            get
            {
                InitializeProperty("options", _options);
                return _options;
            }
            set
            {
                _options = value;
            }
        }
    }
}
