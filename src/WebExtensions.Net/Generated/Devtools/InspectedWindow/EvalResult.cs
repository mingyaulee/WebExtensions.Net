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
        private JsonElement _result;
        private ExceptionInfo _exceptionInfo;

        /// <summary>Creates a new instance of <see cref="EvalResult" />.</summary>
        public EvalResult() : base(propertyTypes, propertyNames)
        {
        }

        /// <summary>The result of evaluation.</summary>
        [JsonPropertyName("result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement Result
        {
            get
            {
                InitializeProperty("result", _result);
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        /// <summary>An object providing details if an exception occurred while evaluating the expression.</summary>
        [JsonPropertyName("exceptionInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExceptionInfo ExceptionInfo
        {
            get
            {
                InitializeProperty("exceptionInfo", _exceptionInfo);
                return _exceptionInfo;
            }
            set
            {
                _exceptionInfo = value;
            }
        }
    }
}
