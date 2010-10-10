#include <sstream>
#include <Exception.h>

using namespace std;

const char Exception::EMSG_NO_DATABASE[] = "no opened database";
const char Exception::EMSG_SQL_ERROR[] = "SQL error";
const char Exception::EMSG_NO_RECORD[] = "no such record";
const char Exception::EMSG_WRONG_NAME[] = "wrong name";
const char Exception::EMSG_WRONG_VALUE[] = "wrong value";
const char Exception::EMSG_UNDEFINED[] = "this should not happen";
const char Exception::EMSG_RECORD_IN_USE[] = "record in use";

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

