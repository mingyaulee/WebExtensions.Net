using Shouldly;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.commands API")]
    public class CommandsApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testCommandName;
        private readonly string testCommandDescription;

        public CommandsApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testCommandName = "dummy-command";
            testCommandDescription = "This is a dummy command";
        }

        [Fact]
        public async Task GetAll()
        {
            // Act
            var commands = await webExtensionsApi.Commands.GetAll();

            // Assert
            commands.ShouldHaveCount(1);
            commands.Single().Name.ShouldBe(testCommandName);
            commands.Single().Description.ShouldBe(testCommandDescription);
        }
    }
}
