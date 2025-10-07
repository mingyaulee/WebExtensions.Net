using Microsoft.JSInterop;
using System.Reflection;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Models;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure
{
    public class TestRunner : ITestRunner
    {
        private readonly ITestFactory testFactory;
        private readonly IJSRuntime jsRuntime;
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly DotNetObjectReference<TestRunner> thisRef;
        private readonly Dictionary<Type, object> testClassInstances;

        public TestRunner(ITestFactory testFactory, IJSRuntime jsRuntime, ILogger<TestRunner> logger, IServiceProvider serviceProvider)
        {
            this.testFactory = testFactory;
            this.jsRuntime = jsRuntime;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            thisRef = DotNetObjectReference.Create(this);
            testClassInstances = [];
        }

        public async Task RunTests()
        {
            var tests = testFactory.GetAllTests();
            await jsRuntime.InvokeVoidAsync("TestRunner.Start", thisRef, tests);
        }

        [JSInvokable]
        public async Task<TestResult> RunTest(TestMethodInfo testMethodInfo)
        {
            var result = new TestResult();
            try
            {
                var testClassType = Type.GetType(testMethodInfo.DeclaringTypeFullName);
                if (testClassType is null)
                {
                    throw new NotSupportedException("Test class type should not be null");
                }
                var testClassInstance = GetTestClassInstance(testClassType);
                var methodInfo = testClassType.GetMethod(testMethodInfo.MethodName);
                if (methodInfo is null)
                {
                    throw new NotSupportedException("Test method info should not be null");
                }
                var response = methodInfo.Invoke(testClassInstance, []);
                if (response is Task task)
                {
                    await task;
                }
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.FailMessage = ex.Message;
                result.StackTrace = ex.StackTrace;
                logger.LogError($"Test failed: {testMethodInfo.Description}", ex);
            }
            return result;
        }

        private object GetTestClassInstance(Type testClassType)
        {
            if (testClassInstances.ContainsKey(testClassType))
            {
                return testClassInstances[testClassType];
            }
            var testClassInstance = ActivatorUtilities.CreateInstance(serviceProvider, testClassType);
            testClassInstances.Add(testClassType, testClassInstance);
            return testClassInstance;
        }

        public async Task GetTestCoverageInfo()
        {
            // AppDomain.Unload is not supported, in the case where the extension is running with coverlet, look for the HitsArray static field in WebExtensions.Net
            // This is a hack to get into the module injected by Coverlet
            // Reference: https://github.com/coverlet-coverage/coverlet/blob/master/src/coverlet.core/Instrumentation/ModuleTrackerTemplate.cs
            var webExtensionsAssembly = typeof(WebExtensions.Net.IWebExtensionsApi).Assembly;
            var types = webExtensionsAssembly.GetTypes();
            var coverletType = types.FirstOrDefault(type => type.Namespace?.Contains("Coverlet", StringComparison.OrdinalIgnoreCase) ?? false);
            if (coverletType == null)
            {
                logger.LogError("Failed to get coverlet type.");
                return;
            }
            var hitsArrayField = coverletType.GetField("HitsArray", BindingFlags.Public | BindingFlags.Static);
            if (hitsArrayField == null)
            {
                logger.LogError("Failed to get 'HitsArray' field.");
                return;
            }
            var hitsFilePathField = coverletType.GetField("HitsFilePath", BindingFlags.Public | BindingFlags.Static);
            if (hitsFilePathField == null)
            {
                logger.LogError("Failed to get 'HitsFilePath' field.");
                return;
            }
            var hitsArray = (int[])hitsArrayField.GetValue(null);
            var hitsFilePath = (string)hitsFilePathField.GetValue(null);
            await jsRuntime.InvokeVoidAsync("TestRunner.SetTestCoverage", new
            {
                HitsFilePath = hitsFilePath,
                HitsArray = hitsArray
            });
        }
    }
}
