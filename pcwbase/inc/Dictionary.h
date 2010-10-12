#ifndef DICTIONARY_H_
#define DICTIONARY_H_

#include <string>
#include <map>
#include <istream>
#include "LanguageTraits.h"
#include "LetterHistogram.h"

class Dictionary {
public:
	typedef std::map<std::wstring, LetterHistogram>::const_iterator const_iterator;

	Dictionary(const LanguageTraits* languageTraits);
	virtual ~Dictionary();

	int getWordCount() const;
	int getMinWordLength() const;
	int getMaxWordLength() const;
	const LetterHistogram& getLetterHistogram() const;
	const_iterator begin() const;
	const_iterator end() const;
	const LetterHistogram& operator[](const std::wstring& word) const;

	void clear();
	void add(const wchar_t* buffer);
	void readWords(std::istream& in);

private:
	const LanguageTraits* languageTraits_;
	std::map<std::wstring, LetterHistogram> words_;
	int minWordLength_;
	int maxWordLength_;
	LetterHistogram letterHistogram_;
};

inline int Dictionary::getWordCount() const
{
	return words_.size();
}

inline int Dictionary::getMinWordLength() const
{
	return minWordLength_;
}

inline int Dictionary::getMaxWordLength() const
{
	return maxWordLength_;
}

inline const LetterHistogram& Dictionary::getLetterHistogram() const
{
	return letterHistogram_;
}

inline Dictionary::const_iterator Dictionary::begin() const
{
	return words_.begin();
}

inline Dictionary::const_iterator Dictionary::end() const
{
	return words_.end();
}

#endif /* DICTIONARY_H_ */
