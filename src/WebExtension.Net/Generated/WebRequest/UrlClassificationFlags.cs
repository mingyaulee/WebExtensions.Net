// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Enum Definition
    /// <summary>
    /// Tracking flags that match our internal tracking classification
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<UrlClassificationFlags>))]
    public enum UrlClassificationFlags
    {
        /// <summary>fingerprinting</summary>
        [EnumValue("fingerprinting")]
        Fingerprinting,
        /// <summary>fingerprinting_content</summary>
        [EnumValue("fingerprinting_content")]
        Fingerprinting_content,
        /// <summary>cryptomining</summary>
        [EnumValue("cryptomining")]
        Cryptomining,
        /// <summary>cryptomining_content</summary>
        [EnumValue("cryptomining_content")]
        Cryptomining_content,
        /// <summary>tracking</summary>
        [EnumValue("tracking")]
        Tracking,
        /// <summary>tracking_ad</summary>
        [EnumValue("tracking_ad")]
        Tracking_ad,
        /// <summary>tracking_analytics</summary>
        [EnumValue("tracking_analytics")]
        Tracking_analytics,
        /// <summary>tracking_social</summary>
        [EnumValue("tracking_social")]
        Tracking_social,
        /// <summary>tracking_content</summary>
        [EnumValue("tracking_content")]
        Tracking_content,
        /// <summary>any_basic_tracking</summary>
        [EnumValue("any_basic_tracking")]
        Any_basic_tracking,
        /// <summary>any_strict_tracking</summary>
        [EnumValue("any_strict_tracking")]
        Any_strict_tracking,
        /// <summary>any_social_tracking</summary>
        [EnumValue("any_social_tracking")]
        Any_social_tracking,
    }
}

