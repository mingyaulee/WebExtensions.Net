using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.permissions API")]
    public class PermissionsApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public PermissionsApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public async Task GetAll()
        {
            // Act
            var permissions = await webExtensionsApi.Permissions.GetAll();

            // Assert
            permissions.ShouldNotBeNull();
            permissions.Permissions.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetSelf()
        {
            // Act
            var containsPermission = await webExtensionsApi.Permissions.Contains(new()
            {
                Permissions =
                [
                    new Permission(new OptionalPermission("alarms")),
                    new Permission(new OptionalPermission("bookmarks")),
                    new Permission(new OptionalPermission("cookies"))
                ]
            });

            // Assert
            containsPermission.ShouldBeTrue();
        }
    }
}
