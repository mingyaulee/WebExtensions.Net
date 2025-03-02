using JsBind.Net;
using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Test
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class PromiseType1 : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("then")]
        [JsonPropertyName("then")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action Then { get; set; }
    }
}
