#ifndef BOARD_H_
#define BOARD_H_

#include <vector>
#include <string>
#include <ostream>
#include "BoardCell.h"

class Board {
public:
	Board(int lineCount = 15, int columnCount = 15, int minWordLength = 2, int maxWordLength = 0);
	virtual ~Board();

	void emptyBoard();

	int getLineCount() const;
	int getColumnCount() const;

	const std::vector<BoardCell>& operator[](int lineNo) const;
	std::vector<BoardCell>& operator[](int lineNo);

	std::wstring getWord(int lineNo, int columnNo, bool horizontal) const;
	std::wstring getWordHorizontal(int lineNo, int columnNo) const;
	std::wstring getWordVertical(int lineNo, int columnNo) const;

	void putWord(const std::wstring& word, int lineNo, int columnNo, bool horizontal);
	void putWordHorizontal(const std::wstring& word, int lineNo, int columnNo);
	void putWordVertical(const std::wstring& word, int lineNo, int columnNo);

	void cleanSelectors();
	void buildSelectors();
	void buildSelectors(int lineNo, int columnNo);
	WordSelector buildSelector(int lineNo, int columnNo, bool horizontal, int length);
	WordSelector buildRandomSelector(int& lineNo, int& columnNo, bool& horizontal);

	std::wostream& write(std::wostream& out) const;

private:
	int lineCount_;
	int columnCount_;
	int minWordLength_;
	int maxWordLength_;
	std::vector<std::vector<BoardCell> > cells_;
};

inline int Board::getLineCount() const
{
	return lineCount_;
}

inline int Board::getColumnCount() const
{
	return columnCount_;
}

inline const std::vector<BoardCell>& Board::operator[](int lineNo) const
{
	return cells_[lineNo];
}

inline std::vector<BoardCell>& Board::operator[](int lineNo)
{
	return cells_[lineNo];
}

inline std::wstring Board::getWordHorizontal(int lineNo, int columnNo) const
{
	return getWord(lineNo, columnNo, true);
}

inline std::wstring Board::getWordVertical(int lineNo, int columnNo) const
{
	return getWord(lineNo, columnNo, false);
}

inline void Board::putWordHorizontal(const std::wstring& word, int lineNo, int columnNo)
{
	putWord(word, lineNo, columnNo, true);
}

inline void Board::putWordVertical(const std::wstring& word, int lineNo, int columnNo)
{
	putWord(word, lineNo, columnNo, false);
}

#endif /* BOARD_H_ */
