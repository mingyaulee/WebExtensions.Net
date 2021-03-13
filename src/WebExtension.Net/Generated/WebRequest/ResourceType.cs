/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// Enum Definition
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<ResourceType>))]
    public enum ResourceType
    {
        [EnumValue("main_frame")]
        Main_frame,
        [EnumValue("sub_frame")]
        Sub_frame,
        [EnumValue("stylesheet")]
        Stylesheet,
        [EnumValue("script")]
        Script,
        [EnumValue("image")]
        Image,
        [EnumValue("object")]
        Object,
        [EnumValue("object_subrequest")]
        Object_subrequest,
        [EnumValue("xmlhttprequest")]
        Xmlhttprequest,
        [EnumValue("xslt")]
        Xslt,
        [EnumValue("ping")]
        Ping,
        [EnumValue("beacon")]
        Beacon,
        [EnumValue("xml_dtd")]
        Xml_dtd,
        [EnumValue("font")]
        Font,
        [EnumValue("media")]
        Media,
        [EnumValue("websocket")]
        Websocket,
        [EnumValue("csp_report")]
        Csp_report,
        [EnumValue("imageset")]
        Imageset,
        [EnumValue("web_manifest")]
        Web_manifest,
        [EnumValue("speculative")]
        Speculative,
        [EnumValue("other")]
        Other,
    }
}

