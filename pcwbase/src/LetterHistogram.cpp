#include <LetterHistogram.h>

using namespace std;

LetterHistogram::LetterHistogram()
{
}

LetterHistogram::~LetterHistogram()
{
}

void LetterHistogram::clear()
{
	histogram_.clear();
}

void LetterHistogram::add(wchar_t letter)
{
	if (histogram_.find(letter) == histogram_.end()) {
		histogram_[letter] = 1;
	} else {
		histogram_[letter] += 1;
	}
}

void LetterHistogram::add(const wstring& word)
{
	for (size_t letterNo = 0; letterNo < word.size(); ++letterNo) {
		add(word[letterNo]);
	}
}

int LetterHistogram::operator[](wchar_t letter) const
{
	const_iterator letterPosition = histogram_.find(letter);
	if (letterPosition == histogram_.end()) {
		return 0;
	} else {
		return letterPosition->second;
	}
}

wostream& LetterHistogram::write(wostream& out) const
{
	const_iterator entry = histogram_.begin();
	out << endl;
	for (; entry != histogram_.end(); ++entry) {
		out << entry->first << L" -> " << entry->second << endl;
	}
	return out;
}
