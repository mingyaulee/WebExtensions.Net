using System.Collections.Generic;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Models
{
    public class TestClassInfo
    {
        public string Description { get; set; }
        public string FullName { get; set; }
        public IEnumerable<TestMethodInfo> TestMethods { get; set; }
    }
}
