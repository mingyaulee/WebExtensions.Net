using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class Options : BaseObject
{
    /// <summary>Include the entire certificate chain.</summary>
    [JsAccessPath("certificateChain")]
    [JsonPropertyName("certificateChain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CertificateChain { get; set; }

    /// <summary>Include raw certificate data for processing by the extension.</summary>
    [JsAccessPath("rawDER")]
    [JsonPropertyName("rawDER")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RawDER { get; set; }
}
