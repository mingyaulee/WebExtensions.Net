using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowsingData
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Result : BaseObject
    {
        /// <summary>All of the types will be present in the result, with values of <c>true</c> if they are permitted to be removed (e.g., by enterprise policy) and <c>false</c> if not.</summary>
        [JsonPropertyName("dataRemovalPermitted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataTypeSet DataRemovalPermitted { get; set; }

        /// <summary>All of the types will be present in the result, with values of <c>true</c> if they are both selected to be removed and permitted to be removed, otherwise <c>false</c>.</summary>
        [JsonPropertyName("dataToRemove")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataTypeSet DataToRemove { get; set; }

        /// <summary></summary>
        [JsonPropertyName("options")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RemovalOptions Options { get; set; }
    }
}
