#ifndef UNDOBUFFER_H_
#define UNDOBUFFER_H_

#include <deque>

namespace adb {

    class ReversibleDatabaseCommand;

    class UndoBuffer {
    public:
        UndoBuffer(size_t maxLength = 1000);
        virtual ~UndoBuffer();

        void reset();
        void add(ReversibleDatabaseCommand* command);
        const ReversibleDatabaseCommand* getUndo() const;
        const ReversibleDatabaseCommand* getRedo() const;
        void undo();
        void redo();
        int getMaxLength() const;

    private:
        std::deque<ReversibleDatabaseCommand*> history_;
        size_t maxLength_;
        int currentUndoPosition_;
    };

    inline int UndoBuffer::getMaxLength() const
    {
        return maxLength_;
    }

} // namespace adb

#endif /* UNDOBUFFER_H_ */
