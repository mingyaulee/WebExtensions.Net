﻿using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.extension API")]
    public class HistoryApiTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
        private readonly string testHistoryUrl = "https://non-existent-url.com/";
        private readonly string testHistorySearchText = "non-existent-url";
        private readonly DateTime testHistoryTime = DateTime.UtcNow;

        [Fact(Order = 1)]
        public async Task AddUrl()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.History.AddUrl(new()
            {
                Url = testHistoryUrl
            });

            // Assert
            await action.ShouldNotThrowAsync();
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
            visits.ShouldNotBeNullOrEmpty();
            ((DateTime)visits.Single().VisitTime).ShouldBeCloseTo(testHistoryTime, precision: TimeSpan.FromSeconds(1));
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
            visits.ShouldNotBeNullOrEmpty();
            visits.ShouldContain(visit => visit.Url == testHistoryUrl);
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
            await action.ShouldNotThrowAsync();
        }
    }
}
