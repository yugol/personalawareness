#ifndef UNDOMANAGER_H_
#define UNDOMANAGER_H_

#include <deque>

namespace adb {

    class ReversibleDatabaseCommand;

    class UndoManager {
    public:
        UndoManager(size_t maxSize = 1000);
        virtual ~UndoManager();

        bool canUndo();
        bool canRedo();
        void add(ReversibleDatabaseCommand* command);
        ReversibleDatabaseCommand* undo();
        ReversibleDatabaseCommand* redo();
        void reset();

    private:
        enum LastAction {
            NONE, UNDO, REDO
        };

        std::deque<ReversibleDatabaseCommand*> history_;
        size_t maxSize_;
        size_t currentPosition_;
        int lastAction_;
    };

} // namespace adb

#endif /* UNDOMANAGER_H_ */
