using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<AdditionalBackgroundsAlignmentArrayItem>))]
    public enum AdditionalBackgroundsAlignmentArrayItem
    {
        /// <summary>bottom</summary>
        [EnumValue("bottom")]
        Bottom,

        /// <summary>center</summary>
        [EnumValue("center")]
        Center,

        /// <summary>left</summary>
        [EnumValue("left")]
        Left,

        /// <summary>right</summary>
        [EnumValue("right")]
        Right,

        /// <summary>top</summary>
        [EnumValue("top")]
        Top,

        /// <summary>center bottom</summary>
        [EnumValue("center bottom")]
        CenterBottom,

        /// <summary>center center</summary>
        [EnumValue("center center")]
        CenterCenter,

        /// <summary>center top</summary>
        [EnumValue("center top")]
        CenterTop,

        /// <summary>left bottom</summary>
        [EnumValue("left bottom")]
        LeftBottom,

        /// <summary>left center</summary>
        [EnumValue("left center")]
        LeftCenter,

        /// <summary>left top</summary>
        [EnumValue("left top")]
        LeftTop,

        /// <summary>right bottom</summary>
        [EnumValue("right bottom")]
        RightBottom,

        /// <summary>right center</summary>
        [EnumValue("right center")]
        RightCenter,

        /// <summary>right top</summary>
        [EnumValue("right top")]
        RightTop,
    }
}
