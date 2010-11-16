#ifndef BASEUTIL_H_
#define BASEUTIL_H_

#include <string>

class BaseUtil {
public:
    static const char EMSG_WRONG_DATABASE[];
    static const char EMSG_INCOMPATIBLE_DATABASE[];
	static const char EMSG_NO_DATABASE[];
	static const char EMSG_SQL_ERROR[];
	static const char EMSG_NO_RECORD[];
	static const char EMSG_WRONG_NAME[];
	static const char EMSG_WRONG_VALUE[];
	static const char EMSG_UNDEFINED[];
	static const char EMSG_RECORD_IN_USE[];

	static bool toBool(const char* cstr);
	static const std::string toDbParameter(const std::string& str);
	static void charPtrToString(std::string& str, const char* cstr);
	static void trimSpaces(std::string& str);
};

#endif /* BASEUTIL_H_ */
