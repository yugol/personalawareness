#include <fstream>
#include <LanguageTraitsRo.h>
#include <Dictionary.h>
#include <WordSelection.h>
#include "_test.h"

TEST(add, Dictionary)
{
	Dictionary dict(new LanguageTraitsRo());
	dict.add(L"apa");
	CHECK(dict.getWordCount() > 0);

	WordSelection selection(dict);
	selection.selectAll();
	selection.write(wcout);
	//	wcout << "Word count: " << dict.getWordCount() << endl;
	//	wcout << "Min word length: " << dict.getMinWordLength() << endl;
	//	wcout << "Max word lenght: " << dict.getMaxWordLength() << endl;
	//	dict.writeLetterHistogram(wcout);
}

TEST(readFile, Dictionary)
{
	Dictionary dict(new LanguageTraitsRo());
	ifstream fin("ro-scrabble-loc-4.1.txt");
	dict.readWords(fin);
	CHECK(dict.getWordCount() > 0);

	//	wcout << endl << "Word count: " << dict.getWordCount() << endl;
	//	wcout << "Min word length: " << dict.getMinWordLength() << endl;
	//	wcout << "Max word lenght: " << dict.getMaxWordLength() << endl;
	//	dict.writeLetterHistogram(wcout);

	WordSelector patternSelector(L".P.");
	WordSelection selection(dict);
	selection.selectByPattern(patternSelector);
	CHECK(5 == selection.size());
	// selection.write(wcout);
	// wcout << endl << selection.getRandomWord() << endl;

	WordSelector histogramSelector(L"AAPP");
	selection.selectByHistogram(histogramSelector);
	CHECK(5 == selection.size());
	// selection.write(wcout);
	// wcout << endl << selection.getRandomWord() << endl;
}
