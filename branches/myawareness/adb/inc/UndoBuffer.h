#ifndef UNDOBUFFER_H_
#define UNDOBUFFER_H_

#include <deque>

namespace adb {

    class ReversibleDatabaseCommand;

    class UndoBuffer {
    public:
        UndoBuffer(size_t maxLength = 1000);
        virtual ~UndoBuffer();

        void add(ReversibleDatabaseCommand* command);
        bool canUndo() const;
        bool canRedo() const;
        const ReversibleDatabaseCommand* getUndo() const;
        const ReversibleDatabaseCommand* getRedo() const;
        void undo();
        void redo();
        void reset();
        int getMaxLength() const;
        void setMaxLength(int maxLength);

    private:
        enum {
            ADD, UNDO, REDO
        };

        std::deque<ReversibleDatabaseCommand*> history_;
        size_t maxLength_;
        size_t currentPosition_;
        int lastAction_;
    };

    inline int UndoBuffer::getMaxLength() const
    {
        return maxLength_;
    }

} // namespace adb

#endif /* UNDOBUFFER_H_ */
