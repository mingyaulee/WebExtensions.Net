/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    /// Enum Definition
    /// <summary>The format of an image.</summary>
    [JsonConverter(typeof(EnumStringConverter<ImageFormat>))]
    public enum ImageFormat
    {
        [EnumValue("jpeg")]
        Jpeg,
        [EnumValue("png")]
        Png,
    }
}

