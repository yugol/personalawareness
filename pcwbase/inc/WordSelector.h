#ifndef WORDSELECTOR_H_
#define WORDSELECTOR_H_

#include <string>
#include "LetterHistogram.h"

class WordSelector {
public:
	friend bool operator<(const WordSelector&, const WordSelector&);
	friend bool operator==(const WordSelector&, const WordSelector&);

	static const wchar_t WILDCARD;

	WordSelector(const std::wstring& pattern);
	virtual ~WordSelector();

	// TODO: copy constructor & assignment operator

	const std::wstring& getPattern() const;
	bool isHistogramMatch(const LetterHistogram& wordHistogram) const;
	bool isPatternMatch(const std::wstring& word) const;

private:
	std::wstring pattern_;
	mutable LetterHistogram* patternHistogram_;

	void buildPatternHistogram() const;
};

inline const std::wstring& WordSelector::getPattern() const
{
	return pattern_;
}

#endif /* WORDSELECTOR_H_ */
