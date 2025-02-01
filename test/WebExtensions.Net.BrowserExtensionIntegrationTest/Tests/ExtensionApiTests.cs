using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.extension API")]
    public class ExtensionApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public ExtensionApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public void GetInIncognitoContext()
        {
            // Act
            var inIncognitoContext = webExtensionsApi.Extension.InIncognitoContext;

            // Assert
            inIncognitoContext.ShouldBeFalse();
        }

        [Fact]
        public async Task IsAllowedFileSchemeAccess()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Extension.IsAllowedFileSchemeAccess();

            // Assert
            await action.ShouldNotThrowAsync();
        }

        [Fact]
        public async Task IsAllowedIncognitoAccesss()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Extension.IsAllowedIncognitoAccess();

            // Assert
            await action.ShouldNotThrowAsync();
        }
    }
}
