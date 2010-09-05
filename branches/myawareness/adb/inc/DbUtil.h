#ifndef DBUTIL_H_
#define DBUTIL_H_

#include <string>

namespace adb {

    class DbUtil {
    public:
        static bool toBool(const char* cstr);
        static const std::string toParameter(const std::string& str);
        static void charPtrToString(std::string& str, const char* cstr);
        static void trimSpaces(std::string& str);
    };

} // namespace std

#endif /* DBUTIL_H_ */
