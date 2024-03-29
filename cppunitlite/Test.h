///////////////////////////////////////////////////////////////////////////////
//
// TEST.H
// 
// This file contains the Test class along with the macros which make effective
// in the harness.
//
///////////////////////////////////////////////////////////////////////////////

#ifndef TEST_H
#define TEST_H

#include <cmath>
#include "SimpleString.h"

class TestResult;

class Test {
public:
    enum Type {
        SILENT, VEBOSE, SKIPPED
    };

    Test(const SimpleString& testName, Type type = VEBOSE);

    const char* getName() const;
    Type getType() const;
    Test* getNext() const;

    void setNext(Test* test);

    virtual void run(TestResult& result) = 0;

protected:
    bool check(long expected, long actual, TestResult& result, const SimpleString& fileName, long lineNumber);
    bool check(const SimpleString& expected, const SimpleString& actual, TestResult& result,
            const SimpleString& fileName, long lineNumber);

    SimpleString name_;
    Type type_;
    Test* next_;
};

#define TEST(testName,testGroup)\
class testGroup##testName##Test : public Test { \
public: \
    testGroup##testName##Test () : Test (#testGroup "-" #testName "-" "Test") {} \
    void run(TestResult& result_); } \
    testGroup##testName##Instance; \
    void testGroup##testName##Test::run(TestResult& result_)

#define SKIPTEST(testName,testGroup)\
class testGroup##testName##Test : public Test { \
public: \
    testGroup##testName##Test () : Test (#testGroup "-" #testName "-" "Test", SKIPPED) {} \
    void run(TestResult& result_); } \
    testGroup##testName##Instance; \
    void testGroup##testName##Test::run(TestResult& result_)

#define CHECK(condition){ \
if (!(condition)) { \
	result_.addFailure (Failure (name_, __FILE__,__LINE__, #condition)); \
	return; \
}\
}

#define CHECK_EQUAL(expected,actual)\
{ if ((expected) == (actual)) return; result_.addFailure(Failure(name_, __FILE__, __LINE__, StringFrom(expected), StringFrom(actual))); }

#define LONGS_EQUAL(expected,actual)\
{ long actualTemp = actual; \
  long expectedTemp = expected; \
  if ((expectedTemp) != (actualTemp)) \
{ result_.addFailure (Failure (name_, __FILE__, __LINE__, StringFrom(expectedTemp), \
StringFrom(actualTemp))); return; } }

#define DOUBLES_EQUAL(expected,actual,threshold)\
{ double actualTemp = actual; \
  double expectedTemp = expected; \
  if (fabs ((expectedTemp)-(actualTemp)) > threshold) \
{ result_.addFailure (Failure (name_, __FILE__, __LINE__, \
StringFrom((double)expectedTemp), StringFrom((double)actualTemp))); return; } }

#define FAIL(text) \
{ result_.addFailure (Failure (name_, __FILE__, __LINE__,(text))); return; }

#endif
