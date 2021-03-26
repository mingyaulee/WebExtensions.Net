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

