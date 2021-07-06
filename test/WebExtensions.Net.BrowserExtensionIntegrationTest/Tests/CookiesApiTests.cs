using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.Cookies;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.cookies API")]
    public class CookiesApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testCookieName;
        private readonly string testCookieUrl;
        private readonly string testCookieDomain;
        private readonly string testCookieValue;

        public CookiesApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testCookieName = "TestCookie";
            testCookieUrl = "https://non-existent-domain.com/";
            testCookieDomain = "non-existent-domain.com";
            testCookieValue = Guid.NewGuid().ToString();
        }

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
            cookie.Should().NotBeNull();
            cookie.Domain.Should().Be(testCookieDomain);
            cookie.Value.Should().Be(testCookieValue);
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
            cookie.Should().NotBeNull();
            cookie.Value.Should().Be(testCookieValue);
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
            cookies.Should().NotBeNullOrEmpty();
            cookies.Single(cookie => cookie.Name == testCookieName).Value.Should().Be(testCookieValue);
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
            detail.Should().NotBeNull();
            detail.Name.Should().Be(testCookieName);
        }
    }
}
