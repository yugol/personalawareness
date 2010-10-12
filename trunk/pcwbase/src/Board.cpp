#include <algorithm>
#include <Exception.h>
#include <Random.h>
#include <Board.h>

using namespace std;

Board::Board(int lineCount, int columnCount, int minWordLength, int maxWordLength) :
	lineCount_(lineCount), columnCount_(columnCount), minWordLength_(minWordLength), maxWordLength_(maxWordLength)
{
	if (maxWordLength_ <= 0) {
		maxWordLength_ = max(lineCount_, columnCount_);
	}
	cells_.resize(lineCount_);
	for (int lineNo = 0; lineNo < lineCount_; ++lineNo) {
		cells_[lineNo].resize(columnCount_);
	}
}

Board::~Board()
{
}

void Board::emptyBoard()
{
	for (int lineNo = 0; lineNo < lineCount_; ++lineNo) {
		for (int columnNo = 0; columnNo < columnCount_; ++columnNo) {
			cells_[lineNo][columnNo].emptyCell();
		}
	}
}

wstring Board::getWord(int lineNo, int columnNo, bool horizontal) const
{
	wstring word;
	while (lineNo < lineCount_ && columnNo < columnCount_) {
		const BoardCell& cell = cells_[lineNo][columnNo];
		if (cell.isEmpty()) {
			break;
		}
		word.append(1, cell.getSymbol());
		if (horizontal) {
			++columnNo;
		} else {
			++lineNo;
		}
	}
	return word;
}

void Board::putWord(const wstring& word, int lineNo, int columnNo, bool horizontal)
{
	for (size_t letterNo = 0; letterNo < word.size(); ++letterNo) {
		if (lineNo < lineCount_ && columnNo < columnCount_) {
			cells_[lineNo][columnNo].setSymbol(word[letterNo]);
			if (horizontal) {
				++columnNo;
			} else {
				++lineNo;
			}
		} else {
			break;
		}
	}
}

void Board::cleanSelectors()
{
	for (int lineNo = 0; lineNo < lineCount_; ++lineNo) {
		for (int columnNo = 0; columnNo < columnCount_; ++columnNo) {
			cells_[lineNo][columnNo].cleanSelectors();
		}
	}
}

void Board::buildSelectors()
{
	for (int lineNo = 0; lineNo < lineCount_; ++lineNo) {
		for (int columnNo = 0; columnNo < columnCount_; ++columnNo) {
			buildSelectors(lineNo, columnNo);
		}
	}
}

void Board::buildSelectors(int lineNo, int columnNo)
{
	// TBD+: start here
	THROW("not implemented yet");
}

WordSelector Board::buildSelector(int lineNo, int columnNo, bool horizontal, int length)
{
	wstring pattern;

	for (int i = 0; i < length; ++i) {
		BoardCell* cell = 0;

		if (horizontal) {
			cell = &cells_[lineNo][columnNo + i];
		} else {
			cell = &cells_[lineNo + i][columnNo];
		}

		if (cell->isEmpty()) {
			pattern.append(1, WordSelector::WILDCARD);
		} else {
			pattern.append(1, cell->getSymbol());
		}
	}

	return WordSelector(pattern);
}

WordSelector Board::buildRandomSelector(int& lineNo, int& columnNo, bool& horizontal)
{
	Random rnd;

	lineNo = rnd.nextInt(lineCount_);
	columnNo = rnd.nextInt(columnCount_);

	horizontal = rnd.nextBool();
	if (horizontal) {
		while (columnNo >= columnCount_ - minWordLength_) {
			columnNo = rnd.nextInt(columnCount_);
		}
	} else {
		while (lineNo >= lineCount_ - minWordLength_) {
			lineNo = rnd.nextInt(lineCount_);
		}
	}

	int length = 0;
	if (horizontal) {
		length = rnd.nextInt(minWordLength_, min(maxWordLength_, columnCount_ - columnNo));
	} else {
		length = rnd.nextInt(minWordLength_, min(maxWordLength_, lineCount_ - lineNo));
	}

	return buildSelector(lineNo, columnNo, horizontal, length);
}

wostream& Board::write(wostream& out) const
{
	out << endl << L"/-";
	for (int columnNo = 0; columnNo < lineCount_; ++columnNo) {
		out << L"--";
	}
	out << L"\\" << endl;

	for (int lineNo = 0; lineNo < lineCount_; ++lineNo) {
		out << L"|";
		for (int columnNo = 0; columnNo < lineCount_; ++columnNo) {
			out << L" " << cells_[lineNo][columnNo].getSymbol();
		}
		out << L" |" << endl;
	}

	out << L"\\-";
	for (int columnNo = 0; columnNo < lineCount_; ++columnNo) {
		out << L"--";
	}
	out << L"/" << endl;

	return out;
}
