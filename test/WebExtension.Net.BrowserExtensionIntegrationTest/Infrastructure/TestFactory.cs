using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebExtension.Net.BrowserExtensionIntegrationTest.Models;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure
{
    public class TestFactory : ITestFactory
    {
        public IEnumerable<TestClassInfo> GetAllTests()
        {
            var testNamespace = GetTestNamespace();
            var testTypes = GetTestAssembly().GetTypes().Where(type => type.Namespace != null && type.Namespace.Contains(testNamespace));
            return testTypes.Select(GetTestClassInfoFromType).Where(classInfo => classInfo != null).ToArray();
        }

        private static string GetTestNamespace()
        {
            return "WebExtension.Net.BrowserExtensionIntegrationTest.Tests";
        }

        private static Assembly GetTestAssembly()
        {
            return typeof(TestFactory).Assembly;
        }

        private TestClassInfo GetTestClassInfoFromType(Type type)
        {
            var testClassAttribute = type.GetCustomAttribute<TestClassAttribute>();
            if (testClassAttribute == null)
            {
                return null;
            }

            return new TestClassInfo()
            {
                Description = testClassAttribute.Description ?? type.Name,
                FullName = type.FullName,
                TestMethods = type.GetMethods().Select(GetTestMethodFromMethodInfo).Where(methodInfo => methodInfo != null).OrderBy(methodInfo => methodInfo.Order).ToArray()
            };
        }

        private TestMethodInfo GetTestMethodFromMethodInfo(MethodInfo methodInfo)
        {
            var factAttribute = methodInfo.GetCustomAttribute<FactAttribute>();
            if (factAttribute is null)
            {
                return null;
            }

            return new TestMethodInfo()
            {
                Order = factAttribute.Order == -1 ? 100 : factAttribute.Order,
                Description = factAttribute.Description ?? methodInfo.Name,
                Skip = factAttribute.Skip,
                MethodName = methodInfo.Name,
                DeclaringTypeFullName = methodInfo.DeclaringType.FullName
            };
        }
    }
}
