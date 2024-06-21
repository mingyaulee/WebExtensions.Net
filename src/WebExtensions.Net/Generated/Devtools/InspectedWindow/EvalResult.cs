using JsBind.Net;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Devtools.InspectedWindow
{
    // Combined Callback Parameter Class
    /// <summary></summary>
    [JsonConverter(typeof(CombinedCallbackParameterJsonConverter<EvalResult>))]
    public partial class EvalResult : BaseCombinedCallbackParameterObject
    {
        private static readonly Type[] propertyTypes = new[] { typeof(JsonElement), typeof(ExceptionInfo) };
        private static readonly string[] propertyNames = new[] { "Result", "ExceptionInfo" };

        /// <summary>Creates a new instance of <see cref="EvalResult" />.</summary>
        public EvalResult() : base(propertyTypes, propertyNames)
        {
        }

        /// <summary>The result of evaluation.</summary>
        [JsAccessPath("result")]
        [JsonPropertyName("result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement Result { get; set; }

        /// <summary>An object providing details if an exception occurred while evaluating the expression.</summary>
        [JsAccessPath("exceptionInfo")]
        [JsonPropertyName("exceptionInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExceptionInfo ExceptionInfo { get; set; }
    }
}
