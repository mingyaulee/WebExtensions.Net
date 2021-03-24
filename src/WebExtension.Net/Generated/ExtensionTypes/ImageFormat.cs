// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    // Enum Definition
    /// <summary>
    /// The format of an image.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<ImageFormat>))]
    public enum ImageFormat
    {
        /// <summary>jpeg</summary>
        [EnumValue("jpeg")]
        Jpeg,
        /// <summary>png</summary>
        [EnumValue("png")]
        Png,
    }
}

