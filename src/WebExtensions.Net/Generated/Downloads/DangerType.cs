using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads;

/// <summary>'dl''dt'file'/dt''dd'The download's filename is suspicious.'/dd''dt'url'/dt''dd'The download's URL is known to be malicious.'/dd''dt'content'/dt''dd'The downloaded file is known to be malicious.'/dd''dt'uncommon'/dt''dd'The download's URL is not commonly downloaded and could be dangerous.'/dd''dt'safe'/dt''dd'The download presents no known danger to the user's computer.'/dd''/dl'These string constants will never change, however the set of DangerTypes may change.</summary>
[JsonConverter(typeof(EnumStringConverter<DangerType>))]
public enum DangerType
{
    /// <summary>file</summary>
    [EnumValue("file")]
    File,

    /// <summary>url</summary>
    [EnumValue("url")]
    Url,

    /// <summary>content</summary>
    [EnumValue("content")]
    Content,

    /// <summary>uncommon</summary>
    [EnumValue("uncommon")]
    Uncommon,

    /// <summary>host</summary>
    [EnumValue("host")]
    Host,

    /// <summary>unwanted</summary>
    [EnumValue("unwanted")]
    Unwanted,

    /// <summary>safe</summary>
    [EnumValue("safe")]
    Safe,

    /// <summary>accepted</summary>
    [EnumValue("accepted")]
    Accepted,
}
