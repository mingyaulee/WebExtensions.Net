using System.Collections.Generic;
using WebExtension.Net.BrowserExtensionIntegrationTest.Models;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure
{
    public interface ITestFactory
    {
        IEnumerable<TestClassInfo> GetAllTests();
    }
}