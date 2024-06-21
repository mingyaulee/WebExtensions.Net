using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Clipboard
{
    /// <summary>Offers the ability to write to the clipboard. Reading is not supported because the clipboard can already be read through the standard web platform APIs.</summary>
    [JsAccessPath("clipboard")]
    public partial interface IClipboardApi
    {
        /// <summary>Copy an image to the clipboard. The image is re-encoded before it is written to the clipboard. If the image is invalid, the clipboard is not modified.</summary>
        /// <param name="imageData">The image data to be copied.</param>
        /// <param name="imageType">The type of imageData.</param>
        [JsAccessPath("setImageData")]
        ValueTask SetImageData(object imageData, string imageType);
    }
}
