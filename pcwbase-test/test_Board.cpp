#include <Board.h>
#include <WordSelector.h>
#include "_test.h"

TEST(basic, Board)
{
	Board b;

	b.putWordHorizontal(L"ABCDEFGHIJKLMNOPQRSTUVWXYZ", 0, 0);
	b.putWordVertical(L"ABCDEFGHIJKLMNOPQRSTUVWXYZ", 0, 0);
	b.putWordHorizontal(L"ABCDEFGHIJKLMNOPQRSTUVWXYZ", b.getLineCount() - 1, 1);
	b.putWordVertical(L"ABCDEFGHIJKLMNOPQRSTUVWXYZ", 1, b.getColumnCount() - 1);
	b.putWordHorizontal(L"ABC", 7, 6);
	b.putWordVertical(L"ABC", 6, 7);

	// b.write(wcout);

	wstring word = b.getWord(3, 3, true);
	CHECK(word.size() == 0);

	word = b.getWord(7, 7, true);
	CHECK(word == L"BC");

	word = b.getWord(6, 7, false);
	CHECK(word == L"ABC");

	WordSelector selector = b.buildSelector(0, 0, true, 3);
	CHECK(selector.getPattern() == L"ABC");

	selector = b.buildSelector(7, 5, true, 5);
	CHECK(selector.getPattern() == L".ABC.");

	selector = b.buildSelector(6, 6, false, 3);
	CHECK(selector.getPattern() == L".A.");
}

TEST(randomSelector, Board)
{
	Board b(10, 10, 3, 5);
	int lineNo, columnNo;
	bool horizontal;

	for (int i = 0; i < 100; ++i) {
		WordSelector selector = b.buildRandomSelector(lineNo, columnNo, horizontal);
		b.putWord(selector.getPattern(), lineNo, columnNo, horizontal);
	}

	// b.write(wcout);
}
