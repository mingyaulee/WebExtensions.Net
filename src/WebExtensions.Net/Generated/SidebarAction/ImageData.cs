using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction
{
    // Multitype Class
    /// <summary>Either an ImageData object or a dictionary {size -> ImageData} representing icon to be set. If the icon is specified as a dictionary, the actual image to be used is chosen depending on screen's pixel density. If the number of image pixels that fit into one screen space unit equals <c>scale</c>, then image with size <c>scale</c> * 19 will be selected. Initially only scales 1 and 2 will be supported. At least one image must be specified. Note that 'details.imageData = foo' is equivalent to 'details.imageData = {'19': foo}'</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<ImageData>))]
    public partial class ImageData : BaseMultiTypeObject
    {
        private readonly ImageDataType valueImageDataType;

        /// <summary>Creates a new instance of <see cref="ImageData" />.</summary>
        /// <param name="value">The value.</param>
        public ImageData(ImageDataType value) : base(value, typeof(ImageDataType))
        {
            valueImageDataType = value;
        }

        /// <summary>Creates a new instance of <see cref="ImageData" />.</summary>
        /// <param name="value">The value.</param>
        public ImageData(object value) : base(value, typeof(object))
        {
        }

        /// <summary>Converts from <see cref="ImageData" /> to <see cref="ImageDataType" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ImageDataType(ImageData value) => value.valueImageDataType;

        /// <summary>Converts from <see cref="ImageDataType" /> to <see cref="ImageData" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator ImageData(ImageDataType value) => new(value);
    }
}
