using System;
using System.Collections.Generic;
using WebExtensions.Net.Mock.Configurators;
using WebExtensions.Net.Mock.Resolvers;

namespace WebExtensions.Net.Mock
{
    /// <summary>
    /// Mock resolvers.
    /// </summary>
    public static class MockResolvers
    {
        internal static readonly IList<IMockResolver> Resolvers = new List<IMockResolver>()
        {
            new ConfiguredMockResolver(),
            new DefaultMockResolver()
        };

        /// <summary>
        /// Configures the mock resolver.
        /// </summary>
        /// <param name="configureAction">The action for configuration.</param>
        public static void Configure(Action<IMockConfigurator> configureAction)
        {
            ConfiguredMockResolver.AddConfigureAction(configureAction);
        }

        internal static object InvokeApiHandler(string targetPath, object[] arguments)
        {
            foreach (var mockResolver in Resolvers)
            {
                if (mockResolver.TryInvokeApiHandler(targetPath, arguments, out var result))
                {
                    return result;
                }
            }

            return null;
        }

        internal static object InvokeObjectReferenceHandler(object objectReference, string targetPath, object[] arguments)
        {
            foreach (var mockResolver in Resolvers)
            {
                if (mockResolver.TryInvokeObjectReferenceHandler(objectReference, targetPath, arguments, out var result))
                {
                    return result;
                }
            }

            return null;
        }
    }
}
