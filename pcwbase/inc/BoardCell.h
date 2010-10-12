#ifndef BOARDCELL_H_
#define BOARDCELL_H_

#include <set>
#include "WordSelector.h"

class BoardCell {
public:
	BoardCell();
	virtual ~BoardCell();

	void emptyCell();

	bool isEmpty() const;
	wchar_t getSymbol() const;
	void setSymbol(wchar_t symbol);

	void cleanSelectors();
	const std::set<WordSelector>& getSelectors() const;
	void addSelector(const WordSelector&);

private:
	static const wchar_t EMPTY;

	wchar_t symbol_;
	std::set<WordSelector> selectors_;
};

inline bool BoardCell::isEmpty() const
{
	return symbol_ == EMPTY;
}

inline wchar_t BoardCell::getSymbol() const
{
	return symbol_;
}

#endif /* BOARDCELL_H_ */
