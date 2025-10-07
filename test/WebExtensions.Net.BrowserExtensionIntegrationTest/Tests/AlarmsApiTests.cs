using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.alarms API")]
    public class AlarmsApiTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
        private readonly string testAlarmName = Guid.NewGuid().ToString();
        private readonly DateTime testAlarmTime = DateTime.UtcNow.AddMinutes(10);

        [Fact(Order = 1)]
        public void Create()
        {
            // Act
            Action action = () => webExtensionsApi.Alarms.Create(testAlarmName, new()
            {
                When = testAlarmTime
            });

            // Assert
            action.ShouldNotThrow();
        }

        [Fact(Order = 2)]
        public async Task Get()
        {
            // Act
            var alarm = await webExtensionsApi.Alarms.Get(testAlarmName);

            // Assert
            ((DateTime)alarm.ScheduledTime).ShouldBe(testAlarmTime);
        }

        [Fact(Order = 2)]
        public async Task GetAll()
        {
            // Act
            var alarms = await webExtensionsApi.Alarms.GetAll();

            // Assert
            alarms.ShouldContain(alarm => alarm.Name == testAlarmName);
        }

        [Fact(Order = 3)]
        public async Task Clear()
        {
            // Act
            var alarmCleared = await webExtensionsApi.Alarms.Clear(testAlarmName);

            // Assert
            alarmCleared.ShouldBeTrue();
        }

        [Fact(Order = 4)]
        public async Task ClearAll()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Alarms.ClearAll();

            // Assert
            await action.ShouldNotThrowAsync();
        }
    }
}
