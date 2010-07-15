#include <cstring>
#include <cstdio>
#include "util.h"

using namespace std;

namespace adb {

void charPtrToString(string &str, const char *cptr)
{
	if (0 == cptr) {
		str = "";
	} else {
		str = cptr;
	}
}

const char* formatStringForDatabase(char *buf, const string &str)
{
	if (0 == str.size()) {
		::strcpy(buf, "NULL");
	} else {
		::sprintf(buf, "'%s'", str.c_str());
	}
	return buf;
}

} // namespace adb
