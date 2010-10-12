#ifndef WORDSELECTION_H_
#define WORDSELECTION_H_

#include <vector>
#include <ostream>
#include "WordSelector.h"

class Dictionary;

class WordSelection {
public:
	WordSelection(const Dictionary& dictionary);
	virtual ~WordSelection();

	size_t size() const;
	const std::wstring& operator[](int index) const;
	const std::wstring& getRandomWord() const;

	void selectAll();
	void selectByPattern(const WordSelector& selector);
	void selectByHistogram(const WordSelector& selector);

	void sort();
	std::wostream& write(std::wostream& out) const;

private:
	const Dictionary* dictionary_;
	std::vector<const std::wstring*> words_;
};

inline size_t WordSelection::size() const
{
	return words_.size();
}

inline const std::wstring& WordSelection::operator[](int index) const
{
	return (*(words_[index]));
}

#endif /* WORDSELECTION_H_ */
