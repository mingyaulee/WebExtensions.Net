using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Configurators
{
    /// <summary>
    /// The base configurator.
    /// </summary>
    /// <typeparam name="TObject">The type of object to configure.</typeparam>
    /// <param name="webExtensionsApi">The web extension API.</param>
    /// <param name="mockHandlers">The mock handlers.</param>
    public abstract class BaseConfigurator<TObject>(IWebExtensionsApi webExtensionsApi, IList<IMockHandler> mockHandlers)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
        private readonly IList<IMockHandler> mockHandlers = mockHandlers;

        /// <summary>Configures the mock handler for the property.</summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="expression">The expression returning the property to mock.</param>
        /// <returns>Property configurator.</returns>
        public MockPropertyConfigurator<T> Property<T>(Expression<Func<TObject, T>> expression)
            => new(mockHandlers, CreateHandler(expression));

        #region Synchronous method without return value

        /// <summary>Configures the mock handler for the method.</summary>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator Method(Expression<Func<TObject, Action>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T">The action argument type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T> Method<T>(Expression<Func<TObject, Func<T, Action>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2> Method<T1, T2>(Expression<Func<TObject, Action<T1, T2>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <typeparam name="T3">The action argument 3 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2, T3> Method<T1, T2, T3>(Expression<Func<TObject, Action<T1, T2, T3>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <typeparam name="T3">The action argument 3 type.</typeparam>
        /// <typeparam name="T4">The action argument 4 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2, T3, T4> Method<T1, T2, T3, T4>(Expression<Func<TObject, Action<T1, T2, T3, T4>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <typeparam name="T3">The action argument 3 type.</typeparam>
        /// <typeparam name="T4">The action argument 4 type.</typeparam>
        /// <typeparam name="T5">The action argument 5 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2, T3, T4, T5> Method<T1, T2, T3, T4, T5>(Expression<Func<TObject, Action<T1, T2, T3, T4, T5>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        #endregion Synchronous method without return value

        #region Asynchronous method without return value

        /// <summary>Configures the mock handler for the method.</summary>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator Method(Expression<Func<TObject, Func<ValueTask>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T">The action argument type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T> Method<T>(Expression<Func<TObject, Func<T, ValueTask>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2> Method<T1, T2>(Expression<Func<TObject, Func<T1, T2, ValueTask>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <typeparam name="T3">The action argument 3 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2, T3> Method<T1, T2, T3>(Expression<Func<TObject, Func<T1, T2, T3, ValueTask>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <typeparam name="T3">The action argument 3 type.</typeparam>
        /// <typeparam name="T4">The action argument 4 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2, T3, T4> Method<T1, T2, T3, T4>(Expression<Func<TObject, Func<T1, T2, T3, T4, ValueTask>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The action argument 1 type.</typeparam>
        /// <typeparam name="T2">The action argument 2 type.</typeparam>
        /// <typeparam name="T3">The action argument 3 type.</typeparam>
        /// <typeparam name="T4">The action argument 4 type.</typeparam>
        /// <typeparam name="T5">The action argument 5 type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Action configurator.</returns>
        public MockActionConfigurator<T1, T2, T3, T4, T5> Method<T1, T2, T3, T4, T5>(Expression<Func<TObject, Func<T1, T2, T3, T4, T5, ValueTask>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        #endregion Asynchronous method without return value

        #region Synchronous method with return value

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<TResult> Method<TResult>(Expression<Func<TObject, Func<TResult>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T">The function argument type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T, TResult> Method<T, TResult>(Expression<Func<TObject, Func<T, TResult>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, TResult> Method<T1, T2, TResult>(Expression<Func<TObject, Func<T1, T2, TResult>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="T3">The function argument 3 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, T3, TResult> Method<T1, T2, T3, TResult>(Expression<Func<TObject, Func<T1, T2, T3, TResult>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="T3">The function argument 3 type.</typeparam>
        /// <typeparam name="T4">The function argument 4 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, T3, T4, TResult> Method<T1, T2, T3, T4, TResult>(Expression<Func<TObject, Func<T1, T2, T3, T4, TResult>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="T3">The function argument 3 type.</typeparam>
        /// <typeparam name="T4">The function argument 4 type.</typeparam>
        /// <typeparam name="T5">The function argument 5 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, T3, T4, T5, TResult> Method<T1, T2, T3, T4, T5, TResult>(Expression<Func<TObject, Func<T1, T2, T3, T4, T5, TResult>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        #endregion Synchronous method with return value

        #region Asynchronous method with return value

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<TResult> Method<TResult>(Expression<Func<TObject, Func<ValueTask<TResult>>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T">The function argument type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T, TResult> Method<T, TResult>(Expression<Func<TObject, Func<T, ValueTask<TResult>>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, TResult> Method<T1, T2, TResult>(Expression<Func<TObject, Func<T1, T2, ValueTask<TResult>>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="T3">The function argument 3 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, T3, TResult> Method<T1, T2, T3, TResult>(Expression<Func<TObject, Func<T1, T2, T3, ValueTask<TResult>>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="T3">The function argument 3 type.</typeparam>
        /// <typeparam name="T4">The function argument 4 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, T3, T4, TResult> Method<T1, T2, T3, T4, TResult>(Expression<Func<TObject, Func<T1, T2, T3, T4, ValueTask<TResult>>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        /// <summary>Configures the mock handler for the method.</summary>
        /// <typeparam name="T1">The function argument 1 type.</typeparam>
        /// <typeparam name="T2">The function argument 2 type.</typeparam>
        /// <typeparam name="T3">The function argument 3 type.</typeparam>
        /// <typeparam name="T4">The function argument 4 type.</typeparam>
        /// <typeparam name="T5">The function argument 5 type.</typeparam>
        /// <typeparam name="TResult">The function return type.</typeparam>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns>Function configurator.</returns>
        public MockFunctionConfigurator<T1, T2, T3, T4, T5, TResult> Method<T1, T2, T3, T4, T5, TResult>(Expression<Func<TObject, Func<T1, T2, T3, T4, T5, ValueTask<TResult>>>> expression)
            => new(mockHandlers, CreateHandler(expression));

        #endregion Asynchronous method with return value

        /// <summary>
        /// Creates the mock handler based on the lamdba expression.
        /// </summary>
        /// <param name="expression">The expression returning the method to mock.</param>
        /// <returns></returns>
        protected abstract IMockHandler CreateHandler(LambdaExpression expression);

        /// <summary>
        /// Invokes the lambda expression and the method returned.
        /// </summary>
        /// <param name="expression">The expression returning the method to mock.</param>
        protected void InvokeExpression(LambdaExpression expression)
        {
            try
            {
                var delegateToMock = (Delegate)expression.Compile().DynamicInvoke(webExtensionsApi);
                var arguments = delegateToMock.Method.GetParameters()
                    .Select(parameter => parameter.ParameterType.IsClass ? null : Activator.CreateInstance(parameter.ParameterType))
                    .ToArray();
                delegateToMock.DynamicInvoke(arguments);
            }
            catch
            {
                // suppress any exception from mock method invocation
            }
        }
    }
}
