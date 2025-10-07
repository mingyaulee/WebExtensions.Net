using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.idle API")]
    public class IdleApiTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;

        [Fact]
        public async Task QueryState()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Idle.QueryState(60);

            // Assert
            await action.ShouldNotThrowAsync();
        }

        [Fact]
        public void SetDetectionInterval()
        {
            // Act
            Action action = () => webExtensionsApi.Idle.SetDetectionInterval(60);

            // Assert
            action.ShouldNotThrow();
        }
    }
}
