///////////////////////////////////////////////////////////////////////////////
//
// TESTRESULT.H
// 
// A TestResult is a collection of the history of some test runs.  Right now
// it just collects failures.
// 
///////////////////////////////////////////////////////////////////////////////


#ifndef TESTRESULT_H
#define TESTRESULT_H

#include <ctime>

class Failure;

class TestResult {
public:
    TestResult();

    virtual void testsStarted();
    virtual void addFailure(const Failure& failure);
    virtual void testsEnded(int testCount, int runCount);

    int getFailureCount() const;
    bool isFailed() const;

    void resetFailed();

private:
    time_t startTime_;
    time_t endTime_;
    int failureCount_;
    bool failed_;
};

inline int TestResult::getFailureCount() const
{
    return failureCount_;
}

inline bool TestResult::isFailed() const
{
    return failed_;
}

inline void TestResult::resetFailed()
{
    failed_ = false;
}

#endif
