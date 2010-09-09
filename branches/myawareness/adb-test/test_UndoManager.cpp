#include <ReversibleDatabaseCommand.h>
#include <UndoBuffer.h>
#include "_test.h"

class DummyCommand: public ReversibleDatabaseCommand {
public:
    DummyCommand(int marker) :
        ReversibleDatabaseCommand(0), marker_(marker)
    {
    }

    void* getCallbackParameter() const
    {
        return reinterpret_cast<void*> (marker_);
    }

    virtual void buildSqlCommand()
    {
    }

    virtual void buildReverseSqlCommand()
    {
    }

    virtual void execute()
    {
    }

    virtual void unexecute()
    {
    }

    virtual string getDescription() const
    {
        return "dummy command";
    }

private:
    int marker_;

};

TEST( Zero, UndoBuffer )
{
    UndoBuffer um;

    CHECK( !um.canUndo() );
    CHECK( !um.canRedo() );
}

TEST( One, UndoBuffer )
{
    UndoBuffer um;

    um.add(new DummyCommand(1));
    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getUndo())->getCallbackParameter()) );

    um.undo();
    CHECK( !um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getRedo())->getCallbackParameter()) );

    um.redo();
    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );
}

TEST( Two, UndoBuffer )
{
    UndoBuffer um;
    um.add(new DummyCommand(1));
    um.add(new DummyCommand(2));

    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getUndo())->getCallbackParameter()) );

    um.undo();
    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getRedo())->getCallbackParameter()) );

    um.redo();
    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getUndo())->getCallbackParameter()) );

    um.undo();
    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getUndo())->getCallbackParameter()) );

    um.undo();
    CHECK( !um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getRedo())->getCallbackParameter()) );

    um.redo();
    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getUndo())->getCallbackParameter()) );

    um.undo();
    CHECK( !um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 1, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getRedo())->getCallbackParameter()) );

    um.redo();
    CHECK( um.canUndo() );
    CHECK( um.canRedo() );

    LONGS_EQUAL( 2, reinterpret_cast<long>(static_cast<const DummyCommand*>(um.getRedo())->getCallbackParameter()) );

    um.redo();
    CHECK( um.canUndo() );
    CHECK( !um.canRedo() );
}
