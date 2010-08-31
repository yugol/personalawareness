#include <cstring>
#include <cstdio>
#include <DbUtil.h>

using namespace std;

namespace adb {

    void DbUtil::charPtrToString(string &str, const char *cptr)
    {
        if (0 == cptr) {
            str = "";
        } else {
            str = cptr;
        }
    }

    void DbUtil::trimSpaces(string& str)
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
