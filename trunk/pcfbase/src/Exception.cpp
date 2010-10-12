#include <sstream>
#include <Exception.h>

using namespace std;

Exception::Exception()
{
}

Exception::Exception(const char* message)
{
	message_ = message;
}

Exception::Exception(const char* message, const char* fileName, int lineNo)
{
	ostringstream sout;

	sout << message << endl << "error trace (top line is the source) :" << endl;
	sout << fileName << " : line " << lineNo;

	message_ = sout.rdbuf()->str();
}

Exception::Exception(const exception& ex, const char* fileName, int lineNo)
{
	ostringstream sout;

	sout << ex.what() << endl;
	sout << fileName << " : line " << lineNo;

	message_ = sout.rdbuf()->str();
}

Exception::~Exception() throw ()
{
}

