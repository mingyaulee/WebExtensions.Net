using System.Threading.Tasks;

namespace WebExtensions.Net.Identity
{
    /// <summary>Use the chrome.identity API to get OAuth2 access tokens. </summary>
    public partial interface IIdentityApi
    {
        /// <summary>Generates a redirect URL to be used in |launchWebAuthFlow|.</summary>
        /// <param name="path">The path appended to the end of the generated URL. </param>
        /// <returns></returns>
        ValueTask<string> GetRedirectURL(string path);

        /// <summary>Starts an auth flow at the specified URL.</summary>
        /// <param name="details"></param>
        /// <returns></returns>
        ValueTask<string> LaunchWebAuthFlow(LaunchWebAuthFlowDetails details);
    }
}
