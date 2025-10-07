using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.windows API")]
    public class WindowsApiTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
        private int? testWindowId;

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var window = await webExtensionsApi.Windows.Create(new()
            {
                Url = "https://google.com",
                Top = 0,
                Left = 0
            });

            // Assert
            window.ShouldNotBeNull();
            window.Id.ShouldHaveValue();
            testWindowId = window.Id;
        }

        [Fact(Order = 2)]
        public async Task Get()
        {
            // Act
            var window = await webExtensionsApi.Windows.Get(testWindowId.Value, null);

            // Assert
            window.ShouldNotBeNull();
            window.Id.ShouldBe(testWindowId.Value);
        }

        [Fact(Order = 3)]
        public async Task Update()
        {
            // Arrange
            var windowTop = 50;
            var windowLeft = 100;

            // Act
            var window = await webExtensionsApi.Windows.Update(testWindowId.Value, new()
            {
                Top = windowTop,
                Left = windowLeft
            });

            // Assert
            window.ShouldNotBeNull();
            window.Top.GetValueOrDefault().ShouldBeInRange(windowTop - 5, windowTop + 5);
            window.Left.GetValueOrDefault().ShouldBeInRange(windowLeft - 5, windowLeft + 5);
        }

        [Fact(Order = 4)]
        public async Task Remove()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Windows.Remove(testWindowId.Value);

            // Assert
            await action.ShouldNotThrowAsync();
        }
    }
}
