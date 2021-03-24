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
        private readonly IWebExtensionAPI webExtensionApi;
        private readonly string notificationId;

        public NotificationsTests(IWebExtensionAPI webExtensionApi)
        {
            this.webExtensionApi = webExtensionApi;
            notificationId = Guid.NewGuid().ToString();
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var createdNotificationId = await webExtensionApi.Notifications.Create(notificationId, new CreateNotificationOptions()
            {
                Title = "Testing notification",
                Message = "Test notification message",
                Type = TemplateType.Basic,
                IconUrl = "Icon.png"
            });

            // Assert
            createdNotificationId.Should().Be(notificationId);
        }

        [Fact(Order = 2)]
        public async Task GetAll()
        {
            // Act
            var notifications = await webExtensionApi.Notifications.GetAll();

            // Assert
            notifications.EnumerateObject().Should().Contain(property => property.Name == notificationId);
        }

        [Fact(Order = 3)]
        public async Task Clear()
        {
            // Act
            var notificationCleared = await webExtensionApi.Notifications.Clear(notificationId);

            // Assert
            notificationCleared.Should().BeTrue();
        }
    }
}
