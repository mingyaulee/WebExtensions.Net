using System.Threading.Tasks;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure
{
    public interface ITestRunner
    {
        Task RunTests();
        Task GetTestCoverageInfo();
    }
}