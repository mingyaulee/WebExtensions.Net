using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.ExtensionTypes;
using WebExtensions.Net.Tabs;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.tabs")]
    public class TabsTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private int? testTabId;
        private readonly string testTabUrl;
        private readonly string testTabUpdateUrl;

        public TabsTests(IWebExtensionsApi webExtensionsApi)
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
            tab.Should().NotBeNull();
            tab.Id.Should().NotBeNull();
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
            accessProperties.Should().NotThrow();
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var tab = await webExtensionsApi.Tabs.Create(new CreateProperties()
            {
                Url = testTabUrl
            });

            // Assert
            tab.Should().NotBeNull();
            tab.Id.Should().HaveValue();
            tab.Id.Should().NotBe(webExtensionsApi.Tabs.TAB_ID_NONE);

            testTabId = tab.Id;
        }

        [Fact(Order = 2)]
        public async Task Get()
        {
            // Act
            var tab = await webExtensionsApi.Tabs.Get(testTabId.Value);
            var attemptCount = 0;
            while (tab.Status != "complete" && attemptCount < 10)
            {
                attemptCount++;
                await Task.Delay(500);
                tab = await webExtensionsApi.Tabs.Get(testTabId.Value);
            }

            // Assert
            tab.Should().NotBeNull();
            tab.Id.Should().Be(testTabId.Value);
            tab.Url.Should().Be(testTabUrl);
            tab.Status.Should().Be("complete");
        }

        [Fact(Order = 2)]
        public async Task Query()
        {
            // Act
            var tabs = await webExtensionsApi.Tabs.Query(new QueryInfo()
            {
                Url = testTabUrl
            });

            // Assert
            tabs.Should().NotBeEmpty();
            tabs.Should().HaveCount(1);
            tabs.Single().Id.Should().Be(testTabId);
        }

        [Fact(Order = 3)]
        public async Task Update()
        {
            // Arrange
            var url = testTabUpdateUrl;

            // Act
            var tab = await webExtensionsApi.Tabs.Update(testTabId.Value, new UpdateProperties()
            {
                Url = url
            });

            // Assert
            tab.Should().NotBeNull();
            tab.Status.Should().Be("loading");
        }

        [Fact(Order = 4)]
        public async Task Remove()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Tabs.Remove(testTabId.Value);

            // Assert
            await action.Should().NotThrowAsync();
        }
    }
}
