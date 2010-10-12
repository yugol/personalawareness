#include <WordSelector.h>
#include <LetterHistogram.h>
#include "_test.h"

TEST(pattern, WordSelector)
{
	WordSelector ws(L".PA");
	CHECK(ws.isPatternMatch(L"APA"));
	CHECK(ws.isPatternMatch(L"EPA"));
	CHECK(!ws.isPatternMatch(L"EPC"));
	CHECK(!ws.isPatternMatch(L"PA"));
	CHECK(!ws.isPatternMatch(L"APAQ"));
}

TEST(histogram, WordSelector)
{
	WordSelector ws(L"ABRACADABRA");

	LetterHistogram hist;
	CHECK(ws.isHistogramMatch(hist));

	hist.add(L"ABBA");
	CHECK(ws.isHistogramMatch(hist));

	hist.clear();
	hist.add(L"ABBBA");
	CHECK(!ws.isHistogramMatch(hist));

	hist.clear();
	hist.add(L"ABEBA");
	CHECK(!ws.isHistogramMatch(hist));
}
