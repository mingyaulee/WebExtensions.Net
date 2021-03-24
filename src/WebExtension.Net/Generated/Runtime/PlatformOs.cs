// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Enum Definition
    /// <summary>
    /// The operating system the browser is running on.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<PlatformOs>))]
    public enum PlatformOs
    {
        /// <summary>mac</summary>
        [EnumValue("mac")]
        Mac,
        /// <summary>win</summary>
        [EnumValue("win")]
        Win,
        /// <summary>android</summary>
        [EnumValue("android")]
        Android,
        /// <summary>cros</summary>
        [EnumValue("cros")]
        Cros,
        /// <summary>linux</summary>
        [EnumValue("linux")]
        Linux,
        /// <summary>openbsd</summary>
        [EnumValue("openbsd")]
        Openbsd,
    }
}

