using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebExtension.Net.Mock.Handlers;
using WebExtension.Net.Mock.Resolvers;

namespace WebExtension.Net.Mock.Configurators
{
    /// <summary>
    /// The API configurator.
    /// </summary>
    public class ApiConfigurator : BaseConfigurator<IWebExtensionApi>
    {
        /// <summary>
        /// Creates a new instance of ApiConfigurator.
        /// </summary>
        /// <param name="webExtensionApi">The web extension API.</param>
        /// <param name="mockHandlers">The mock handlers.</param>
        internal ApiConfigurator(IWebExtensionApi webExtensionApi, IList<IMockHandler> mockHandlers) : base(webExtensionApi, mockHandlers) { }

        /// <inheritdoc />
        protected override IMockHandler CreateHandler(LambdaExpression expression)
        {
            MockConfigurationContext.ResetContext();
            InvokeExpression(expression);
            if (MockConfigurationContext.TryGetApiInvoked(out var targetPath))
            {
                return new MockApiHandler()
                {
                    ApiTargetPath = targetPath
                };
            }

            throw new InvalidOperationException("There was no invocation on the API.");
        }
    }
}
