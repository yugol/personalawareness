#include <sstream>
#include <Exception.h>

using namespace std;

const char Exception::EMSG_EMPTY_EXPRESSION[] = "empty expression";
const char Exception::EMSG_UNKNOWN_PRIORITY[] = "unknown priority";
const char Exception::EMSG_UNKNOWN_OPERATOR[] = "unknown operator";
const char Exception::EMSG_NO_OPERATOR[] = "operand without operator";
const char Exception::EMSG_NO_FIRST_OPERAND[] = "operator without first operand";
const char Exception::EMSG_NO_SECOND_OPERAND[] = "operator without second operand";

Exception::Exception()
{
}

Exception::Exception(const char* message) :
	what_(message)
{
}

Exception::Exception(const char* message, const char* fileName, int lineNo) :
	what_(message)
{
	ostringstream sout;
	sout << what_ << endl;
	sout << fileName << " : line " << lineNo;
	what_ = sout.rdbuf()->str();
}

Exception::Exception(const exception& ex, const char* fileName, int lineNo)
{
	ostringstream sout;
	sout << ex.what() << endl;
	sout << fileName << " : line " << lineNo;
	what_ = sout.rdbuf()->str();
}

Exception::~Exception() throw ()
{
}

