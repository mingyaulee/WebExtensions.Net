using FluentAssertions;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.Notifications;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.notifications")]
    public class NotificationsTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testNotificationId;

        public NotificationsTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testNotificationId = Guid.NewGuid().ToString();
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var createdNotificationId = await webExtensionsApi.Notifications.Create(testNotificationId, new CreateNotificationOptions()
            {
                Title = "Testing notification",
                Message = "Test notification message",
                Type = TemplateType.Basic,
                IconUrl = "Icon.png"
            });

            // Assert
            createdNotificationId.Should().Be(testNotificationId);
        }

        [Fact(Order = 2)]
        public async Task Update()
        {
            // Act
            var notificationUpdated = await webExtensionsApi.Notifications.Update(testNotificationId, new CreateNotificationOptions()
            {
                Title = "Updated notification",
                Message = "Updated notification message"
            });

            // Assert
            notificationUpdated.Should().BeTrue();
        }

        [Fact(Order = 2)]
        public async Task GetAll()
        {
            // Act
            var notifications = await webExtensionsApi.Notifications.GetAll();

            // Assert
            notifications.EnumerateObject().Should().Contain(property => property.Name == testNotificationId);
        }

        [Fact(Order = 3)]
        public async Task Clear()
        {
            // Act
            var notificationCleared = await webExtensionsApi.Notifications.Clear(testNotificationId);

            // Assert
            notificationCleared.Should().BeTrue();
        }
    }
}
