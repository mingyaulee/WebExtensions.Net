using JsBind.Net;

namespace WebExtensions.Net.SidebarAction;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class SidebarActionApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "sidebarAction")), ISidebarActionApi
{
    /// <inheritdoc />
    public virtual void Close()
        => InvokeVoid("close");

    /// <inheritdoc />
    public virtual void GetPanel(GetPanelDetails details)
        => InvokeVoid("getPanel", details);

    /// <inheritdoc />
    public virtual void GetTitle(GetTitleDetails details)
        => InvokeVoid("getTitle", details);

    /// <inheritdoc />
    public virtual void IsOpen(IsOpenDetails details)
        => InvokeVoid("isOpen", details);

    /// <inheritdoc />
    public virtual void Open()
        => InvokeVoid("open");

    /// <inheritdoc />
    public virtual void SetIcon(SetIconDetails details)
        => InvokeVoid("setIcon", details);

    /// <inheritdoc />
    public virtual void SetPanel(SetPanelDetails details)
        => InvokeVoid("setPanel", details);

    /// <inheritdoc />
    public virtual void SetTitle(SetTitleDetails details)
        => InvokeVoid("setTitle", details);

    /// <inheritdoc />
    public virtual void Toggle()
        => InvokeVoid("toggle");
}
