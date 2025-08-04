using JsBind.Net;
using System;
using System.Collections.Generic;

namespace WebExtensions.Net.Test
{
    /// <summary>none</summary>
    [JsAccessPath("test")]
    public partial interface ITestApi
    {
        /// <summary>Used to test sending messages to extensions.</summary>
        [JsAccessPath("onMessage")]
        OnMessageEvent OnMessage { get; }

        /// <summary></summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [JsAccessPath("assertDeepEq")]
        void AssertDeepEq(object expected, object actual, string message = null);

        /// <summary></summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [JsAccessPath("assertEq")]
        void AssertEq(object expected = null, object actual = null, string message = null);

        /// <summary></summary>
        /// <param name="test"></param>
        /// <param name="message"></param>
        [JsAccessPath("assertFalse")]
        void AssertFalse(object test = null, string message = null);

        /// <summary></summary>
        /// <param name="promise"></param>
        /// <param name="expectedError"></param>
        /// <param name="message"></param>
        [JsAccessPath("assertRejects")]
        void AssertRejects(Promise promise, ExpectedError expectedError, string message = null);

        /// <summary></summary>
        /// <param name="func"></param>
        /// <param name="expectedError">Required, unless running with extensions.wpt.enabled</param>
        /// <param name="message"></param>
        [JsAccessPath("assertThrows")]
        void AssertThrows(Action func, ExpectedError expectedError = null, string message = null);

        /// <summary></summary>
        /// <param name="test"></param>
        /// <param name="message"></param>
        [JsAccessPath("assertTrue")]
        void AssertTrue(object test = null, string message = null);

        /// <summary></summary>
        /// <param name="message"></param>
        [JsAccessPath("fail")]
        void Fail(object message = null);

        /// <summary>Logs a message during internal unit testing.</summary>
        /// <param name="message"></param>
        [JsAccessPath("log")]
        void Log(string message);

        /// <summary>Notifies the browser process that test code running in the extension failed.  This is only used for internal unit testing.</summary>
        /// <param name="message"></param>
        [JsAccessPath("notifyFail")]
        void NotifyFail(string message);

        /// <summary>Notifies the browser process that test code running in the extension passed.  This is only used for internal unit testing.</summary>
        /// <param name="message"></param>
        [JsAccessPath("notifyPass")]
        void NotifyPass(string message = null);

        /// <summary></summary>
        /// <param name="tests"></param>
        [JsAccessPath("runTests")]
        void RunTests(IEnumerable<Action> tests);

        /// <summary>Sends a string message to the browser process, generating a Notification that C++ test code can wait for.</summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        [JsAccessPath("sendMessage")]
        void SendMessage(object arg1 = null, object arg2 = null);

        /// <summary></summary>
        /// <param name="message"></param>
        [JsAccessPath("succeed")]
        void Succeed(object message = null);

        /// <summary>Calls the callback function wrapped with user input set.  This is only used for internal unit testing.</summary>
        /// <param name="callback"></param>
        [JsAccessPath("withHandlingUserInput")]
        void WithHandlingUserInput(Action callback);
    }
}
