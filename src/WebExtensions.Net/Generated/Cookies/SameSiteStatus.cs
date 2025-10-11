using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies;

/// <summary>A cookie's 'SameSite' state (https://tools.ietf.org/html/draft-west-first-party-cookies). 'no_restriction' corresponds to a cookie set without a 'SameSite' attribute, 'lax' to 'SameSite=Lax', and 'strict' to 'SameSite=Strict'.</summary>
[JsonConverter(typeof(EnumStringConverter<SameSiteStatus>))]
public enum SameSiteStatus
{
    /// <summary>unspecified</summary>
    [EnumValue("unspecified")]
    Unspecified,

    /// <summary>no_restriction</summary>
    [EnumValue("no_restriction")]
    NoRestriction,

    /// <summary>lax</summary>
    [EnumValue("lax")]
    Lax,

    /// <summary>strict</summary>
    [EnumValue("strict")]
    Strict,
}
