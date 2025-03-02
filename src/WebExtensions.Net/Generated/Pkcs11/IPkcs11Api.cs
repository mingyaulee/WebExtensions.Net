using JsBind.Net;

namespace WebExtensions.Net.Pkcs11
{
    /// <summary>PKCS#11 module management API</summary>
    [JsAccessPath("pkcs11")]
    public partial interface IPkcs11Api
    {
        /// <summary>Enumerate a module's slots, each with their name and whether a token is present</summary>
        /// <param name="name"></param>
        [JsAccessPath("getModuleSlots")]
        void GetModuleSlots(string name);

        /// <summary>Install a PKCS#11 module with a given name</summary>
        /// <param name="name"></param>
        /// <param name="flags"></param>
        [JsAccessPath("installModule")]
        void InstallModule(string name, int? flags = null);

        /// <summary>checks whether a PKCS#11 module, given by name, is installed</summary>
        /// <param name="name"></param>
        [JsAccessPath("isModuleInstalled")]
        void IsModuleInstalled(string name);

        /// <summary>Remove an installed PKCS#11 module from firefox</summary>
        /// <param name="name"></param>
        [JsAccessPath("uninstallModule")]
        void UninstallModule(string name);
    }
}
