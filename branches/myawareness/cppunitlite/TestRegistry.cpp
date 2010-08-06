#include <cstdio>
#include <cstring>
#include "Test.h"
#include "TestResult.h"
#include "TestRegistry.h"

TestRegistry::TestRegistry() :
    testCount_(0), runCount_(0)
{
}

void TestRegistry::addTest(Test *test)
{
    instance().add(test);
}

void TestRegistry::runAllTests(TestResult& result)
{
    instance().run(result);
}

TestRegistry& TestRegistry::instance()
{
    static TestRegistry registry;
    return registry;
}

void TestRegistry::add(Test *test)
{
    if (0 == tests_) {
        tests_ = test;
    } else {
        test->setNext(tests_);
        tests_ = test;
    }
    ++testCount_;
}

void TestRegistry::run(TestResult& result)
{
    result.testsStarted();

    for (Test *test = tests_; test != 0; test = test->getNext()) {
        if (Test::SKIPPED != test->getType()) {
            ++runCount_;
            result.resetFailed();
            if (Test::VEBOSE == test->getType()) {
                ::fprintf(stdout, "%s ", test->getName());
                ::fflush(stdout);
            }
            test->run(result);
            if (Test::VEBOSE == test->getType()) {
                if (result.isFailed()) {
                    ::fprintf(stdout, ". failed\n");
                } else {
                    ::fprintf(stdout, ". ok\n");
                }
            }
        }
    }

    result.testsEnded(testCount_, runCount_);
}

