using Microsoft.JSInterop;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Models;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

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
}
