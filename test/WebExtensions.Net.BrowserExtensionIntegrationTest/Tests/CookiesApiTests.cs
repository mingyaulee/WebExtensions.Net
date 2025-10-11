using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests;

[TestClass(Description = "browser.cookies API")]
public class CookiesApiTests(IWebExtensionsApi webExtensionsApi)
{
    private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
    private readonly string testCookieName = "TestCookie";
    private readonly string testCookieUrl = "https://non-existent-domain.com/";
    private readonly string testCookieDomain = "non-existent-domain.com";
    private readonly string testCookieValue = Guid.NewGuid().ToString();

    [Fact(Order = 1)]
    public async Task Set()
    {
        // Act
        var cookie = await webExtensionsApi.Cookies.Set(new()
        {
            Name = testCookieName,
            Url = testCookieUrl,
            Secure = true,
            Value = testCookieValue
        });

        // Assert
        cookie.ShouldNotBeNull();
        cookie.Domain.ShouldBe(testCookieDomain);
        cookie.Value.ShouldBe(testCookieValue);
    }

    [Fact(Order = 2)]
    public async Task Get()
    {
        // Act
        var cookie = await webExtensionsApi.Cookies.Get(new()
        {
            Name = testCookieName,
            Url = testCookieUrl
        });

        // Assert
        cookie.ShouldNotBeNull();
        cookie.Value.ShouldBe(testCookieValue);
    }

    [Fact(Order = 2)]
    public async Task GetAll()
    {
        // Act
        var cookies = await webExtensionsApi.Cookies.GetAll(new()
        {
            Url = testCookieUrl
        });

        // Assert
        cookies.ShouldNotBeNullOrEmpty();
        cookies.Single(cookie => cookie.Name == testCookieName).Value.ShouldBe(testCookieValue);
    }

    [Fact(Order = 3)]
    public async Task Remove()
    {
        // Act
        var detail = await webExtensionsApi.Cookies.Remove(new()
        {
            Name = testCookieName,
            Url = testCookieUrl
        });

        // Assert
        detail.ShouldNotBeNull();
        detail.Name.ShouldBe(testCookieName);
    }
}
