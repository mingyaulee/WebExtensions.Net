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
    /// 
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<ResourceType>))]
    public enum ResourceType
    {
        /// <summary>main_frame</summary>
        [EnumValue("main_frame")]
        Main_frame,
        /// <summary>sub_frame</summary>
        [EnumValue("sub_frame")]
        Sub_frame,
        /// <summary>stylesheet</summary>
        [EnumValue("stylesheet")]
        Stylesheet,
        /// <summary>script</summary>
        [EnumValue("script")]
        Script,
        /// <summary>image</summary>
        [EnumValue("image")]
        Image,
        /// <summary>object</summary>
        [EnumValue("object")]
        Object,
        /// <summary>object_subrequest</summary>
        [EnumValue("object_subrequest")]
        Object_subrequest,
        /// <summary>xmlhttprequest</summary>
        [EnumValue("xmlhttprequest")]
        Xmlhttprequest,
        /// <summary>xslt</summary>
        [EnumValue("xslt")]
        Xslt,
        /// <summary>ping</summary>
        [EnumValue("ping")]
        Ping,
        /// <summary>beacon</summary>
        [EnumValue("beacon")]
        Beacon,
        /// <summary>xml_dtd</summary>
        [EnumValue("xml_dtd")]
        Xml_dtd,
        /// <summary>font</summary>
        [EnumValue("font")]
        Font,
        /// <summary>media</summary>
        [EnumValue("media")]
        Media,
        /// <summary>websocket</summary>
        [EnumValue("websocket")]
        Websocket,
        /// <summary>csp_report</summary>
        [EnumValue("csp_report")]
        Csp_report,
        /// <summary>imageset</summary>
        [EnumValue("imageset")]
        Imageset,
        /// <summary>web_manifest</summary>
        [EnumValue("web_manifest")]
        Web_manifest,
        /// <summary>speculative</summary>
        [EnumValue("speculative")]
        Speculative,
        /// <summary>other</summary>
        [EnumValue("other")]
        Other,
    }
}

