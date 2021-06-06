using FluentAssertions;
using System;
using System.Threading.Tasks;
using WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtension.Net.Notifications;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.notifications")]
    public class NotificationsTests
    {
        private readonly IWebExtensionApi webExtensionApi;
        private readonly string testNotificationId;

        public NotificationsTests(IWebExtensionApi webExtensionApi)
        {
            this.webExtensionApi = webExtensionApi;
            testNotificationId = Guid.NewGuid().ToString();
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var createdNotificationId = await webExtensionApi.Notifications.Create(testNotificationId, new CreateNotificationOptions()
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
            var notificationUpdated = await webExtensionApi.Notifications.Update(testNotificationId, new CreateNotificationOptions()
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
            var notifications = await webExtensionApi.Notifications.GetAll();

            // Assert
            notifications.EnumerateObject().Should().Contain(property => property.Name == testNotificationId);
        }

        [Fact(Order = 3)]
        public async Task Clear()
        {
            // Act
            var notificationCleared = await webExtensionApi.Notifications.Clear(testNotificationId);

            // Assert
            notificationCleared.Should().BeTrue();
        }
    }
}
