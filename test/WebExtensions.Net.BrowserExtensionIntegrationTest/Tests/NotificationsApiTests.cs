using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.Notifications;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.notifications API")]
    public class NotificationsApiTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
        private readonly string testNotificationId = Guid.NewGuid().ToString();

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var createdNotificationId = await webExtensionsApi.Notifications.Create(testNotificationId, new()
            {
                Title = "Testing notification",
                Message = "Test notification message",
                Type = TemplateType.Basic,
                IconUrl = "Icon.png"
            });

            // Assert
            createdNotificationId.ShouldBe(testNotificationId);
        }

        [Fact(Order = 2)]
        public async Task Update()
        {
            // Act
            var notificationUpdated = await webExtensionsApi.Notifications.Update(testNotificationId, new()
            {
                Title = "Updated notification",
                Message = "Updated notification message"
            });

            // Assert
            notificationUpdated.ShouldBeTrue();
        }

        [Fact(Order = 2)]
        public async Task GetAll()
        {
            // Act
            var notifications = await webExtensionsApi.Notifications.GetAll();

            // Assert
            notifications.EnumerateObject().ShouldContain(property => property.Name == testNotificationId);
        }

        [Fact(Order = 3)]
        public async Task Clear()
        {
            // Act
            var notificationCleared = await webExtensionsApi.Notifications.Clear(testNotificationId);

            // Assert
            notificationCleared.ShouldBeTrue();
        }
    }
}
