using JsBind.Net;

namespace WebExtensions.Net.Pkcs11
{
    /// <inheritdoc />
    public partial class Pkcs11Api : BaseApi, IPkcs11Api
    {
        /// <summary>Creates a new instance of <see cref="Pkcs11Api" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public Pkcs11Api(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "pkcs11"))
        {
        }

        /// <inheritdoc />
        public virtual void GetModuleSlots(string name)
            => InvokeVoid("getModuleSlots", name);

        /// <inheritdoc />
        public virtual void InstallModule(string name, int? flags = null)
            => InvokeVoid("installModule", name, flags);

        /// <inheritdoc />
        public virtual void IsModuleInstalled(string name)
            => InvokeVoid("isModuleInstalled", name);

        /// <inheritdoc />
        public virtual void UninstallModule(string name)
            => InvokeVoid("uninstallModule", name);
    }
}
