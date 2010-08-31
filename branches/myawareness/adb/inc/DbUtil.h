#ifndef DBUTIL_H_
#define DBUTIL_H_

#include <string>

namespace adb {

    class DbUtil {
    public:
        static const int STATEMENT_LEN = 2000;

        static void charPtrToString(std::string &str, const char *cptr);
        static void trimSpaces(std::string& str);
    };

} // namespace std

#endif /* DBUTIL_H_ */
