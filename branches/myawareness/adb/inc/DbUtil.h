#ifndef DBUTIL_H_
#define DBUTIL_H_

#include <string>

namespace adb {

    class DbUtil {
    public:
        static const int DATE_LEN = 20;
        static const int NAME_LEN = 100;
        static const int DESCRIPTION_LEN = 1000;
        static const int STATEMENT_LEN = 2000;

        static void charPtrToString(std::string &str, const char *cptr);
        static const char* formatStringForDatabase(char *buf, const std::string &str);
        static void trimSpaces(std::string& str);
    };

} // namespace std

#endif /* DBUTIL_H_ */
