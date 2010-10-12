#include <LetterHistogram.h>
#include "_test.h"

TEST(basic, LetterHistogram)
{
	LetterHistogram hist;
	hist.add(L'A');
	hist.add(L"APA");
	CHECK(hist[L'A'] == 3);
	CHECK(hist[L'P'] == 1);
	CHECK(hist[L'Z'] == 0);
	// hist.write(wcout);
	hist.clear();
	CHECK(hist.begin() == hist.end());
}
