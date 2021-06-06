using System;
using System.Collections.Generic;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Configurators
{
    /// <summary>Mock function configurator.</summary>
    /// <typeparam name="TResult">The function return type.</typeparam>
    public class MockFunctionConfigurator<TResult> : BaseMethodConfigurator
    {
        internal MockFunctionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

        /// <summary>Sets an object to be returned from this mock.</summary>
        /// <param name="returnThis">The object to return.</param>
        public void ReturnsForAnyArgs(TResult returnThis) => Returns(() => returnThis);

        /// <summary>Sets a delegate to handle invocation from this mock.</summary>
        /// <param name="returns">The delegate to handle the invocation.</param>
        public void Returns(Func<TResult> returns) => SetDelegateHandler(returns);
    }

    /// <summary>Mock function configurator.</summary>
    /// <typeparam name="T">The function argument type.</typeparam>
    /// <typeparam name="TResult">The function return type.</typeparam>
    public class MockFunctionConfigurator<T, TResult> : BaseMethodConfigurator
    {
        internal MockFunctionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

        /// <summary>Sets an object to be returned from this mock.</summary>
        /// <param name="returnThis">The object to return.</param>
        public void ReturnsForAnyArgs(TResult returnThis) => Returns(_ => returnThis);

        /// <summary>Sets a delegate to handle invocation from this mock.</summary>
        /// <param name="returns">The delegate to handle the invocation.</param>
        public void Returns(Func<T, TResult> returns) => SetDelegateHandler(returns);
    }

    /// <summary>Mock function configurator.</summary>
    /// <typeparam name="T1">The function argument 1 type.</typeparam>
    /// <typeparam name="T2">The function argument 2 type.</typeparam>
    /// <typeparam name="TResult">The function return type.</typeparam>
    public class MockFunctionConfigurator<T1, T2, TResult> : BaseMethodConfigurator
    {
        internal MockFunctionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

        /// <summary>Sets an object to be returned from this mock.</summary>
        /// <param name="returnThis">The object to return.</param>
        public void ReturnsForAnyArgs(TResult returnThis) => Returns((_, _) => returnThis);

        /// <summary>Sets a delegate to handle invocation from this mock.</summary>
        /// <param name="returns">The delegate to handle the invocation.</param>
        public void Returns(Func<T1, T2, TResult> returns) => SetDelegateHandler(returns);
    }

    /// <summary>Mock function configurator.</summary>
    /// <typeparam name="T1">The function argument 1 type.</typeparam>
    /// <typeparam name="T2">The function argument 2 type.</typeparam>
    /// <typeparam name="T3">The function argument 3 type.</typeparam>
    /// <typeparam name="TResult">The function return type.</typeparam>
    public class MockFunctionConfigurator<T1, T2, T3, TResult> : BaseMethodConfigurator
    {
        internal MockFunctionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

        /// <summary>Sets an object to be returned from this mock.</summary>
        /// <param name="returnThis">The object to return.</param>
        public void ReturnsForAnyArgs(TResult returnThis) => Returns((_, _, _) => returnThis);

        /// <summary>Sets a delegate to handle invocation from this mock.</summary>
        /// <param name="returns">The delegate to handle the invocation.</param>
        public void Returns(Func<T1, T2, T3, TResult> returns) => SetDelegateHandler(returns);
    }

    /// <summary>Mock function configurator.</summary>
    /// <typeparam name="T1">The function argument 1 type.</typeparam>
    /// <typeparam name="T2">The function argument 2 type.</typeparam>
    /// <typeparam name="T3">The function argument 3 type.</typeparam>
    /// <typeparam name="T4">The function argument 4 type.</typeparam>
    /// <typeparam name="TResult">The function return type.</typeparam>
    public class MockFunctionConfigurator<T1, T2, T3, T4, TResult> : BaseMethodConfigurator
    {
        internal MockFunctionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

        /// <summary>Sets an object to be returned from this mock.</summary>
        /// <param name="returnThis">The object to return.</param>
        public void ReturnsForAnyArgs(TResult returnThis) => Returns((_, _, _, _) => returnThis);

        /// <summary>Sets a delegate to handle invocation from this mock.</summary>
        /// <param name="returns">The delegate to handle the invocation.</param>
        public void Returns(Func<T1, T2, T3, T4, TResult> returns) => SetDelegateHandler(returns);
    }

    /// <summary>Mock function configurator.</summary>
    /// <typeparam name="T1">The function argument 1 type.</typeparam>
    /// <typeparam name="T2">The function argument 2 type.</typeparam>
    /// <typeparam name="T3">The function argument 3 type.</typeparam>
    /// <typeparam name="T4">The function argument 4 type.</typeparam>
    /// <typeparam name="T5">The function argument 5 type.</typeparam>
    /// <typeparam name="TResult">The function return type.</typeparam>
    public class MockFunctionConfigurator<T1, T2, T3, T4, T5, TResult> : BaseMethodConfigurator
    {
        internal MockFunctionConfigurator(IList<IMockHandler> mockHandlers, IMockHandler mockHandler) : base(mockHandlers, mockHandler) { }

        /// <summary>Sets an object to be returned from this mock.</summary>
        /// <param name="returnThis">The object to return.</param>
        public void ReturnsForAnyArgs(TResult returnThis) => Returns((_, _, _, _, _) => returnThis);

        /// <summary>Sets a delegate to handle invocation from this mock.</summary>
        /// <param name="returns">The delegate to handle the invocation.</param>
        public void Returns(Func<T1, T2, T3, T4, T5, TResult> returns) => SetDelegateHandler(returns);
    }
}
