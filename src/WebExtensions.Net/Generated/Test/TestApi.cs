using JsBind.Net;
using System;

namespace WebExtensions.Net.Test
{
    /// <inheritdoc />
    public partial class TestApi : BaseApi, ITestApi
    {
        private OnMessageEvent _onMessage;

        /// <summary>Creates a new instance of <see cref="TestApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public TestApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "test"))
        {
        }

        /// <inheritdoc />
        public OnMessageEvent OnMessage
        {
            get
            {
                if (_onMessage is null)
                {
                    _onMessage = new OnMessageEvent();
                    _onMessage.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onMessage"));
                }
                return _onMessage;
            }
        }

        /// <inheritdoc />
        public virtual void AssertDeepEq(object expected, object actual, string message = null)
            => InvokeVoid("assertDeepEq", expected, actual, message);

        /// <inheritdoc />
        public virtual void AssertEq(object expected = null, object actual = null, string message = null)
            => InvokeVoid("assertEq", expected, actual, message);

        /// <inheritdoc />
        public virtual void AssertFalse(object test = null, string message = null)
            => InvokeVoid("assertFalse", test, message);

        /// <inheritdoc />
        public virtual void AssertRejects(Promise promise, ExpectedError expectedError, string message = null)
            => InvokeVoid("assertRejects", promise, expectedError, message);

        /// <inheritdoc />
        public virtual void AssertThrows(Action func, ExpectedError expectedError, string message = null)
            => InvokeVoid("assertThrows", func, expectedError, message);

        /// <inheritdoc />
        public virtual void AssertTrue(object test = null, string message = null)
            => InvokeVoid("assertTrue", test, message);

        /// <inheritdoc />
        public virtual void Fail(object message = null)
            => InvokeVoid("fail", message);

        /// <inheritdoc />
        public virtual void Log(string message)
            => InvokeVoid("log", message);

        /// <inheritdoc />
        public virtual void NotifyFail(string message)
            => InvokeVoid("notifyFail", message);

        /// <inheritdoc />
        public virtual void NotifyPass(string message = null)
            => InvokeVoid("notifyPass", message);

        /// <inheritdoc />
        public virtual void SendMessage(object arg1 = null, object arg2 = null)
            => InvokeVoid("sendMessage", arg1, arg2);

        /// <inheritdoc />
        public virtual void Succeed(object message = null)
            => InvokeVoid("succeed", message);

        /// <inheritdoc />
        public virtual void WithHandlingUserInput(Action callback)
            => InvokeVoid("withHandlingUserInput", callback);
    }
}
