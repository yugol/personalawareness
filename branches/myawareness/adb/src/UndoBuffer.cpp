#include <Exception.h>
#include <ReversibleDatabaseCommand.h>
#include <UndoBuffer.h>

using namespace std;

namespace adb {

    UndoBuffer::UndoBuffer(size_t maxSize) :
        maxLength_(maxSize), currentPosition_(0), lastAction_(ADD)
    {
        if (maxSize < 1) {
            THROW("undo history must be at least 1");
        }
    }

    UndoBuffer::~UndoBuffer()
    {
        reset();
    }

    void UndoBuffer::add(ReversibleDatabaseCommand* command)
    {
        if (history_.size() >= maxLength_) {
            delete history_.at(0);
            history_.pop_front();
        }
        history_.push_back(command);
        currentPosition_ = history_.size();
        lastAction_ = ADD;
    }

    void UndoBuffer::reset()
    {
        while (history_.size() > 0) {
            ReversibleDatabaseCommand* cmd = history_.at(0);
            delete cmd;
            history_.pop_front();
        }
        currentPosition_ = 0;
        lastAction_ = ADD;
    }

    bool UndoBuffer::canUndo() const
    {
        if (history_.size() <= 0) {
            return false;
        }

        switch (lastAction_) {
            case ADD:
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

    bool UndoBuffer::canRedo() const
    {
        if (history_.size() <= 0) {
            return false;
        }

        switch (lastAction_) {
            case ADD:
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

    const ReversibleDatabaseCommand* UndoBuffer::getUndo() const
    {
        ReversibleDatabaseCommand* cmd = 0;
        if (canUndo()) {
            if (UNDO == lastAction_ || ADD == lastAction_) {
                return history_.at(currentPosition_ - 1);
            }
            return history_.at(currentPosition_);
        }
        return cmd;
    }

    void UndoBuffer::undo()
    {
        ReversibleDatabaseCommand* cmd = 0;

        if (!canUndo()) {
            THROW("cannot UNdo");
        }

        if (UNDO == lastAction_ || ADD == lastAction_) {
            --currentPosition_;
        } else {
            lastAction_ = UNDO;
        }

        cmd = history_.at(currentPosition_);
        cmd->unexecute();
    }

    const ReversibleDatabaseCommand* UndoBuffer::getRedo() const
    {
        ReversibleDatabaseCommand* cmd = 0;
        if (canRedo()) {
            if (REDO == lastAction_) {
                return history_.at(currentPosition_ + 1);
            }
            return history_.at(currentPosition_);
        }
        return cmd;
    }

    void UndoBuffer::redo()
    {
        ReversibleDatabaseCommand* cmd = 0;

        if (!canRedo()) {
            THROW("cannot REdo");
        }

        if (REDO == lastAction_) {
            ++currentPosition_;
        } else {
            lastAction_ = REDO;
        }

        cmd = history_.at(currentPosition_);
        cmd->execute();
    }

} // namespac adb
