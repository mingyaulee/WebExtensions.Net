using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary>Describes the type of the Rule.action.redirect.transform property.</summary>
    [BindAllProperties]
    public partial class UrlTransform : BaseObject
    {
        /// <summary>The new fragment for the request. Should be either empty, in which case the existing fragment is cleared; or should begin with '#'.</summary>
        [JsAccessPath("fragment")]
        [JsonPropertyName("fragment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Fragment { get; set; }

        /// <summary>The new host name for the request.</summary>
        [JsAccessPath("host")]
        [JsonPropertyName("host")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Host { get; set; }

        /// <summary>The new password for the request.</summary>
        [JsAccessPath("password")]
        [JsonPropertyName("password")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Password { get; set; }

        /// <summary>The new path for the request. If empty, the existing path is cleared.</summary>
        [JsAccessPath("path")]
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Path { get; set; }

        /// <summary>The new port for the request. If empty, the existing port is cleared.</summary>
        [JsAccessPath("port")]
        [JsonPropertyName("port")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Port { get; set; }

        /// <summary>The new query for the request. Should be either empty, in which case the existing query is cleared; or should begin with '?'. Cannot be specified if 'queryTransform' is specified.</summary>
        [JsAccessPath("query")]
        [JsonPropertyName("query")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Query { get; set; }

        /// <summary>Add, remove or replace query key-value pairs. Cannot be specified if 'query' is specified.</summary>
        [JsAccessPath("queryTransform")]
        [JsonPropertyName("queryTransform")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QueryTransform QueryTransform { get; set; }

        /// <summary>The new scheme for the request.</summary>
        [JsAccessPath("scheme")]
        [JsonPropertyName("scheme")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Scheme? Scheme { get; set; }

        /// <summary>The new username for the request.</summary>
        [JsAccessPath("username")]
        [JsonPropertyName("username")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Username { get; set; }
    }
}
