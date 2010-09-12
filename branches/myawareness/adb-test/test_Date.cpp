#include <Date.h>
#include "_test.h"

TEST( Full, Date)
{
    Date date;

    date.setNow();
    // cout << date << endl;

    date.setValue("20061107");
    LONGS_EQUAL(2006, date.getYear());
    LONGS_EQUAL(11, date.getMonth());
    LONGS_EQUAL(7, date.getDay());
    // cout << date << endl;
}
