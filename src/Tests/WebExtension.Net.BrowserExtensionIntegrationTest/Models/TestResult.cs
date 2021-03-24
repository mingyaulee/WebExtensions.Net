using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Models
{
    public class TestResult
    {
        public bool Success { get; set; }
        public string FailMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
