#include "test.h"

using namespace adb;

TEST( all, Date)
{
	cout << "Date-all" << endl;

	char rep[20];
	Date date;

	date.setNow();
	date.sprintf(rep);

	date.setValue("20061107");
	date.sprintf(rep);
	LONGS_EQUAL(2006, date.getYear());
	LONGS_EQUAL(11, date.getMonth());
	LONGS_EQUAL(7, date.getDay());
}