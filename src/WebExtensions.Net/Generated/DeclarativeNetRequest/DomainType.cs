using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest;

/// <summary>Specifies whether the network request is first-party or third-party to the domain from which it originated. If omitted, all requests are matched.</summary>
[JsonConverter(typeof(EnumStringConverter<DomainType>))]
public enum DomainType
{
    /// <summary>firstParty</summary>
    [EnumValue("firstParty")]
    FirstParty,

    /// <summary>thirdParty</summary>
    [EnumValue("thirdParty")]
    ThirdParty,
}
