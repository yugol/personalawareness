#include <Record.h>

namespace adb {

void Record::assign(std::string& str, const char* cstr)
{
	if (0 == cstr) {
		str = "";
	} else {
		str = cstr;
	}
}

Record::Record(int id) :
	id_(id)
{
}

Record::~Record()
{
}

void Record::setId(int id)
{
	id_ = id;
}

}
