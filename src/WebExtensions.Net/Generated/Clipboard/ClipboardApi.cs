using JsBind.Net;

namespace WebExtensions.Net.Clipboard
{
    /// <inheritdoc />
    public partial class ClipboardApi : BaseApi, IClipboardApi
    {
        /// <summary>Creates a new instance of <see cref="ClipboardApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ClipboardApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "clipboard"))
        {
        }

        /// <inheritdoc />
        public virtual void SetImageData(object imageData, string imageType)
            => InvokeVoid("setImageData", imageData, imageType);
    }
}
