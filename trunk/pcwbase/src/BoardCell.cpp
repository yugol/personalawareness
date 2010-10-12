#include <BoardCell.h>

using namespace std;

const wchar_t BoardCell::EMPTY = L' ';

BoardCell::BoardCell() :
	symbol_(EMPTY)
{
}

BoardCell::~BoardCell()
{
}

void BoardCell::emptyCell()
{
	symbol_ = EMPTY;
	cleanSelectors();
}

void BoardCell::cleanSelectors()
{
	selectors_.clear();
}

void BoardCell::setSymbol(wchar_t symbol)
{
	symbol_ = symbol;
}

void BoardCell::addSelector(const WordSelector& selector)
{
	selectors_.insert(selector);
}

