#include <cstring>
#include <cstdio>
#include <cstdlib>
#include <iostream>
#include <sstream>
#include <util.h>

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

void trimSpaces(string& str)
{
	size_t startpos = str.find_first_not_of(" \t\n\r");
	size_t endpos = str.find_last_not_of(" \t\n\r");
	if ((string::npos == startpos) || (string::npos == endpos)) {
		str = "";
	} else {
		str = str.substr(startpos, endpos - startpos + 1);
	}
}

} // namespace adb
