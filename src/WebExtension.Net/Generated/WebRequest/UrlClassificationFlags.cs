/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// Enum Definition
    /// <summary>Tracking flags that match our internal tracking classification</summary>
    [JsonConverter(typeof(EnumStringConverter<UrlClassificationFlags>))]
    public enum UrlClassificationFlags
    {
        [EnumValue("fingerprinting")]
        Fingerprinting,
        [EnumValue("fingerprinting_content")]
        Fingerprinting_content,
        [EnumValue("cryptomining")]
        Cryptomining,
        [EnumValue("cryptomining_content")]
        Cryptomining_content,
        [EnumValue("tracking")]
        Tracking,
        [EnumValue("tracking_ad")]
        Tracking_ad,
        [EnumValue("tracking_analytics")]
        Tracking_analytics,
        [EnumValue("tracking_social")]
        Tracking_social,
        [EnumValue("tracking_content")]
        Tracking_content,
        [EnumValue("any_basic_tracking")]
        Any_basic_tracking,
        [EnumValue("any_strict_tracking")]
        Any_strict_tracking,
        [EnumValue("any_social_tracking")]
        Any_social_tracking,
    }
}

