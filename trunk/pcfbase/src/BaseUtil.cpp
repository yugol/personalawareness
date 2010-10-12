#include <cctype>
#include <cstring>
#include <cstdio>
#include <BaseUtil.h>

using namespace std;

const char BaseUtil::EMSG_NO_DATABASE[] = "no opened database";
const char BaseUtil::EMSG_SQL_ERROR[] = "SQL error";
const char BaseUtil::EMSG_NO_RECORD[] = "no such record";
const char BaseUtil::EMSG_WRONG_NAME[] = "wrong name";
const char BaseUtil::EMSG_WRONG_VALUE[] = "wrong value";
const char BaseUtil::EMSG_UNDEFINED[] = "this should not happen";
const char BaseUtil::EMSG_RECORD_IN_USE[] = "record in use";

bool BaseUtil::toBool(const char* cstr)
{
	if (cstr == 0) {
		return false;
	}
	switch (::tolower(cstr[0])) {
		case '1':
		case 't':
			return true;
		default:
			return false;
	}
}

const string BaseUtil::toDbParameter(const string& str)
{
	string param;
	if (str.size() > 0) {
		char* buf = new char[str.size() * 2 + 3];
		char* dst = buf;
		*dst++ = '\'';
		for (size_t i = 0; i < str.size(); ++i) {
			char ch = str[i];
			*dst++ = ch;
			if (ch == '\'') {
				*dst++ = '\'';
			}
		}
		*dst++ = '\'';
		*dst++ = '\0';
		param = buf;
		delete[] buf;
	} else {
		param = "NULL";
	}
	return param;
}

void BaseUtil::charPtrToString(string& str, const char* cstr)
{
	if (0 == cstr) {
		str = "";
	} else {
		str = cstr;
	}
}

void BaseUtil::trimSpaces(string& str)
{
	size_t startpos = str.find_first_not_of(" \t\n\r");
	size_t endpos = str.find_last_not_of(" \t\n\r");
	if ((string::npos == startpos) || (string::npos == endpos)) {
		str = "";
	} else {
		str = str.substr(startpos, endpos - startpos + 1);
	}
}

