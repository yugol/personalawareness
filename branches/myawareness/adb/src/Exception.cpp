#include <sstream>
#include <Exception.h>

using namespace std;

namespace adb {

    const char Exception::NO_DATABASE_MESSAGE[] = "no opened database";
    const char Exception::SQL_ERROR_MESSAGE[] = "SQL error";
    const char Exception::NO_RECORD_MESSAGE[] = "no such record";
    const char Exception::WRONG_NAME_MESSAGE[] = "wrong name";
    const char Exception::WRONG_VALUE_MESSAGE[] = "wrong value";
    const char Exception::UNDEFINED_MESSAGE[] = "this should not happen";
    const char Exception::RECORD_IN_USE[] = "record in use";

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

        sout << message << " : in" << endl;
        sout << fileName << ":" << lineNo << ":";

        message_ = sout.rdbuf()->str();
    }

    Exception::Exception(const exception& ex, const char* fileName, int lineNo)
    {
        ostringstream sout;

        sout << ex.what() << " in" << endl;
        sout << fileName << ":" << lineNo << ":";

        message_ = sout.rdbuf()->str();
    }

    Exception::~Exception() throw ()
    {
    }

} // namespac eadb
