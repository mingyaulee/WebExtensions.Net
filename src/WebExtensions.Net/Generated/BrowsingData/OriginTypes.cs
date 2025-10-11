using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowsingData;

// Type Class
/// <summary>An object whose properties specify which origin types ought to be cleared. If this object isn't specified, it defaults to clearing only "unprotected" origins. Please ensure that you <em>really</em> want to remove application data before adding 'protectedWeb' or 'extensions'.</summary>
[BindAllProperties]
public partial class OriginTypes : BaseObject
{
    /// <summary>Extensions and packaged applications a user has installed (be _really_ careful!).</summary>
    [JsAccessPath("extension")]
    [JsonPropertyName("extension")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Extension { get; set; }

    /// <summary>Websites that have been installed as hosted applications (be careful!).</summary>
    [JsAccessPath("protectedWeb")]
    [JsonPropertyName("protectedWeb")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ProtectedWeb { get; set; }

    /// <summary>Normal websites.</summary>
    [JsAccessPath("unprotectedWeb")]
    [JsonPropertyName("unprotectedWeb")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UnprotectedWeb { get; set; }
}
