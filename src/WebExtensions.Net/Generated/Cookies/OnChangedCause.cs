using System.Text.Json.Serialization;

namespace WebExtensions.Net.Cookies;

/// <summary>The underlying reason behind the cookie's change. If a cookie was inserted, or removed via an explicit call to $(ref:cookies.remove), "cause" will be "explicit". If a cookie was automatically removed due to expiry, "cause" will be "expired". If a cookie was removed due to being overwritten with an already-expired expiration date, "cause" will be set to "expired_overwrite".  If a cookie was automatically removed due to garbage collection, "cause" will be "evicted".  If a cookie was automatically removed due to a "set" call that overwrote it, "cause" will be "overwrite". Plan your response accordingly.</summary>
[JsonConverter(typeof(EnumStringConverter<OnChangedCause>))]
public enum OnChangedCause
{
    /// <summary>evicted</summary>
    [EnumValue("evicted")]
    Evicted,

    /// <summary>expired</summary>
    [EnumValue("expired")]
    Expired,

    /// <summary>explicit</summary>
    [EnumValue("explicit")]
    Explicit,

    /// <summary>expired_overwrite</summary>
    [EnumValue("expired_overwrite")]
    ExpiredOverwrite,

    /// <summary>overwrite</summary>
    [EnumValue("overwrite")]
    Overwrite,
}
