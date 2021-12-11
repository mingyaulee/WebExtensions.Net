using JsBind.Net;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    // Type Class
    /// <summary>Details of a script injection</summary>
    [BindAllProperties]
    public partial class ScriptInjection : BaseObject
    {
        /// <summary>The arguments to curry into a provided function. This is only valid if the <c>func</c> parameter is specified. These arguments must be JSON-serializable.</summary>
        [JsonPropertyName("args")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<object> Args { get; set; }

        /// <summary>The path of the JS or CSS files to inject, relative to the extension's root directory. Exactly one of <c>files</c> and <c>func</c> must be specified.</summary>
        [JsonPropertyName("files")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Files { get; set; }

        /// <summary>A JavaScript function to inject. This function will be serialized, and then deserialized for injection. This means that any bound parameters and execution context will be lost. Exactly one of <c>files</c> and <c>func</c> must be specified.</summary>
        [JsonPropertyName("func")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Action Func { get; set; }

        /// <summary>Details specifying the target into which to inject the script.</summary>
        [JsonPropertyName("target")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public InjectionTarget Target { get; set; }
    }
}
