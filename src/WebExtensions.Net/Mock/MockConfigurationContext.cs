using System;
using WebExtension.Net.Mock.Configurators;
using WebExtension.Net.Mock.Resolvers;

namespace WebExtension.Net.Mock
{
    internal static class MockConfigurationContext
    {
        private static bool hasContext;
        private static string apiTargetPath;
        private static object objectReference;
        private static string objectReferenceTargetPath;

        public static bool IsConfiguring { get; private set; }
        public static bool IsConfigured { get; private set; }

        public static void Configure()
        {
            IsConfiguring = true;
            IsConfigured = false;

            var webExtensionApi = new WebExtensionApi(new MockWebExtensionJSRuntime());
            var configurator = new MockConfigurator(webExtensionApi);
            DefaultMockResolver.Configure(configurator);
            ConfiguredMockResolver.Configure(configurator);

            IsConfiguring = false;
            IsConfigured = true;
        }

        public static void ApiInvoked(string targetPath)
        {
            if (hasContext)
            {
                throw new InvalidOperationException("Invalid mock configuration.");
            }

            ResetContext();
            hasContext = true;
            apiTargetPath = targetPath;
        }

        public static void ObjectReferenceInvoked(object obj, string targetPath)
        {
            if (hasContext)
            {
                throw new InvalidOperationException("Invalid mock configuration.");
            }

            ResetContext();
            hasContext = true;
            objectReference = obj;
            objectReferenceTargetPath = targetPath;
        }

        public static bool TryGetApiInvoked(out string targetPath)
        {
            targetPath = apiTargetPath;

            if (hasContext && apiTargetPath is not null)
            {
                ResetContext();
                return true;
            }

            return false;
        }

        public static bool TryGetObjectReferenceInvoked(out object obj, out string targetPath)
        {
            obj = objectReference;
            targetPath = objectReferenceTargetPath;

            if (hasContext && objectReference is not null && objectReferenceTargetPath is not null)
            {
                ResetContext();
                return true;
            }

            return false;
        }

        public static void ResetContext()
        {
            hasContext = false;
            apiTargetPath = null;
            objectReference = null;
            objectReferenceTargetPath = null;
        }
    }
}
