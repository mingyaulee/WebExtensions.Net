using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary>Add, remove or replace query key-value pairs. Cannot be specified if 'query' is specified.</summary>
    [BindAllProperties]
    public partial class QueryTransform : BaseObject
    {
        /// <summary>The list of query key-value pairs to be added or replaced.</summary>
        [JsAccessPath("addOrReplaceParams")]
        [JsonPropertyName("addOrReplaceParams")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<AddOrReplaceParam> AddOrReplaceParams { get; set; }

        /// <summary>The list of query keys to be removed.</summary>
        [JsAccessPath("removeParams")]
        [JsonPropertyName("removeParams")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> RemoveParams { get; set; }
    }
}
