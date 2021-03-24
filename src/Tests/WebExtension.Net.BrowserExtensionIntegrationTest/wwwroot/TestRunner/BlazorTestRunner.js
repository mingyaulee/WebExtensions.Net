class TestClassInfo {
    /** @type {string} */ description;
    /** @type {string} */ fullName;
    /** @type {TestMethodInfo[]} */ testMethods;
}

class TestMethodInfo {
    /** @type {string} */ description;
    /** @type {string} */ skip;
    /** @type {string} */ methodName;
    /** @type {string} */ declaringTypeFullName;
}

class TestResult {
    /** @type {boolean} */ success;
    /** @type {string} */ failMessage;
    /** @type {string} */ stackTrace;
}

class TestResultError extends Error {
    constructor(message, stack) {
        super(message);
        this.stack = stack;
    }
}

(function (global) {
    let testRunner;
    const runTests = window.onload;
    window.onload = undefined;

    /**
     * 
     * @param {TestMethodInfo} testMethod
     * @param {function(): void} done
     */
    async function executeTestMethod(testMethod) {
        /** @type {TestResult} */
        const result = await testRunner.invokeMethodAsync("RunTest", testMethod);
        if (result.success) {
            expect(result.success).toBeTrue();
        } else {
            fail(new TestResultError(result.failMessage, result.stackTrace));
        }
    }

    /**
     * Adds the test class using describe()
     * @param {TestClassInfo} testClass
     */
    function addTestClass(testClass) {
        describe(testClass.description, function () {
            for (var testMethod of testClass.testMethods) {
                if (testMethod.skip) {
                    xit(testMethod.description, executeTestMethod.bind(null, testMethod)).pend(testMethod.skip);
                } else {
                    it(testMethod.description, executeTestMethod.bind(null, testMethod));
                }
            }
        });
    }

    /**
     * Start the test runner
     * @param {TestClassInfo[]} testClasses
     */
    function startTestRunner(testRunnerRef, testClasses) {
        testRunner = testRunnerRef;
        for (var testClass of testClasses) {
            addTestClass(testClass);
        }
        runTests();
    }

    global.TestRunner = {
        Start: startTestRunner
    };
})(globalThis);