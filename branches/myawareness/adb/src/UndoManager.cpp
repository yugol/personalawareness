#include <UndoManager.h>
#include <cmd/Command.h>
#include <Exception.h>

using namespace std;

namespace adb {

UndoManager::UndoManager(size_t maxSize) :
	maxSize_(maxSize), currentPosition_(-1)
{
	if (maxSize < 1) {
		throw Exception("undo history must be at least 1");
	}
}

UndoManager::~UndoManager()
{
	reset();
}

void UndoManager::reset()
{
	deque<ReversibleCommand*>::iterator it;
	for (it = history_.begin(); it != history_.end(); ++it) {
		delete (*it);
	}
	history_.clear();
	currentPosition_ = -1;
}

void UndoManager::add(ReversibleCommand* command)
{
	if (history_.size() >= maxSize_) {
		delete history_.at(0);
		history_.pop_front();
	}
	history_.push_back(command);
	currentPosition_ = history_.size() - 1;
}

ReversibleCommand* UndoManager::undo()
{
	if (currentPosition_ < 0) {
		return 0;
	}
	return history_.at(currentPosition_--);
}

ReversibleCommand* UndoManager::redo()
{
	if (currentPosition_ >= 0 && static_cast<size_t> (currentPosition_) >= history_.size()) {
		return 0;
	}
	return history_.at(currentPosition_++);

}

}
