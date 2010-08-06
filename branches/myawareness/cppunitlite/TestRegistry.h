///////////////////////////////////////////////////////////////////////////////
//
// TESTREGISTRY.H
// 
// TestRegistry is a singleton collection of all the tests to_ run in a system.  
// 
///////////////////////////////////////////////////////////////////////////////

#ifndef TESTREGISTRY_H
#define TESTREGISTRY_H

class Test;
class TestResult;

class TestRegistry {
public:
	static void addTest(Test *test);
	static void runAllTests(TestResult& result);

	TestRegistry();

private:
	static TestRegistry& instance();

    Test *tests_;
    int testCount_;
    int runCount_;

    void add(Test *test);
	void run(TestResult& result);
};

#endif
