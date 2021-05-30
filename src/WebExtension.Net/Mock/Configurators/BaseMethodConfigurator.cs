using System;
using System.Collections.Generic;
using WebExtension.Net.Mock.Handlers;

namespace WebExtension.Net.Mock.Configurators
{
    /// <summary>
    /// Base method configurator.
    /// </summary>
    public abstract class BaseMethodConfigurator
    {
        private readonly IList<IMockHandler> mockHandlers;
        private readonly IMockHandler mockHandler;

        /// <summary>
        /// Creates a new instance of BaseMethodConfigurator
        /// </summary>
        /// <param name="mockHandlers">The list of mock handlers.</param>
        /// <param name="mockHandler">The mock handler to configure</param>
        protected BaseMethodConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler)
        {
            this.mockHandlers = mockHandlers;
            this.mockHandler = mockHandler;
        }

        /// <summary>
        /// Sets the delegate handler and add the handler to the mock handler list.
        /// </summary>
        /// <param name="delegateHandler"></param>
        protected void SetDelegateHandler(Delegate delegateHandler)
        {
            if (mockHandlers.Contains(mockHandler))
            {
                throw new InvalidOperationException("This instance of mock handler has been configured.");
            }

            mockHandler.DelegateHandler = delegateHandler;
            mockHandlers.Add(mockHandler);
        }
    }
}
