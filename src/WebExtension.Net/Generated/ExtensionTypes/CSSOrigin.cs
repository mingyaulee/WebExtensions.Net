/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ExtensionTypes
{
    /// Enum Definition
    /// <summary>The origin of the CSS to inject, this affects the cascading order (priority) of the stylesheet.</summary>
    [JsonConverter(typeof(EnumStringConverter<CSSOrigin>))]
    public enum CSSOrigin
    {
        [EnumValue("user")]
        User,
        [EnumValue("author")]
        Author,
    }
}

