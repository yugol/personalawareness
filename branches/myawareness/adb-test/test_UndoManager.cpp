#include <cmd/ReversibleDatabaseCommand.h>
#include <UndoManager.h>
#include "_test.h"

class DummyReversibleCommand: public ReversibleDatabaseCommand {
public:
    DummyReversibleCommand(int marker) :
        ReversibleDatabaseCommand(0), marker_(marker)
    {
    }

    void* getCallbackParameter()
    {
        return reinterpret_cast<void*> (marker_);
    }

    virtual void buildSqlCommand()
    {
    }

    virtual void buildReverseSqlCommand()
    {
    }

private:
    int marker_;

};

TEST( Zero, UndoManager )
{
    UndoManager um;

    CHECK( !um.canUndo() );
    CHECK( !um.canRedo() );
}

TEST( One, UndoManager )
{
    UndoManager um;
    um.add(new DummyReversibleCommand(1));

    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.undo())->getCallbackParameter()) );

    CHECK( !um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.redo())->getCallbackParameter()) );

    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );
}

TEST( Two, UndoManager )
{
    UndoManager um;
    um.add(new DummyReversibleCommand(1));
    um.add(new DummyReversibleCommand(2));

    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.undo())->getCallbackParameter()) );

    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.redo())->getCallbackParameter()) );

    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.undo())->getCallbackParameter()) );

    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.undo())->getCallbackParameter()) );

    CHECK( !um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.redo())->getCallbackParameter()) );

    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.undo())->getCallbackParameter()) );

    CHECK( !um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.redo())->getCallbackParameter()) );

    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<DummyReversibleCommand*>(um.redo())->getCallbackParameter()) );

    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );
}
