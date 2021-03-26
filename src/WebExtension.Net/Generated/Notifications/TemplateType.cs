using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Notifications
{
    // Enum Definition
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<TemplateType>))]
    public enum TemplateType
    {
        /// <summary>basic</summary>
        [EnumValue("basic")]
        Basic,
        /// <summary>image</summary>
        [EnumValue("image")]
        Image,
        /// <summary>list</summary>
        [EnumValue("list")]
        List,
        /// <summary>progress</summary>
        [EnumValue("progress")]
        Progress,
    }
}

