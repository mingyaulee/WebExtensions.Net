using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest;

/// <summary>Tracking flags that match our internal tracking classification</summary>
[JsonConverter(typeof(EnumStringConverter<UrlClassificationFlagTypes>))]
public enum UrlClassificationFlagTypes
{
    /// <summary>fingerprinting</summary>
    [EnumValue("fingerprinting")]
    Fingerprinting,

    /// <summary>fingerprinting_content</summary>
    [EnumValue("fingerprinting_content")]
    FingerprintingContent,

    /// <summary>cryptomining</summary>
    [EnumValue("cryptomining")]
    Cryptomining,

    /// <summary>cryptomining_content</summary>
    [EnumValue("cryptomining_content")]
    CryptominingContent,

    /// <summary>emailtracking</summary>
    [EnumValue("emailtracking")]
    Emailtracking,

    /// <summary>emailtracking_content</summary>
    [EnumValue("emailtracking_content")]
    EmailtrackingContent,

    /// <summary>tracking</summary>
    [EnumValue("tracking")]
    Tracking,

    /// <summary>tracking_ad</summary>
    [EnumValue("tracking_ad")]
    TrackingAd,

    /// <summary>tracking_analytics</summary>
    [EnumValue("tracking_analytics")]
    TrackingAnalytics,

    /// <summary>tracking_social</summary>
    [EnumValue("tracking_social")]
    TrackingSocial,

    /// <summary>tracking_content</summary>
    [EnumValue("tracking_content")]
    TrackingContent,

    /// <summary>any_basic_tracking</summary>
    [EnumValue("any_basic_tracking")]
    AnyBasicTracking,

    /// <summary>any_strict_tracking</summary>
    [EnumValue("any_strict_tracking")]
    AnyStrictTracking,

    /// <summary>any_social_tracking</summary>
    [EnumValue("any_social_tracking")]
    AnySocialTracking,

    /// <summary>consentmanager</summary>
    [EnumValue("consentmanager")]
    Consentmanager,

    /// <summary>antifraud</summary>
    [EnumValue("antifraud")]
    Antifraud,
}
