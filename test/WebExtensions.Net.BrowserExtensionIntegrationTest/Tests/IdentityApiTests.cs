using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests;

[TestClass(Description = "browser.identity API")]
public class IdentityApiTests(IWebExtensionsApi webExtensionsApi)
{
    private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
    private readonly string testIdentityRedirectUrl = "https://non-existent-url.com";

    [Fact]
    public void GetRedirectURL()
    {
        // Act
        var result = webExtensionsApi.Identity.GetRedirectURL(testIdentityRedirectUrl);

        // Assert
        result.ShouldNotBeNull();
    }
}
