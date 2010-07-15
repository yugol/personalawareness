#ifndef UTIL_H_INCLUDED
#define UTIL_H_INCLUDED

#include <string>

namespace adb {

const int DATE_LEN = 20;
const int NAME_LEN = 100;
const int DESCRIPTION_LEN = 1000;
const int STATEMENT_LEN = 2000;

void charPtrToString(std::string &str, const char *cptr);
const char* formatStringForDatabase(char *buf, const std::string &str);

} // namespace adb


#endif // UTIL_H_INCLUDED
