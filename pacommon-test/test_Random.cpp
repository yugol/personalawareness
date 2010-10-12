#include <climits>
#include <Random.h>
#include "_test.h"

TEST(nextBool, Random)
{
	Random rnd;
	bool gotTrue = false;
	bool gotFalse = false;
	for (int i = 0; i < 10; ++i) {
		bool val = rnd.nextBool();
		if (val) {
			gotTrue = true;
		} else {
			gotFalse = true;
		}
	}
	CHECK(gotTrue);
	CHECK(gotFalse);
}

TEST(nextInt, Random)
{
	Random rnd;
	for (int i = 0; i < 1000; ++i) {
		int val = rnd.nextInt();
		CHECK(LONG_MIN <= val);
		CHECK(val <= LONG_MAX);
	}
}

TEST(nextIntMax, Random)
{
	Random rnd;
	int min = 1000;
	int max = -1000;
	for (int i = 0; i < 1000; ++i) {
		int val = rnd.nextInt(100);
		if (val > max) {
			max = val;
		}
		if (val < min) {
			min = val;
		}
	}
	CHECK(0 == min);
	CHECK(99 == max);
}

TEST(nextIntMinMax, Random)
{
	Random rnd;
	int min = 1000;
	int max = -1000;
	for (int i = 0; i < 1000; ++i) {
		int val = rnd.nextInt(-50, 50);
		if (val > max) {
			max = val;
		}
		if (val < min) {
			min = val;
		}
	}
	CHECK(-50 == min);
	CHECK(50 == max);
}
