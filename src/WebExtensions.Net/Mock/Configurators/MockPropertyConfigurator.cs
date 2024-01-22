using System;
using System.Collections.Generic;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Configurators
{
    /// <summary>Mock property configurator.</summary>
    /// <typeparam name="T">The property type.</typeparam>
    public class MockPropertyConfigurator<T>
    {
        private readonly IList<IMockHandler> mockHandlers;
        private readonly IMockHandler mockHandler;

        /// <summary>
        /// Creates a new instance of MockPropertyConfigurator
        /// </summary>
        /// <param name="mockHandlers">The list of mock handlers.</param>
        /// <param name="mockHandler">The mock handler to configure</param>
        public MockPropertyConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler)
        {
            this.mockHandlers = mockHandlers;
            this.mockHandler = mockHandler;
        }

        /// <summary>Sets an object to be returned from this mock.</summary>
        /// <param name="returnThis">The object to return.</param>
        public void ReturnsForAnyArgs(T returnThis) => Returns(() => returnThis);

        /// <summary>Sets a delegate to handle invocation from this mock.</summary>
        /// <param name="returns">The delegate to handle the invocation.</param>
        public void Returns(Func<T> returns) => SetDelegateHandler(returns);

        /// <summary>
        /// Sets the delegate handler and add the handler to the mock handler list.
        /// </summary>
        /// <param name="delegateHandler"></param>
        private void SetDelegateHandler(Delegate delegateHandler)
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
