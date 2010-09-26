#include <stdio.h>
#include "TestResult.h"
#include "Failure.h"

TestResult::TestResult() :
    failureCount_(0)
{
}

void TestResult::testsStarted()
{
    fprintf(stdout, "Testing...\n");
    ::time(&startTime_);
}

void TestResult::addFailure(const Failure& failure)
{
    fprintf(stderr, "%s:%ld: \"%s\"\n", failure.fileName.asCharString(), failure.lineNumber,
            failure.message.asCharString());

    failureCount_++;
    failed_ = true;
}

void TestResult::testsEnded(int testCount, int runCount)
{
    ::time(&endTime_);
    double duration = ::difftime(endTime_, startTime_);
    fprintf(stdout, "Test duration: %0.2f second(s).\n", duration);
    fprintf(stdout, "Test result: %d test(s), %d run(s), %d failure(s).\n", testCount, runCount, failureCount_);
}
