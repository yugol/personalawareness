#include <Exception.h>

namespace adb {

Exception::Exception()
{
}

Exception::Exception(const char* message)
{
	message_ = message;
}

Exception::~Exception() throw ()
{
}

}
