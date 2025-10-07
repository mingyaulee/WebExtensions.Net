using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Configurators
{
    /// <summary>
    /// The API configurator.
    /// </summary>
    public class ApiConfigurator : BaseConfigurator<IWebExtensionsApi>
    {
        /// <summary>
        /// Creates a new instance of ApiConfigurator.
        /// </summary>
        /// <param name="webExtensionsApi">The web extension API.</param>
        /// <param name="mockHandlers">The mock handlers.</param>
        internal ApiConfigurator(IWebExtensionsApi webExtensionsApi, IList<IMockHandler> mockHandlers) : base(webExtensionsApi, mockHandlers) { }

        /// <inheritdoc />
        protected override IMockHandler CreateHandler(LambdaExpression expression)
        {
            MockConfigurationContext.ResetContext();
            InvokeExpression(expression);
            return MockConfigurationContext.TryGetApiInvoked(out var targetPath)
                ? (IMockHandler)new MockApiHandler()
                {
                    ApiTargetPath = targetPath
                }
                : throw new InvalidOperationException("There was no invocation on the API.");
        }
    }
}
