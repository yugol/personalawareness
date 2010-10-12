#include <WordSelector.h>

using namespace std;

bool operator<(const WordSelector& one, const WordSelector& other)
{
	if (one.pattern_.size() < other.pattern_.size()) {
		return true;
	}
	return false;
}

bool operator==(const WordSelector& one, const WordSelector& other)
{
	return one.pattern_ == other.pattern_;
}

const wchar_t WordSelector::WILDCARD = L'.';

WordSelector::WordSelector(const wstring& pattern) :
	pattern_(pattern), patternHistogram_(0)
{
}

WordSelector::~WordSelector()
{
	delete patternHistogram_;
}

void WordSelector::buildPatternHistogram() const
{
	if (patternHistogram_ == 0) {
		patternHistogram_ = new LetterHistogram();
		for (size_t letterNo = 0; letterNo < pattern_.size(); ++letterNo) {
			wchar_t letter = pattern_[letterNo];
			switch (letter) {
				case WILDCARD:

					break;
				default:
					patternHistogram_->add(letter);
					break;
			}
		}
	}
}

bool WordSelector::isHistogramMatch(const LetterHistogram& wordHistogram) const
{
	buildPatternHistogram();
	LetterHistogram::const_iterator entry = wordHistogram.begin();
	for (; entry != wordHistogram.end(); ++entry) {
		if ((*patternHistogram_)[entry->first] < entry->second) {
			return false;
		}
	}
	return true;
}

bool WordSelector::isPatternMatch(const wstring& word) const
{
	if (word.size() != pattern_.size()) {
		return false;
	}
	for (size_t letterNo = 0; letterNo < pattern_.size(); ++letterNo) {
		wchar_t patternSymbol = pattern_[letterNo];
		if (patternSymbol != WILDCARD) {
			wchar_t wordLetter = word[letterNo];
			if (wordLetter != patternSymbol) {
				return false;
			}
		}
	}
	return true;
}

