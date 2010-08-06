#ifndef DATE_H
#define DATE_H

#include <ctime>
#include <ostream>

namespace adb {

class Date {

public:
	Date();
	Date(const char *date);
	virtual ~Date();

	void setNow();
	void setValue(time_t when);
	void setValue(const char* date);
	int getYear() const;
	int getMonth() const;
	int getDay() const;
	void sprintf(char* rep) const;

protected:

private:
	short year_;
	char month_;
	char day_;

};

std::ostream& operator<<(std::ostream& out, const Date& date);

inline int Date::getYear() const
{
	return year_;
}

inline int Date::getMonth() const
{
	return month_;
}

inline int Date::getDay() const
{
	return day_;
}

} // namespace adb

#endif // DATE_H
