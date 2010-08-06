#include <ctime>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <Date.h>

namespace adb {

Date::Date() :
	year_(0), month_(0), day_(0)
{
}

Date::Date(const char *date)
{
	setValue(date);
}

Date::~Date()
{
}

void Date::setNow()
{
	time_t now;
	::time(&now);
	setValue(now);
}

void Date::setValue(time_t when)
{
	tm *timeinfo = localtime(&when);
	year_ = timeinfo->tm_year + 1900;
	month_ = timeinfo->tm_mon + 1;
	day_ = timeinfo->tm_mday;
}

void Date::setValue(const char* date)
{
	char buf[9];
	::memcpy(buf, date, 8);
	buf[8] = '\0';
	day_ = ::atoi(buf + 6);
	buf[6] = '\0';
	month_ = ::atoi(buf + 4);
	buf[4] = '\0';
	year_ = ::atoi(buf);
}

void Date::sprintf(char* rep) const
{
	::sprintf(rep, "%04d%02d%02d", year_, month_, day_);
}

std::ostream& operator<<(std::ostream& out, const Date& date)
{
	out.fill('0');
	out.width(4);
	out << date.getYear();
	out.fill('0');
	out.width(2);
	out << date.getMonth();
	out.fill('0');
	out.width(2);
	out << date.getDay();
	return out;
}

} // namespace adb
