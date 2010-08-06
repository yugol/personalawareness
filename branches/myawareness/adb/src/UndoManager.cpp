#include <Exception.h>
#include <UndoManager.h>

using namespace std;

namespace adb {

UndoManager::UndoManager(size_t maxSize) :
	maxSize_(maxSize), currentPosition_(0), lastAction_(NONE)
{
	if (maxSize < 1) {
	    THROW("undo history must be at least 1");
	}
}

UndoManager::~UndoManager()
{
	reset();
}

void UndoManager::reset()
{
	while (history_.size() > 0) {
		ReversibleDatabaseCommand* cmd = history_.at(0);
		delete cmd;
		history_.pop_front();
	}
	currentPosition_ = 0;
}

bool UndoManager::canUndo()
{
	if (history_.size() <= 0) {
		return false;
	}

	switch (lastAction_) {
	case NONE:
	case UNDO:
		if (0 == currentPosition_) {
			return false;
		}
		return true;
	case REDO:
		return true;
	default:
	    THROW(Exception::UNDEFINED_MESSAGE);
	}
}

bool UndoManager::canRedo()
{
	if (history_.size() <= 0) {
		return false;
	}

	switch (lastAction_) {
	case NONE:
		if (currentPosition_ >= history_.size()) {
			return false;
		}
		return true;
	case REDO:
		if (currentPosition_ >= history_.size() - 1) {
			return false;
		}
		return true;
	case UNDO:
		return true;
	default:
	    THROW(Exception::UNDEFINED_MESSAGE);
	}
}

void UndoManager::add(ReversibleDatabaseCommand* command)
{
	if (history_.size() >= maxSize_) {
		delete history_.at(0);
		history_.pop_front();
	}
	history_.push_back(command);
	currentPosition_ = history_.size();
	lastAction_ = NONE;
}

ReversibleDatabaseCommand* UndoManager::undo()
{
	if (!canUndo()) {
	    THROW("cannot UNdo");
	}

	if (UNDO == lastAction_ || NONE == lastAction_) {
		--currentPosition_;
	} else {
		lastAction_ = UNDO;
	}

	return history_.at(currentPosition_);
}

ReversibleDatabaseCommand* UndoManager::redo()
{
	if (!canRedo()) {
	    THROW("cannot REdo");
	}

	if (REDO == lastAction_) {
		++currentPosition_;
	} else {
		lastAction_ = REDO;
	}

	return history_.at(currentPosition_);
}

}
