using System.Threading.Tasks;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure
{
    public interface ITestRunner
    {
        Task RunTests();
        Task GetTestCoverageInfo();
    }
}