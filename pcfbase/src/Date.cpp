#include <cstdlib>
#include <cstring>
#include <Exception.h>
#include <BaseUtil.h>
#include <Date.h>

using namespace std;

int Date::monthDifference(const Date& young, const Date& old)
{
	return (old.month_ - young.month_ + 12 * (old.year_ - young.year_));
}

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

bool Date::isNull() const
{
	return (0 == year_ && 0 == month_ && 0 == day_);
}

void Date::setNow()
{
	time_t now;
	::time(&now);
	setValue(now);
}

void Date::setValue(time_t when)
{
	tm *timeinfo = ::localtime(&when);
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
	if (0 == day_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
	buf[6] = '\0';
	month_ = ::atoi(buf + 4);
	if (0 == month_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
	buf[4] = '\0';
	year_ = ::atoi(buf);
	if (0 == year_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
}

ostream& operator<<(ostream& out, const Date& date)
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

