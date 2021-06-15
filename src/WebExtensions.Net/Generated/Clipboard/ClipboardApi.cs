using System.Threading.Tasks;

namespace WebExtensions.Net.Clipboard
{
    /// <inheritdoc />
    public partial class ClipboardApi : BaseApi, IClipboardApi
    {
        /// <summary>Creates a new instance of <see cref="ClipboardApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public ClipboardApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "clipboard")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask SetImageData(object imageData, string imageType)
        {
            return InvokeVoidAsync("setImageData", imageData, imageType);
        }
    }
}
