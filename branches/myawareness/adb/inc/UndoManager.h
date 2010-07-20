#ifndef UNDOMANAGER_H_
#define UNDOMANAGER_H_

#include <deque>

namespace adb {

class ReversibleCommand;

class UndoManager {
public:
	UndoManager(size_t maxSize = 1000);
	virtual ~UndoManager();

	void add(ReversibleCommand* command);
	ReversibleCommand* undo();
	ReversibleCommand* redo();
	void reset();

private:
	std::deque<ReversibleCommand*> history_;
	size_t maxSize_;
	int currentPosition_;
};

}

#endif /* UNDOMANAGER_H_ */
