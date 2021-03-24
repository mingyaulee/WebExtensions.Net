using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtension.Net.BrowserExtensionIntegrationTest.Models;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure
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
            testClassInstances = new Dictionary<Type, object>();
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
                    throw new Exception("Test class type should not be null");
                }
                var testClassInstance = GetTestClassInstance(testClassType);
                var methodInfo = testClassType.GetMethod(testMethodInfo.MethodName);
                if (methodInfo is null)
                {
                    throw new Exception("Test method info should not be null");
                }
                var response = methodInfo.Invoke(testClassInstance, Array.Empty<object>());
                if (response is Task task)
                {
                    await task;
                }
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.FailMessage = ex.Message;
                result.StackTrace = GetStackTrace(ex);
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

        private string GetStackTrace(Exception ex)
        {
            if (ex is AssertionFailedException)
            {
                // clear the stack trace from FluentAssertions namespace
                return string.Join(Environment.NewLine, ex.StackTrace.Split(Environment.NewLine).Where(line => !line.Contains($"{nameof(FluentAssertions)}.")));
            }
            return ex.StackTrace;
        }
    }
}
