using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
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
            commands.Should().HaveCount(1);
            commands.Single().Name.Should().Be(testCommandName);
            commands.Single().Description.Should().Be(testCommandDescription);
        }
    }
}
