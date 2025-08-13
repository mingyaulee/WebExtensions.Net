using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.tabs API")]
    public class TabsApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private int? testTabId;
        private readonly string testTabUrl;
        private readonly string testTabUpdateUrl;

        public TabsApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testTabUrl = "https://raw.githubusercontent.com/mingyaulee/WebExtensions.Net/main/README.md?testId=" + Guid.NewGuid().ToString();
            testTabUpdateUrl = testTabUrl + "&update=true";
        }

        [Fact]
        public async Task GetCurrent()
        {
            // Act
            var tab = await webExtensionsApi.Tabs.GetCurrent();

            // Assert
            tab.ShouldNotBeNull();
            tab.Id.ShouldNotBeNull();
        }

        [Fact]
        public async Task AccessAllTabsProperties()
        {
            // Arrange
            var tab = await webExtensionsApi.Tabs.GetCurrent();

            // Act
            Func<object[]> accessProperties = () => new object[]
            {
                tab.Active,
                tab.Attention,
                tab.Audible,
                tab.CookieStoreId,
                tab.Discarded,
                tab.FavIconUrl,
                tab.Height,
                tab.Hidden,
                tab.Highlighted,
                tab.Id,
                tab.Incognito,
                tab.Index,
                tab.IsArticle,
                tab.IsInReaderMode,
                tab.LastAccessed,
                tab.MutedInfo,
                tab.MutedInfo?.ExtensionId,
                tab.MutedInfo?.Muted,
                tab.MutedInfo?.Reason,
                tab.OpenerTabId,
                tab.Pinned,
                tab.SessionId,
                tab.SharingState,
                tab.SharingState?.Camera,
                tab.SharingState?.Microphone,
                tab.SharingState?.Screen,
                tab.Status,
                tab.SuccessorTabId,
                tab.Title,
                tab.Url,
                tab.Width,
                tab.WindowId
            };

            // Assert
            accessProperties.ShouldNotThrow();
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var tab = await webExtensionsApi.Tabs.Create(new()
            {
                Url = testTabUrl
            });

            // Assert
            tab.ShouldNotBeNull();
            tab.Id.ShouldHaveValue();
            tab.Id.ShouldNotBe(webExtensionsApi.Tabs.TAB_ID_NONE);

            testTabId = tab.Id;
        }

        [Fact(Order = 2)]
        public async Task Get()
        {
            // Act
            var tab = await webExtensionsApi.Tabs.Get(testTabId.Value);
            var attemptCount = 0;
            while (tab.Status != TabStatus.Complete && attemptCount < 10)
            {
                attemptCount++;
                await Task.Delay(500);
                tab = await webExtensionsApi.Tabs.Get(testTabId.Value);
            }

            // Assert
            tab.ShouldNotBeNull();
            tab.Id.ShouldBe(testTabId.Value);
            tab.Url.ShouldBe(testTabUrl);
            tab.Status.ShouldBe(TabStatus.Complete);
        }

        [Fact(Order = 2)]
        public async Task Query()
        {
            // Act
            var tabs = await webExtensionsApi.Tabs.Query(new()
            {
                Url = testTabUrl
            });

            // Assert
            tabs.ShouldNotBeNullOrEmpty();
            tabs.ShouldHaveCount(1);
            tabs.Single().Id.ShouldBe(testTabId);
        }

        [Fact(Order = 3)]
        public async Task Update()
        {
            // Arrange
            var url = testTabUpdateUrl;

            // Act
            var tab = await webExtensionsApi.Tabs.Update(testTabId.Value, new()
            {
                Url = url
            });

            // Assert
            tab.ShouldNotBeNull();
            tab.Status.ShouldBe(TabStatus.Loading);
        }

        [Fact(Order = 4)]
        public async Task Remove()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Tabs.Remove(testTabId.Value);

            // Assert
            await action.ShouldNotThrowAsync();
        }
    }
}
