using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<ResourceType>))]
    public enum ResourceType
    {
        /// <summary>main_frame</summary>
        [EnumValue("main_frame")]
        MainFrame,

        /// <summary>sub_frame</summary>
        [EnumValue("sub_frame")]
        SubFrame,

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
        XmlDtd,

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
        CspReport,

        /// <summary>imageset</summary>
        [EnumValue("imageset")]
        Imageset,

        /// <summary>web_manifest</summary>
        [EnumValue("web_manifest")]
        WebManifest,

        /// <summary>speculative</summary>
        [EnumValue("speculative")]
        Speculative,

        /// <summary>json</summary>
        [EnumValue("json")]
        Json,

        /// <summary>other</summary>
        [EnumValue("other")]
        Other,
    }
}
