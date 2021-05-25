using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace WebExtension.Net
{
    /// <summary>
    /// A JS function proxy to be invoked in DotNet.
    /// </summary>
    internal class JSFunctionProxy
    {
        private static readonly MethodInfo dynamicInvokeMethodInfo = typeof(JSFunctionProxy).GetMethod(nameof(DynamicInvoke), BindingFlags.Public | BindingFlags.Instance);
        private readonly Guid id;

        /// <summary>
        /// Creates a new instance of the JSFunctionProxy class.
        /// </summary>
        /// <param name="id">The function identifier.</param>
        public JSFunctionProxy(Guid id)
        {
            this.id = id;
        }

        /// <summary>
        /// Gets the proxy delegate to invoke the JavaScript function.
        /// </summary>
        /// <param name="delegateType">The delegate type.</param>
        /// <returns>A delegate matching the signature of the delegate type, when invoked executes the JavaScript function.</returns>
        public Delegate GetDelegate(Type delegateType)
        {
            // Generates a lambda expression based on the delegate type.
            // Action generates () => DynamicInvoke(new object[])
            // Action<int> generates (arg0) => DynamicInvoke(new object[] { (object)arg0 })
            // Func<int, int> generates (arg0) => (int)DynamicInvoke(new object[] { (object)arg0 })
            // Action<int, string> generates (arg0, arg1) => DynamicInvoke(new object[] { (object)arg0, (object)arg1 })
            // Func<int, string, int> generates (arg0, arg1) => DynamicInvoke(new object[] { (object)arg0, (object)arg1 })

            var invokeMethod = delegateType.GetMethod("Invoke");
            var invokeParameters = invokeMethod.GetParameters();
            var parameterExpressions = invokeParameters.Select((invokeParameter, index) => Expression.Parameter(invokeParameter.ParameterType, $"arg{index}")).ToArray();

            var returnType = invokeMethod.ReturnType == typeof(void) ? typeof(object) : invokeMethod.ReturnType;
            var newArrayInitExpression = Expression.NewArrayInit(typeof(object), parameterExpressions.Select(parameterExpression => Expression.Convert(parameterExpression, typeof(object))));
            var methodCallExpression = Expression.Call(Expression.Constant(this), dynamicInvokeMethodInfo.MakeGenericMethod(returnType), newArrayInitExpression);

            Expression expression = methodCallExpression;
            if (invokeMethod.ReturnType != typeof(void))
            {
                expression = Expression.Convert(methodCallExpression, invokeMethod.ReturnType);
            }

            return Expression.Lambda(delegateType, expression, parameterExpressions).Compile();
        }

        /// <summary>
        /// Dynamically invoke the JavaScript function synchronously.
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="arguments">JSON-serializable arguments.</param>
        /// <returns>An instance of TResult obtained by JSON-deserializing the return value.</returns>
        public TValue DynamicInvoke<TValue>(object[] arguments)
        {
            var webExtensionJsRuntime = WebExtensionJSRuntime.GetStaticInstance();
            return webExtensionJsRuntime.Invoke<TValue>(InvokeFunctionReferenceOption.Identifier, new InvokeFunctionReferenceOption(id), arguments);
        }
    }
}
