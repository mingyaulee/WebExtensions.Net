using JsBind.Net;

namespace WebExtensions.Net.SidebarAction
{
    /// <inheritdoc />
    public partial class SidebarActionApi : BaseApi, ISidebarActionApi
    {
        /// <summary>Creates a new instance of <see cref="SidebarActionApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public SidebarActionApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "sidebarAction"))
        {
        }

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
}
