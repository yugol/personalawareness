#ifndef DATE_H
#define DATE_H

#include <ctime>
#include <ostream>

class Date {

public:
    static int monthDifference(const Date& young, const Date& old);

    Date();
    Date(const char *date);
    virtual ~Date();

    bool isNull() const;
    void setNow();
    void setValue(time_t when);
    void setValue(const char* date);
    int getYear() const;
    int getMonth() const;
    int getDay() const;

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

#endif // DATE_H
