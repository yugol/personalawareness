#include "Test.h"
#include "TestRegistry.h"
#include "TestResult.h"
#include "Failure.h"

Test::Test(const SimpleString& testName, Type type) :
    name_(testName), type_(type)
{
    TestRegistry::addTest(this);
}

Test::Type Test::getType() const
{
    return type_;
}

Test *Test::getNext() const
{
    return next_;
}

const char* Test::getName() const
{
    return name_.asCharString();
}

void Test::setNext(Test *test)
{
    next_ = test;
}

bool Test::check(long expected, long actual, TestResult& result, const SimpleString& fileName, long lineNumber)
{
    if (expected == actual)
        return true;
    result.addFailure(Failure(name_, StringFrom(__FILE__), __LINE__, StringFrom(expected), StringFrom(actual)));

    return false;

}

bool Test::check(const SimpleString& expected, const SimpleString& actual, TestResult& result,
        const SimpleString& fileName, long lineNumber)
{
    if (expected == actual)
        return true;
    result.addFailure(Failure(name_, StringFrom(__FILE__), __LINE__, expected, actual));

    return false;

}

