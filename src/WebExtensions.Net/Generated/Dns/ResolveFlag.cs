using System.Text.Json.Serialization;

namespace WebExtensions.Net.Dns;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<ResolveFlag>))]
public enum ResolveFlag
{
    /// <summary>allow_name_collisions</summary>
    [EnumValue("allow_name_collisions")]
    AllowNameCollisions,

    /// <summary>bypass_cache</summary>
    [EnumValue("bypass_cache")]
    BypassCache,

    /// <summary>canonical_name</summary>
    [EnumValue("canonical_name")]
    CanonicalName,

    /// <summary>disable_ipv4</summary>
    [EnumValue("disable_ipv4")]
    DisableIpv4,

    /// <summary>disable_ipv6</summary>
    [EnumValue("disable_ipv6")]
    DisableIpv6,

    /// <summary>disable_trr</summary>
    [EnumValue("disable_trr")]
    DisableTrr,

    /// <summary>offline</summary>
    [EnumValue("offline")]
    Offline,

    /// <summary>priority_low</summary>
    [EnumValue("priority_low")]
    PriorityLow,

    /// <summary>priority_medium</summary>
    [EnumValue("priority_medium")]
    PriorityMedium,

    /// <summary>speculate</summary>
    [EnumValue("speculate")]
    Speculate,
}
