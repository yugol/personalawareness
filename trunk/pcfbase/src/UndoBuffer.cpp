#include <Exception.h>
#include <ReversibleDatabaseCommand.h>
#include <UndoBuffer.h>

using namespace std;

UndoBuffer::UndoBuffer(size_t maxSize) :
    maxLength_(maxSize)
{
    if (maxSize < 1) {
        THROW("undo history must be at least 1");
    }
    reset();
}

UndoBuffer::~UndoBuffer()
{
    reset();
}

void UndoBuffer::reset()
{
    while (history_.size() > 0) {
        delete history_.at(0);
        history_.pop_front();
    }
    currentUndoPosition_ = -1;
}

void UndoBuffer::add(ReversibleDatabaseCommand* command)
{
    size_t addPos = currentUndoPosition_ + 1;
    while (history_.size() > addPos) {
        delete history_.at(addPos);
        history_.pop_back();
    }
    while (history_.size() >= maxLength_) {
        delete history_.at(0);
        history_.pop_front();
    }
    history_.push_back(command);
    currentUndoPosition_ = history_.size() - 1;
}

const ReversibleDatabaseCommand* UndoBuffer::getUndo() const
{
    if (currentUndoPosition_ >= 0) {
        return history_.at(currentUndoPosition_);
    }
    return 0;
}

const ReversibleDatabaseCommand* UndoBuffer::getRedo() const
{
    size_t redoPos = currentUndoPosition_ + 1;
    if (redoPos < history_.size()) {
        return history_.at(redoPos);
    }
    return 0;
}

void UndoBuffer::undo()
{
    ReversibleDatabaseCommand* cmd = const_cast<ReversibleDatabaseCommand*> (getUndo());
    if (cmd) {
        cmd->unexecute();
        --currentUndoPosition_;
    }
}

void UndoBuffer::redo()
{
    ReversibleDatabaseCommand* cmd = const_cast<ReversibleDatabaseCommand*> (getRedo());
    if (cmd) {
        cmd->execute();
        ++currentUndoPosition_;
    }
}

