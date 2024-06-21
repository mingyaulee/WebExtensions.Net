using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Services
{
    /// <summary>Use the <c>browser.privacy</c> API to control usage of the features in the browser that can affect a user's privacy.</summary>
    [JsAccessPath("services")]
    public partial interface IServicesApi
    {
        /// <summary>If enabled, the password manager will ask if you want to save passwords. This preference's value is a boolean, defaulting to <c>true</c>.</summary>
        [JsAccessPath("passwordSavingEnabled")]
        Setting PasswordSavingEnabled { get; }
    }
}
