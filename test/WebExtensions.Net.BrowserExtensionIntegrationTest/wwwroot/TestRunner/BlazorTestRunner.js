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
     * Executes the test method
     * @param {TestMethodInfo} testMethod
     * @param {function(): void} done
     */
    async function executeTestMethod(testMethod) {
        setSpecProperty("testMethod", testMethod);
        if (testMethod.skip) {
            pending(testMethod.skip);
            return;
        }
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
                it(testMethod.description, executeTestMethod.bind(null, testMethod));
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
        return new Promise(resolve => {
            afterAll(() => resolve());
            runTests();
        });
    }

    function getTestResults() {
        const runDetails = jsApiReporter.runDetails;
        const tests = jsApiReporter.specs().map(spec => {
            return {
                fullName: spec.fullName,
                description: spec.description,
                status: spec.status,
                duration: spec.duration,
                skip: spec.properties?.testMethod?.skip,
                declaringTypeFullName: spec.properties?.testMethod?.declaringTypeFullName,
                methodName: spec.properties?.testMethod?.methodName,
                failMessage: spec.failedExpectations?.[0]?.message,
                stackTrace: spec.failedExpectations?.[0]?.stack
            };
        });
        return {
            status: runDetails.overallStatus,
            duration: runDetails.totalTime,
            tests: tests
        };
    }

    let testCoverage = null;
    function setTestCoverage(value) {
        testCoverage = value;
    }

    function getTestCoverage() {
        return testCoverage;
    }

    global.TestRunner = {
        Start: startTestRunner,
        GetTestResults: getTestResults,
        SetTestCoverage: setTestCoverage,
        GetTestCoverage: getTestCoverage
    };
})(globalThis);