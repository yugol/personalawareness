#include "_test.h"

int main()
{
	TestResult testResult;

	try {
		TestRegistry::runAllTests(testResult);
	} catch (const exception& ex) {
		cerr << ex.what() << endl;
		return -1;
	} catch (...) {
		cerr << "some exception was thrown" << endl;
		return -1;
	}

	return testResult.getFailureCount();
}
