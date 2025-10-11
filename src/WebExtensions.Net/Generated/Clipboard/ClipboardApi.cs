using JsBind.Net;

namespace WebExtensions.Net.Clipboard;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class ClipboardApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "clipboard")), IClipboardApi
{
    /// <inheritdoc />
    public virtual void SetImageData(object imageData, ImageType imageType)
        => InvokeVoid("setImageData", imageData, imageType);
}
