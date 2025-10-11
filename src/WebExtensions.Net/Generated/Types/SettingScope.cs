using System.Text.Json.Serialization;

namespace WebExtensions.Net.Types;

/// <summary>The scope of the Setting. One of'ul''li'<c>regular</c>: setting for the regular profile (which is inherited by the incognito profile if not overridden elsewhere),'/li''li'<c>regular_only</c>: setting for the regular profile only (not inherited by the incognito profile),'/li''li'<c>incognito_persistent</c>: setting for the incognito profile that survives browser restarts (overrides regular preferences),'/li''li'<c>incognito_session_only</c>: setting for the incognito profile that can only be set during an incognito session and is deleted when the incognito session ends (overrides regular and incognito_persistent preferences).'/li''/ul' Only <c>regular</c> is supported by Firefox at this time.</summary>
[JsonConverter(typeof(EnumStringConverter<SettingScope>))]
public enum SettingScope
{
    /// <summary>regular</summary>
    [EnumValue("regular")]
    Regular,

    /// <summary>regular_only</summary>
    [EnumValue("regular_only")]
    RegularOnly,

    /// <summary>incognito_persistent</summary>
    [EnumValue("incognito_persistent")]
    IncognitoPersistent,

    /// <summary>incognito_session_only</summary>
    [EnumValue("incognito_session_only")]
    IncognitoSessionOnly,
}
