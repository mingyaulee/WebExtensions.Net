using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.History;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.extension API")]
    public class HistoryApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testHistoryUrl;
        private readonly string testHistorySearchText;
        private readonly DateTime testHistoryTime;

        public HistoryApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testHistoryUrl = "https://non-existent-url.com/";
            testHistorySearchText = "non-existent-url";
            testHistoryTime = DateTime.UtcNow;
        }

        [Fact(Order = 1)]
        public async Task AddUrl()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.History.AddUrl(new()
            {
                Url = testHistoryUrl
            });

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Order = 2)]
        public async Task GetVisits()
        {
            // Act
            var visits = await webExtensionsApi.History.GetVisits(new()
            {
                Url = testHistoryUrl
            });

            // Assert
            visits.Should().NotBeNullOrEmpty();
            ((DateTime)visits.Single().VisitTime).Should().BeCloseTo(testHistoryTime, precision: 1000);
        }

        [Fact(Order = 2)]
        public async Task Search()
        {
            // Act
            var visits = await webExtensionsApi.History.Search(new()
            {
                Text = testHistorySearchText,
                StartTime = testHistoryTime.AddMinutes(-1),
                EndTime = testHistoryTime.AddMinutes(1)
            });

            // Assert
            visits.Should().NotBeNullOrEmpty();
            visits.Should().Contain(visit => visit.Url == testHistoryUrl);
        }

        [Fact(Order = 3)]
        public async Task DeleteUrl()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.History.DeleteUrl(new()
            {
                Url = testHistoryUrl
            });

            // Assert
            await action.Should().NotThrowAsync();
        }
    }
}
