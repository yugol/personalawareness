#ifndef DBUTIL_H_
#define DBUTIL_H_

#include <string>

class BaseUtil {
public:
    static bool toBool(const char* cstr);
    static const std::string toDbParameter(const std::string& str);
    static void charPtrToString(std::string& str, const char* cstr);
    static void trimSpaces(std::string& str);
};

#endif /* DBUTIL_H_ */
